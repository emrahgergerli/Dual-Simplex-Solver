namespace Genetic_Algorithm_Tsp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ComboBox combo_crossoverOperator;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_iterationNumber = new System.Windows.Forms.TextBox();
            this.txt_populationSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_mutationProbability = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_run = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_elitismRatio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            combo_crossoverOperator = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(188, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(20, 404);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(294, 260);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Population Size";
            // 
            // txt_iterationNumber
            // 
            this.txt_iterationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_iterationNumber.Location = new System.Drawing.Point(17, 59);
            this.txt_iterationNumber.Name = "txt_iterationNumber";
            this.txt_iterationNumber.Size = new System.Drawing.Size(144, 23);
            this.txt_iterationNumber.TabIndex = 3;
            this.txt_iterationNumber.Text = "100";
            // 
            // txt_populationSize
            // 
            this.txt_populationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_populationSize.Location = new System.Drawing.Point(17, 119);
            this.txt_populationSize.Name = "txt_populationSize";
            this.txt_populationSize.Size = new System.Drawing.Size(144, 23);
            this.txt_populationSize.TabIndex = 5;
            this.txt_populationSize.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Iteration Number";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.Location = new System.Drawing.Point(20, 183);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(141, 23);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mutation Probability";
            // 
            // txt_mutationProbability
            // 
            this.txt_mutationProbability.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_mutationProbability.Location = new System.Drawing.Point(20, 241);
            this.txt_mutationProbability.Name = "txt_mutationProbability";
            this.txt_mutationProbability.Size = new System.Drawing.Size(141, 23);
            this.txt_mutationProbability.TabIndex = 9;
            this.txt_mutationProbability.Text = "0,001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(17, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Crossover Probability";
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.Color.White;
            this.btn_run.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btn_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_run.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_run.Location = new System.Drawing.Point(188, 273);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(126, 104);
            this.btn_run.TabIndex = 10;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // combo_crossoverOperator
            // 
            combo_crossoverOperator.Cursor = System.Windows.Forms.Cursors.Hand;
            combo_crossoverOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            combo_crossoverOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            combo_crossoverOperator.FormattingEnabled = true;
            combo_crossoverOperator.Items.AddRange(new object[] {
            "One Point",
            "Two Point",
            "Position Based Crossover"});
            combo_crossoverOperator.Location = new System.Drawing.Point(20, 353);
            combo_crossoverOperator.Name = "combo_crossoverOperator";
            combo_crossoverOperator.Size = new System.Drawing.Size(141, 24);
            combo_crossoverOperator.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(17, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Crossover Operator";
            // 
            // txt_elitismRatio
            // 
            this.txt_elitismRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_elitismRatio.Location = new System.Drawing.Point(20, 295);
            this.txt_elitismRatio.Name = "txt_elitismRatio";
            this.txt_elitismRatio.Size = new System.Drawing.Size(141, 23);
            this.txt_elitismRatio.TabIndex = 17;
            this.txt_elitismRatio.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(17, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Elitism Ratio";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(320, 43);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(904, 620);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1236, 675);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txt_elitismRatio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(combo_crossoverOperator);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.txt_mutationProbability);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_populationSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_iterationNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_iterationNumber;
        private System.Windows.Forms.TextBox txt_populationSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_mutationProbability;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_elitismRatio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

