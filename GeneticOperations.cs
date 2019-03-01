using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm_Tsp
{
    class GeneticOperations
    {
        private Random rng = new Random();
        


        //
        //Ilk populasyonu olusturma 
        public List<TspFile> CreateFirstPopulation(TspFile firstTspFile, int populationSize)
        {
            List<TspFile> populationList = new List<TspFile>();
            for (int i = 0; i < populationSize; i++)
            {
                List<City> cityPopulation = new List<City>(firstTspFile.cityList);
                Shuffle<City>(cityPopulation);
                TspFile tspFile = new TspFile();
                tspFile.cityList = cityPopulation;
                populationList.Add(tspFile);
            }
            return populationList;
        }


        //ilk populasyonu yaratmak  icin olusturdugumuz karistirma fonksiyonumuz
        public void Shuffle<T>(IList<T> list)
        {
            // https://stackoverflow.com/questions/273313/randomize-a-listt

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //Fitness degerlerini dosya tipine gore hesaplayan fonksiyon
        //fitness fonksiyonumuz uzaklik hesabi oldugundan problemin tipi fitness fonksiyonumuzu da belirliyor.
        public void CalculateFitnessFunction(TspFile tspFile, EdgeWeightType edgeWeightType)
        {
            switch (edgeWeightType)
            {
                case EdgeWeightType.EUC_2D:
                    tspFile.EuclidDistance();
                    break;

                case EdgeWeightType.MAX_2D:
                    tspFile.MaximumDistance();
                    break;

                case EdgeWeightType.MAN_2D:
                    tspFile.ManhattanDistance();
                    break;

                case EdgeWeightType.CEIL_2D:
                    tspFile.CeilDistance();
                    break;

                default:
                    break;
            }
        }

        //------Parent seciminde kullandigimiz Rank Selection yontemi-------------
        //Algoritma en kotuden en iyiye fitness degerlerini siralayip,
        //sirasina gore  i.sira / (n(n+1))/2 formulu ile hesapliyor.
        //Boylelikle en iyi fitness en buyuk olasiliga sahip oluyor.
        public TspFile[] RankSelection(List<TspFile> populationList)
        {

            Dictionary<double, double[]> rank = new Dictionary<double, double[]>();

            double n = (populationList.Count * (populationList.Count + 1)) / 2;
            double cumulativeRankSum = 0; // kumulatif toplam urettigimiz random sayinin nereye dustugunu bulmak icin tanimlandi.


            for (int i = 1; i <= populationList.Count; i++)
            {

                rank.Add(i, new double[] { i / n, cumulativeRankSum + i / n });
                cumulativeRankSum += i / n;


            }

            Random r = new Random();
            double p1 = r.Next(0, int.MaxValue) / (double)int.MaxValue; //0 ile 1 arasinda sayi uretmek icin kullandik.
            double p2 = r.Next(0, int.MaxValue) / (double)int.MaxValue;

            TspFile parent1 = new TspFile();
            TspFile parent2 = new TspFile();
            parent1 = populationList[0];
            parent2 = populationList[0];
            for (int i = rank.Count; i >= 1; i--)
            {
                rank.TryGetValue(i, out double[] value);
                if (p1 >= value[1])
                {
                    parent1 = populationList[i];
                    break;
                }

            }
            for (int i = rank.Count; i >= 1; i--)
            {
                rank.TryGetValue(i, out double[] value);
                if (p2 >= value[1])
                {
                    parent2 = populationList[i];
                    break;
                }
            }

            return new TspFile[] { parent1, parent2 };

        }



        //Tek Noktali Caprazlama Fonksiyonu
        //Rank`tangelen 2 adet parent, random bir noktadan bolunuyor.
        public TspFile[] OnePointCrossover(TspFile[] parents)
        {
            TspFile parent1 = parents[0];
            TspFile parent2 = parents[1];
            Random r = new Random();
            int position = r.Next(1, parent1.cityList.Count);
            TspFile child1 = new TspFile();
            TspFile child2 = new TspFile();

            // Crossover Child 1 
            //ilk cocuga 1. parent`in ilk parcasi + 2.parent`in ikinci parcasi ekleniyor + 2. parent'in seçilmeyen parçaları da ekleniyor
            child1.cityList.AddRange(parent1.cityList.GetRange(0, position));
            for (int i = position; i < parent2.cityList.Count; i++)
            {
                //Bu surecte tekrar eden sehirlerin kontrolu saglaniyor.
                if (!child1.cityList.Exists(city =>
                {
                    if (city.index == parent2.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child1.cityList.Add(parent2.cityList[i]);
            }
            for (int i = 0; i < position; i++)
            {
                if (!child1.cityList.Exists(city =>
                {
                    if (city.index == parent2.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child1.cityList.Add(parent2.cityList[i]);
            }


            // Crossover Child 2
            child2.cityList.AddRange(parent2.cityList.GetRange(0, position));
            for (int i = position; i < parent2.cityList.Count; i++)
            {
                if (!child2.cityList.Exists(city =>
                {
                    if (city.index == parent1.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child2.cityList.Add(parent1.cityList[i]);
            }
            for (int i = 0; i < position; i++)
            {
                if (!child2.cityList.Exists(city =>
                {
                    if (city.index == parent1.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child2.cityList.Add(parent1.cityList[i]);
            }

            return new TspFile[] { child1, child2 };
        }



        //Iki Noktali Caprazlama Fonksiyonu
        //Rank`tangelen 2 adet parent, random iki noktadan bolunuyor.
        public TspFile[] TwoPointCrossover(TspFile[] parents)
        {
            TspFile parent1 = parents[0];
            TspFile parent2 = parents[1];
            Random r = new Random();
            int positionMin;
            int positionMax;
            do
            {
                positionMin = r.Next(1, parent1.cityList.Count); // İlk kesme noktası
                positionMax = r.Next(1, parent1.cityList.Count); // İkinci kesme noktası
            } while (positionMax == positionMin);  //eger iki noktada esit gelirse diye

            if (positionMin > positionMax) //eger min deger max degerden buyuk olursa isimler dogru olmasi adina yer degistirme yapiyoruz.
            {
                int temp = positionMin;
                positionMin = positionMax;
                positionMax = temp;
            }

            TspFile child1 = new TspFile();
            TspFile child2 = new TspFile();

            // Crossover Child 1
            //child1 = [----parent1----/----parent2----/----parent1---]  yapisinin olusmasi icin gerekli ayristirma 
            //         [0--------------min-------------max---------sehirSayisi]
            child1.cityList.AddRange(parent1.cityList.GetRange(0, positionMin));
           // child1.cityList.AddRange(parent2.cityList.GetRange(positionMin + 1, positionMax - positionMin));
            child1.cityList.AddRange(parent1.cityList.GetRange(positionMax, parent2.cityList.Count - positionMax));
            int location = positionMin;
            for (int i = 0; i < parent2.cityList.Count; i++)
            {
                if (!child1.cityList.Exists(city =>
                {
                    if (city.index == parent2.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child1.cityList.Insert(location++, parent2.cityList[i]);
            }

            // Crossover Child 2
            //child2 = [----parent2----/----parent1----/----parent2---]
            child2.cityList.AddRange(parent2.cityList.GetRange(0, positionMin));
           // child2.cityList.AddRange(parent1.cityList.GetRange(positionMin + 1, positionMax - positionMin));
            child2.cityList.AddRange(parent2.cityList.GetRange(positionMax, parent2.cityList.Count - positionMax));
            location = positionMin;
            for (int i = 0; i < parent1.cityList.Count; i++)
            {
                if (!child2.cityList.Exists(city =>
                {
                    if (city.index == parent1.cityList[i].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                    child2.cityList.Insert(location++, parent1.cityList[i]);
            }
            return new TspFile[] { child1, child2 };
        }


        //Pozisyon bazli Crossover Fonksiyonu
        //Parent1`den Rastgele secilen pozisyonlardaki genler(sehirler) cocuk kromozoma aktarilir.
        //parent2`den sirasiyla cocukta olmayan genler aktarilirken olanlar goz ardi edilir.
        public TspFile[] PositionBasedCrossover(TspFile[] parents)
        {
            TspFile parent1 = parents[0];
            TspFile parent2 = parents[1];
            Random r = new Random();
            List<int> positionArray = new List<int>();
            int randomNumber = r.Next(0, parent1.cityList.Count); // random kac tane sayi gelecegini yine random seciyoruz.
            for (int i = 0; i < randomNumber; i++)
            {
                positionArray.Add(r.Next(0, parent1.cityList.Count)); // Bu listeye random sayilari atiyoruz.
            }

            //Rank Selection`dan gelen cocuklar
            TspFile child1 = new TspFile();
            TspFile child2 = new TspFile();

            for (int i = 0; i < parent1.cityList.Count; i++)
            {
                City city = new City
                {
                    index = 0
                };
                child1.cityList.Add(city);
            }

            //Burda sehrin tekrar edip etmedigini kontrol ediyoruz.
            for (int i = 0; i < parent1.cityList.Count; i++)
            {
                if (positionArray.Exists(find =>
                {
                    if (find == i)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    child1.cityList[i] = parent1.cityList[i];
                }
            }

            for (int j = 0; j < parent1.cityList.Count; j++)
            {
                if (!child1.cityList.Exists(city =>
                {
                    if (city.index == parent2.cityList[j].index)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    for (int k = 0; k < child1.cityList.Count; k++)
                    {
                        if (child1.cityList[k].index == 0)
                        {
                            child1.cityList[k] = parent2.cityList[j];
                            break;
                        }
                    }
                }
            }
            // child2 yapılacak?
            return new TspFile[] { child1, child2 };
        }

        //Mutasyon Fonksiyonu

        public void Mutation(TspFile chromosome, double probability)
        {
            Random r = new Random();
            double rndProbability = r.NextDouble();
            if (rndProbability <= probability) //Mutasyon olasiligi, random sayimizdan buyukse mutasyon islemi gerceklesir
            {
                // random pozisyondaki sehri 1 arttiriyoruz ama bunu gecici bir degiskende tutuyoruz.
                int mPosition = r.Next(0, chromosome.cityList.Count);
                int temp = chromosome.cityList[mPosition].index;
                int temp2 = temp + 1;

                //degisecek sehri bulma
                for (int i = 0; i < chromosome.cityList.Count; i++)
                {
                    //degeri artirilan sehri buldugmuzda ve o sehir, sehir sayimizdan kucuk oldugunda 
                    if (chromosome.cityList[i].index == temp2 && temp2 <= chromosome.cityList.Count)
                    {


                        chromosome.cityList[i].index = temp; //degeri 1 artan sehiri 1 eksiltiyoruz
                        chromosome.cityList[mPosition].index++; //mutasyon gecirecek gercek geni 1 arttiriyoruz
                        break;
                    }
                }

            }

        }

    }
}
