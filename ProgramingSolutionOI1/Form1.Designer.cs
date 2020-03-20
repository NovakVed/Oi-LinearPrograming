namespace ProgramingSolutionOI1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvTableProductMachine = new System.Windows.Forms.DataGridView();
            this.BtnAddMachine = new System.Windows.Forms.Button();
            this.BtnAddMachineCapacityAndLimitation = new System.Windows.Forms.Button();
            this.BtnAddProductNetIncome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteColumn = new System.Windows.Forms.Button();
            this.BtnOriginalMethod = new System.Windows.Forms.Button();
            this.CmbTypeOfRevenue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RtxtFormulaResult = new System.Windows.Forms.RichTextBox();
            this.BtnLoadGraph = new System.Windows.Forms.Button();
            this.BtnDualMethod = new System.Windows.Forms.Button();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableProductMachine)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTableProductMachine
            // 
            this.dgvTableProductMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableProductMachine.Location = new System.Drawing.Point(9, 21);
            this.dgvTableProductMachine.Name = "dgvTableProductMachine";
            this.dgvTableProductMachine.RowHeadersWidth = 51;
            this.dgvTableProductMachine.RowTemplate.Height = 24;
            this.dgvTableProductMachine.Size = new System.Drawing.Size(775, 221);
            this.dgvTableProductMachine.TabIndex = 0;
            // 
            // BtnAddMachine
            // 
            this.BtnAddMachine.Location = new System.Drawing.Point(90, 248);
            this.BtnAddMachine.Name = "BtnAddMachine";
            this.BtnAddMachine.Size = new System.Drawing.Size(111, 74);
            this.BtnAddMachine.TabIndex = 2;
            this.BtnAddMachine.Text = "Dodaj Radnu Snagu";
            this.BtnAddMachine.UseVisualStyleBackColor = true;
            this.BtnAddMachine.Click += new System.EventHandler(this.BtnAddMachine_Click);
            // 
            // BtnAddMachineCapacityAndLimitation
            // 
            this.BtnAddMachineCapacityAndLimitation.Location = new System.Drawing.Point(571, 251);
            this.BtnAddMachineCapacityAndLimitation.Name = "BtnAddMachineCapacityAndLimitation";
            this.BtnAddMachineCapacityAndLimitation.Size = new System.Drawing.Size(102, 71);
            this.BtnAddMachineCapacityAndLimitation.TabIndex = 3;
            this.BtnAddMachineCapacityAndLimitation.Text = "Dodaj kapacitet i ograničenja";
            this.BtnAddMachineCapacityAndLimitation.UseVisualStyleBackColor = true;
            this.BtnAddMachineCapacityAndLimitation.Click += new System.EventHandler(this.BtnAddMachineCapacityAndLimitation_Click);
            // 
            // BtnAddProductNetIncome
            // 
            this.BtnAddProductNetIncome.Location = new System.Drawing.Point(679, 250);
            this.BtnAddProductNetIncome.Name = "BtnAddProductNetIncome";
            this.BtnAddProductNetIncome.Size = new System.Drawing.Size(105, 72);
            this.BtnAddProductNetIncome.TabIndex = 4;
            this.BtnAddProductNetIncome.Text = "Dodaj Neto Prihod";
            this.BtnAddProductNetIncome.UseVisualStyleBackColor = true;
            this.BtnAddProductNetIncome.Click += new System.EventHandler(this.BtnAddProductNetIncome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDeleteColumn);
            this.groupBox1.Controls.Add(this.BtnAddProductNetIncome);
            this.groupBox1.Controls.Add(this.dgvTableProductMachine);
            this.groupBox1.Controls.Add(this.BtnAddMachineCapacityAndLimitation);
            this.groupBox1.Controls.Add(this.BtnAddMachine);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 328);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proizvod/Stroj";
            // 
            // BtnDeleteColumn
            // 
            this.BtnDeleteColumn.Location = new System.Drawing.Point(9, 248);
            this.BtnDeleteColumn.Name = "BtnDeleteColumn";
            this.BtnDeleteColumn.Size = new System.Drawing.Size(75, 74);
            this.BtnDeleteColumn.TabIndex = 5;
            this.BtnDeleteColumn.Text = "Izbrisi Stupac";
            this.BtnDeleteColumn.UseVisualStyleBackColor = true;
            this.BtnDeleteColumn.Click += new System.EventHandler(this.BtnDeleteColumn_Click);
            // 
            // BtnOriginalMethod
            // 
            this.BtnOriginalMethod.Location = new System.Drawing.Point(821, 130);
            this.BtnOriginalMethod.Name = "BtnOriginalMethod";
            this.BtnOriginalMethod.Size = new System.Drawing.Size(235, 56);
            this.BtnOriginalMethod.TabIndex = 2;
            this.BtnOriginalMethod.Text = "Originalni oblik";
            this.BtnOriginalMethod.UseVisualStyleBackColor = true;
            this.BtnOriginalMethod.Click += new System.EventHandler(this.BtnOriginalMethod_Click);
            // 
            // CmbTypeOfRevenue
            // 
            this.CmbTypeOfRevenue.FormattingEnabled = true;
            this.CmbTypeOfRevenue.Items.AddRange(new object[] {
            "Maksimalni prihod",
            "Minimalni prihod"});
            this.CmbTypeOfRevenue.Location = new System.Drawing.Point(819, 35);
            this.CmbTypeOfRevenue.Name = "CmbTypeOfRevenue";
            this.CmbTypeOfRevenue.Size = new System.Drawing.Size(235, 24);
            this.CmbTypeOfRevenue.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Odaberi vrstu prihoda";
            // 
            // RtxtFormulaResult
            // 
            this.RtxtFormulaResult.Location = new System.Drawing.Point(21, 346);
            this.RtxtFormulaResult.Name = "RtxtFormulaResult";
            this.RtxtFormulaResult.Size = new System.Drawing.Size(792, 173);
            this.RtxtFormulaResult.TabIndex = 8;
            this.RtxtFormulaResult.Text = "";
            // 
            // BtnLoadGraph
            // 
            this.BtnLoadGraph.Location = new System.Drawing.Point(822, 254);
            this.BtnLoadGraph.Name = "BtnLoadGraph";
            this.BtnLoadGraph.Size = new System.Drawing.Size(235, 56);
            this.BtnLoadGraph.TabIndex = 9;
            this.BtnLoadGraph.Text = "Ucitaj Graf";
            this.BtnLoadGraph.UseVisualStyleBackColor = true;
            this.BtnLoadGraph.Click += new System.EventHandler(this.BtnLoadGraph_Click);
            // 
            // BtnDualMethod
            // 
            this.BtnDualMethod.Location = new System.Drawing.Point(822, 192);
            this.BtnDualMethod.Name = "BtnDualMethod";
            this.BtnDualMethod.Size = new System.Drawing.Size(234, 56);
            this.BtnDualMethod.TabIndex = 10;
            this.BtnDualMethod.Text = "Dualni oblik";
            this.BtnDualMethod.UseVisualStyleBackColor = true;
            this.BtnDualMethod.Click += new System.EventHandler(this.BtnDualMethod_Click);
            // 
            // Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(21, 525);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(792, 439);
            this.Chart.TabIndex = 11;
            this.Chart.Text = "chart";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProgramingSolutionOI1.Properties.Resources.PrimjerUnosa;
            this.pictureBox1.Location = new System.Drawing.Point(10, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 278);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(1082, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 328);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Primjer Unosa Podataka";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 976);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.BtnDualMethod);
            this.Controls.Add(this.BtnLoadGraph);
            this.Controls.Add(this.RtxtFormulaResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbTypeOfRevenue);
            this.Controls.Add(this.BtnOriginalMethod);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableProductMachine)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTableProductMachine;
        private System.Windows.Forms.Button BtnAddMachine;
        private System.Windows.Forms.Button BtnAddMachineCapacityAndLimitation;
        private System.Windows.Forms.Button BtnAddProductNetIncome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnDeleteColumn;
        private System.Windows.Forms.Button BtnOriginalMethod;
        private System.Windows.Forms.ComboBox CmbTypeOfRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RtxtFormulaResult;
        private System.Windows.Forms.Button BtnLoadGraph;
        private System.Windows.Forms.Button BtnDualMethod;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

