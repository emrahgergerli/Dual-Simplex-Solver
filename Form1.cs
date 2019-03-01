using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Genetic_Algorithm_Tsp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TspFile tspFile;
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
        }


        // Dosya okuma Fonksiyonu
        //Butun satirlari okuyup lines`a atiyor.
        // daha sonra string islemleri ile tspfile classina tanimliyoruz.
        void ReadFile()
        {
            listBox1.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                tspFile = new TspFile();
                bool startCoordinat = false;
                bool rightFile = true;
                char[] seperators = new char[] { ' ' };

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();

                    if (line != "NODE_COORD_SECTION" && startCoordinat == false)
                    {
                        string before = line.Split(':')[0].Trim();
                        string after = line.Split(':')[1].Trim();


                        if (before == "NAME")
                        {
                            tspFile.name = after;
                        }
                        else if (before == "TYPE")
                        {
                            if (after == "TSP")
                            {
                                tspFile.type = after;
                            }
                            else
                            {
                                rightFile = false;  /////// Dosya TSP degil ise yanlis dosya tipi 
                                break;
                            }

                        }
                        else if (before == "COMMENT")
                        {
                            tspFile.comment = after;
                        }
                        else if (before == "DIMENSION")
                        {
                            tspFile.dimension = int.Parse(after);
                        }
                        else if (before == "EDGE_WEIGHT_TYPE") //tipi 2d olmayanlari okumuyor.
                        {
                            try
                            {
                                tspFile.edgeWeightType = (EdgeWeightType)Enum.Parse(typeof(EdgeWeightType), after);
                            }
                            catch (Exception)
                            {
                                rightFile = false;
                                MessageBox.Show("Yanlış Dosya Formatı. Geçerli formatlar EUC_2D - MAX_2D - MAN_2D - CEIL_2D");
                                break;
                            }

                        }
                    }

                    else if (line == "NODE_COORD_SECTION")
                    {
                        startCoordinat = true;
                    }

                    else if (line != "EOF")
                    {

                        line = lines[i].Trim();
                        string[] splitLine = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                        int index = int.Parse(splitLine[0]);
                        double x = double.Parse(splitLine[1].Replace('.', ','));
                        double y = double.Parse(splitLine[2].Replace('.', ','));
                        tspFile.AddCity(index, x, y);

                    }
                }
                if (rightFile) // Dosya tsp ve tipi 2d ise 
                {
                    listBox1.Items.Add(tspFile.name);
                    listBox1.Items.Add(tspFile.comment);
                    listBox1.Items.Add(tspFile.type);
                    listBox1.Items.Add(tspFile.dimension);
                    listBox1.Items.Add(tspFile.edgeWeightType);
                    listBox1.Items.Add(tspFile.MaximumDistance());
                    for (int i = 0; i < tspFile.cityList.Count; i++)
                    {
                        listBox1.Items.Add(tspFile.cityList[i].index + ".city " + tspFile.cityList[i].x + " , " + tspFile.cityList[i].y);
                    }
                }

            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Distance");
            int iterationNumber = int.Parse(txt_iterationNumber.Text);
            int populationSize = int.Parse(txt_populationSize.Text);
            double mutationProbability = double.Parse(txt_mutationProbability.Text);
            double elitismRatio = double.Parse(txt_elitismRatio.Text);
            string crossoverType = combo_crossoverOperator.Text;



            GeneticOperations geneticOperations = new GeneticOperations();
            List<TspFile> populationList = geneticOperations.CreateFirstPopulation(tspFile, populationSize);
            List<TspFile> newPopulationList = new List<TspFile>();
            TspFile parent1;
            TspFile parent2;


            for (int j = 0; j < populationList.Count; j++)
            {
                //populasyonun fitness degerlerinin hesaplanmasi
                geneticOperations.CalculateFitnessFunction(populationList[j], tspFile.edgeWeightType);
            }

            // burada popülasyon sıralanacak fitness değerine göre
            populationList.Sort();

            double maxFitness = 0, minFitness = double.MaxValue, meanFitness = 0;


            for (int i = 0; i < iterationNumber; i++)
            {
                newPopulationList.Clear();

                // elitizm 
                int elitismCount = (int)(elitismRatio * populationSize);
                for (int j = 1; j <= elitismCount; j++)
                {
                    newPopulationList.Add(populationList[populationList.Count - j]);
                }

                // popülasyonlar oluşturuluyor
                while (newPopulationList.Count <= populationSize)
                {

                    // Popülasyona genetik algoritmalar uygulanıyor
                    TspFile[] parents = geneticOperations.RankSelection(populationList); //Rank Selection yapilmasi, geriye 2 parent donuyor.


                    parent1 = parents[0];
                    parent2 = parents[1];

                    switch (crossoverType)
                    {
                        case "One Point":
                            parents = geneticOperations.OnePointCrossover(parents);
                            break;
                        case "Two Point":
                            parents = geneticOperations.TwoPointCrossover(parents);
                            break;
                        case "Position Based Crossover": // Bu caprazlama da tek cocuk elde ettigimiz icin 2 kere yapiyoruz
                            parent1 = geneticOperations.PositionBasedCrossover(parents)[0];
                            parent2 = geneticOperations.PositionBasedCrossover(parents)[0];
                            parents[0] = parent1;
                            parents[1] = parent2;
                            break;
                    }

                    geneticOperations.Mutation(parent1, mutationProbability);
                    geneticOperations.Mutation(parent2, mutationProbability);
                    newPopulationList.AddRange(parents);
                }

                for (int j = 0; j < newPopulationList.Count; j++)
                {
                    geneticOperations.CalculateFitnessFunction(newPopulationList[j], tspFile.edgeWeightType);

                    maxFitness = Math.Max(maxFitness, newPopulationList[j].distance);
                    minFitness = Math.Min(minFitness, newPopulationList[j].distance);
                    meanFitness += newPopulationList[j].distance;

                    meanFitness /= newPopulationList.Count;
                }

                populationList = new List<TspFile>(newPopulationList);
                populationList.Sort();

               
                series.Points.Add(minFitness);
            }

            TspFile result = new TspFile();
            minFitness = double.MaxValue;
            for (int k = 0; k < populationList.Count; k++)
            {

                listBox1.Items.Add(populationList[k].distance);
                if (minFitness > populationList[k].distance)
                {
                    minFitness = populationList[k].distance;
                    result = populationList[k];
                }
            }

            /*
            double max = 0, min = double.MaxValue, mean = 0;
            for (int k = 0; k < populationList.Count; k++)
            {
                max = Math.Max(max, populationList[k].distance);
                min = Math.Min(min, populationList[k].distance);
                mean += populationList[k].distance;
            }
            mean /= populationList.Count;
            listBox1.Items.Add("maximum fitness " + max);
            listBox1.Items.Add("minimum fitness " + min);
            listBox1.Items.Add("mean fitness " + mean);

            */

            /*
            for (int j = 0; j < populationList.Count; j++)
            {
                geneticOperations.CalculateFitnessFunction(populationList[j], tspFile.edgeWeightType);
            }
            */
            this.Text = "Bitti";
            SaveFile(result,minFitness);
        }

        void SaveFile(TspFile result, double bestFitness)
        {
            StreamWriter sw = new StreamWriter(tspFile.name + ".tour");
            sw.WriteLine("Name : " + tspFile.name + ".tour");
            sw.WriteLine("Comment : " + bestFitness);
            sw.WriteLine("TYPE : TOUR");
            sw.WriteLine("DIMENSION : " + tspFile.dimension);
            sw.WriteLine("TOUR_SECTION");
            for (int i = 0; i < result.cityList.Count; i++)
            {
                sw.WriteLine(result.cityList[i].index);
            }
            sw.WriteLine("-1");
            sw.WriteLine("EOF");
            sw.Close();
        }




    }
}
