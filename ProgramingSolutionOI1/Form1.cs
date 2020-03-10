using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramingSolutionOI1
{
    public partial class Form1 : Form
    {
        //TODO: Napravi za minimum
        //TODO: Popravi ograničenja
        //TODO: Popravi upis u tablicu
        private DataTable DataTableProductMachine;
        ProductMachine productMachine = new ProductMachine();

        public int btnPressed = 0;

        public Form1()
        {
            InitializeComponent();

            DataTableProductMachine = new DataTable();
            DataTableProductMachine.Columns.Add("Naziv proizvoda");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTableProductMachine.Clear();
            dgvTableProductMachine.DataSource = null;

            CmbTypeOfRevenue.SelectedIndex = 0;
            BtnAddProductNetIncome.Enabled = false;
        }

        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            AddMachine addMachine = new AddMachine();
            addMachine.ShowDialog();
            RefreshTable();
        }

        private void RefreshTable()
        {
            dgvTableProductMachine.DataSource = null;
            RefreshTableRows();
            dgvTableProductMachine.DataSource = DataTableProductMachine;
        }

        private void RefreshTableRows()
        {
            foreach (var item in ProductMachine.machines)
            {
                if (DataTableProductMachine.Columns.Contains(item.ToString()) == false)
                {
                    DataTableProductMachine.Columns.Add(item.ToString());
                }
            }
        }

        private void BtnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dgvTableProductMachine.CurrentCell == null) {
                MessageBox.Show("Niste odabrali stupac", "Error");
                return;
            }

            int columnIndex = dgvTableProductMachine.CurrentCell.ColumnIndex;
            string columnName = dgvTableProductMachine.Columns[columnIndex].Name;

            if (columnName == "Naziv proizvoda")
            {
                MessageBox.Show("Navedeni stupac se ne može izbrisati", "Error");
                return;
            }

            ProductMachine.RemoveMachineFromList(columnName);

            DataTableProductMachine.Columns.RemoveAt(columnIndex);
            RefreshTable();
        }

        private void BtnAddMachineCapacityAndLimitation_Click(object sender, EventArgs e)
        {
            if (DataTableProductMachine.Rows.Count <= 1)
            {
                if (DataTableProductMachine.Columns.Contains("Kapacitet"))
                {
                    MessageBox.Show("Već ste unijeli Kapacitet", "Error");
                    return;
                }

                MessageBox.Show("Unijeli ste premalo proizvoda", "Error");
                return;
            }

            DataTableProductMachine.Rows.Add("Kapacitet");
            DataTableProductMachine.Rows.Add("Ograničenje");
            RefreshTable();

            //Disable buttons and dgv
            dgvTableProductMachine.AllowUserToAddRows = false;
            BtnAddMachineCapacityAndLimitation.Enabled = false;
            BtnAddProductNetIncome.Enabled = true;
        }

        private void BtnAddProductNetIncome_Click(object sender, EventArgs e)
        {
            if (DataTableProductMachine.Columns.Count <= 1)
            {
                if (DataTableProductMachine.Columns.Contains("Neto Prihod"))
                {
                    MessageBox.Show("Već ste unijeli Neto prihod", "Error");
                    return;
                }

                MessageBox.Show("Unijeli ste premalo radne snage", "Error");
                return;
            }

            DataTableProductMachine.Columns.Add("Neto Prihod");
            RefreshTableRows();

            //Disable\enable buttons
            BtnAddMachine.Enabled = false;
            BtnAddProductNetIncome.Enabled = false;
            BtnDeleteColumn.Enabled = false;
            BtnAddMachineCapacityAndLimitation.Enabled = false;
        }

        private void GetDataFromDataTable()
        {
            foreach (DataRow row in DataTableProductMachine.Rows)
            {
                List<string> ListInt = new List<string>();
                string productName = row.ItemArray[0].ToString();
                string netIncome = row.ItemArray.Last().ToString();
                for (int i = 1; i < row.ItemArray.Length - 1; i++)
                {
                    ListInt.Add(row.ItemArray[i].ToString());
                    /*if (int.TryParse(row.ItemArray[i].ToString(), out int result))
                    {
                        ListInt.Add(result);
                    }
                    else
                    {
                        MessageBox.Show("Jedan od unos nije tip int", "Error");
                        return;
                    }*/
                }
                productMachine.AddProduct(productName, ListInt, netIncome);
            }
        }

        private void BtnOriginalMethod_Click(object sender, EventArgs e)
        {
            if (!productMachine.products.Any())
            {
                GetDataFromDataTable();
            }

            if (CmbTypeOfRevenue.Text.Equals(""))
            {
                MessageBox.Show("Niste odabrali tip prihoda", "Error");
                return;
            }

            if (ProductMachine.originals.Count > 3)
            {
                MessageBox.Show("Nemožete napraviti originalni oblik Vam uneseni podaci nisu dobri", "Error");
                return;
            }

            BtnOriginalMethod.Enabled = false;
            BtnDualMethod.Enabled = true;
            btnPressed = 1;

            RtxtFormulaResult.Text = productMachine.SetDataForSelectedTypeOfForm(CmbTypeOfRevenue.Text);
        }

        private void BtnDualMethod_Click(object sender, EventArgs e)
        {
            if (!productMachine.products.Any())
            {
                GetDataFromDataTable();
            }

            if (CmbTypeOfRevenue.Text.Equals(""))
            {
                MessageBox.Show("Niste odabrali tip prihoda", "Error");
                return;
            }

            if (ProductMachine.duals.Count > 3)
            {
                MessageBox.Show("Nemožete napraviti dualni oblik Vam uneseni podaci nisu dobri", "Error");
                return;
            }

            BtnDualMethod.Enabled = false;
            BtnOriginalMethod.Enabled = true;
            btnPressed = 2;

            RtxtFormulaResult.Text = productMachine.GetStringForDualProblemForMax();
        }

        private void BtnLoadGraph_Click(object sender, EventArgs e)
        {
            //Ako nije odabran niti jedna metoda
            if (btnPressed == 0)
            {
                MessageBox.Show("Niste kliknuli na niti jednu metodu", "Error");
                return;
            }

            var chart = Chart.ChartAreas[0];

            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;

            //Ako želimo postaviti svoj defoult razmak između svakog intervala
            //chart.AxisX.Interval = 10;
            //chart.AxisY.Interval = 10;

            Chart.Series[0].IsVisibleInLegend = false;
            //TODO: Uzmi najvece rjesenje
            //Odabrana je originalna metoda
            if (btnPressed == 1)
            {
                //Ako postoji graf, izbrisi ga
                if (Chart.Series.Any())
                {
                    Chart.Series.Clear();
                }
                int counter = 1;
                //productMachine.SetDataForOriginalProblemInListOriginals();
                LinearSolver solver = new LinearSolver();
                foreach (List<int> item in ProductMachine.originals)
                {
                    if (item.Count != 2)
                    {
                        string lineName = "p" + counter;
                        Chart.Series.Add(lineName);
                        Chart.Series[lineName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        Chart.Series[lineName].Color = Color.Blue;
                        Chart.Series[lineName].BorderWidth = 2;

                        double axisX = solver.FindAxisX(counter);
                        double axisY = solver.FindAxisY(counter);

                        //TODO: Pitaj kako se rješava crtanje vertikalne linije na grafu
                        double avarageX = ProductMachine.originals.Average(r => r[1]) * 3;
                        double avarageY = ProductMachine.originals.Average(r => r[1]) * 3;

                        if (axisX == 0)
                        {
                            Chart.Series[lineName].Points.AddXY(0, axisY);
                            Chart.Series[lineName].Points.AddXY(avarageX, axisY);
                        }
                        else if (axisY == 0)
                        {
                            Chart.Series[lineName].Points.AddXY(axisX, 0);
                            Chart.Series[lineName].Points.AddXY(avarageY, axisX);
                        }
                        else
                        {
                            Chart.Series[lineName].Points.AddXY(axisX, 0);
                            Chart.Series[lineName].Points.AddXY(0, axisY);
                        }
                        
                        counter++;
                    }
                }

                List<double> goalFunctions = solver.FindGoalFunctionOriginals();
                //Ako je lista prazna znači da ne postoji funkciju cilja
                if (!goalFunctions.Any())
                {
                    MessageBox.Show("Nema funckije cilja", "Error");
                }
                else
                {
                    Chart.Series.Add("Funkcija Cilja");
                    Chart.Series["Funkcija Cilja"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart.Series["Funkcija Cilja"].Color = Color.Green;
                    Chart.Series["Funkcija Cilja"].BorderWidth = 2;

                    Chart.Series["Funkcija Cilja"].Points.AddXY(goalFunctions[0], 0);
                    Chart.Series["Funkcija Cilja"].Points.AddXY(0, goalFunctions[1]);

                    List<int> zs = ProductMachine.originals[0];
                    double z = zs[0]*goalFunctions[0] + zs[1]*goalFunctions[1];

                    RtxtFormulaResult.Text += "\n\nRezultat funckije cilja: \n";
                    RtxtFormulaResult.Text += "Z = " + zs[0] + " x " + goalFunctions[0] + " + " + zs[1] + " x " + goalFunctions[1] + " = " + z;
                    RtxtFormulaResult.Text += "\nM(" + goalFunctions[0] + ", "+ goalFunctions[1] + ")";
                }
            }
            //TODO: Uzmi najmanje rjesenje
            //Odabrana je dualna metoda
            else
            {
                //Ako postoji graf izbrisi ga
                if (Chart.Series.Any())
                {
                    Chart.Series.Clear();
                }
                int counter = 1;
                LinearSolver solver = new LinearSolver();
                foreach (List<int> item in ProductMachine.duals)
                {
                    if (item.Count != 2)
                    {
                        string lineName = "p" + counter;
                        Chart.Series.Add(lineName);
                        Chart.Series[lineName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        Chart.Series[lineName].Color = Color.Black;

                        Chart.Series[lineName].Points.AddXY(solver.FindAxisXDual(counter), 0);
                        Chart.Series[lineName].Points.AddXY(0, solver.FindAxisYDual(counter));

                        counter++;
                    }
                }

                List<double> goalFunctions = solver.FindGoalFunctionDuals();
                //Ako je lista prazna znači da ne postoji funkciju cilja
                if (!goalFunctions.Any())
                {
                    MessageBox.Show("Nema funckije cilja", "Error");
                }
                else
                {
                    Chart.Series.Add("Funkcija Cilja");
                    Chart.Series["Funkcija Cilja"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart.Series["Funkcija Cilja"].Color = Color.Green;

                    Chart.Series["Funkcija Cilja"].Points.AddXY(goalFunctions[0], 0);
                    Chart.Series["Funkcija Cilja"].Points.AddXY(0, goalFunctions[1]);

                    List<int> zs = ProductMachine.duals[0];
                    double z = goalFunctions[0] * zs[0] + goalFunctions[1] * zs[1];

                    RtxtFormulaResult.Text += "\n\nRezultat funckije cilja: \n";
                    RtxtFormulaResult.Text += "Z = " + goalFunctions[0] + " x " + zs[0] + " + " + goalFunctions[1] + " x " + zs[1] + " = " + z;
                    RtxtFormulaResult.Text += "\nM(" + goalFunctions[0] + ", " + goalFunctions[1] + ")";
                }
            }
        }
    }
}
