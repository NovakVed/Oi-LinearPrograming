using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingSolutionOI1
{
    class ProductMachine
    {
        public static List<List<int>> originals = new List<List<int>>();
        public static List<List<int>> duals = new List<List<int>>();
        public static List<Machine> machines = new List<Machine>();
        public List<Product> products = new List<Product>();
        public List<int> capacityValues = new List<int>();

        public void InputNewMachine(Machine machine)
        {
            machines.Add(machine);
        }

        public static void RemoveMachineFromList(string machineName)
        {
            Machine itemToRemove = machines.Single(r => r.MachineName.Equals(machineName));
            machines.Remove(itemToRemove);
        }

        public void AddProduct(string productName, List<string> MachinesValues, string netIncome)
        {
            Product product = new Product(productName, MachinesValues, netIncome);
            products.Add(product);
        }

        public void AddDataToCapacityValues()
        {
            Product machineValues = products.Single(r => r.ProductName.Equals("Kapacitet"));
            capacityValues = machineValues.MachineValues.Select(int.Parse).ToList();
        }

        //TODO: Ubaci za problem min
        public string SetDataForSelectedTypeOfForm(string typeOfRevenue)
        {
            if (!capacityValues.Any())
            {
                AddDataToCapacityValues();
            }

            if (typeOfRevenue == "Maksimalni prihod")
            {
                return GetStringForOriginalProblemForMax();
            }
            else
            {
                return GetStringForDualProblemForMax();
            }
        }

        public string GetStringForOriginalProblemForMax()
        {
            //Izbrisi sve podatke iz liste originals
            originals.Clear();

            //Upiši podatke u liste originals
            SetDataForOriginalProblemInListOriginals();
            
            string z = " Z = ";
            int counter = 1;

            //Z = ... funkcija
            for (int i = 0; i < originals[0].Count - 1; i++)
            {
                z += originals[0][i] + "x" + counter + " + ";
                counter++;
            }
            z += originals[0][counter - 1] + "x" + counter + " --> max \n";

            //Ispis svih ograničenja
            foreach (var item in originals)
            {
                int index = originals.IndexOf(item);
                if (index != 0)
                {
                    int A = item[0];
                    int B = item[1];
                    int C = item[2];
                    z += A + "x1" + " + " + B + "x2" + " ≤ " + C + "\n";
                }
            }

            z += "x1,x2 ≥ 0 --> uvjet nenegativnosti";

            return z;
        }

        public string GetStringForDualProblemForMax()
        {
            //Izbrisi sve podatke iz liste originals
            duals.Clear();

            //Upiši podatke u liste duals
            SetDataForDualProblemInListDuals();
            string z = " Z = ";
            int counter = 1;

            //Z = ... funkcija
            for (int i = 0; i < duals[0].Count - 1; i++)
            {
                z += duals[0][i] + "y" + counter + " + ";
                counter++;
            }
            z += duals[0][counter - 1] + "y" + counter + " --> min \n";

            //Ispis svih ograničenja
            foreach (var item in duals)
            {
                int index = duals.IndexOf(item);
                if (index != 0)
                {
                    int A = item[0];
                    int B = item[1];
                    int C = item[2];
                    z += A + "y1" + " + " + B + "y2" + " ≥ " + C + "\n";
                }
            }

            z += "y1,y2 ≥ 0 --> uvjet nenegativnosti";

            return z;
        }

        public void SetDataForOriginalProblemInListOriginals()
        {
            //Funkcija cilja (Z = ) u prvom redu liste
            List<int> dataNetWorth = new List<int>();
            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet") || item.ProductName.Equals("Ograničenje"))
                {
                    originals.Add(dataNetWorth);
                    break;
                }
                else
                {
                    dataNetWorth.Add(int.Parse(item.NetIncome));
                }
            }

            //Postavljanje ostalih varijabla redom u listu
            Product machineValuesForOriginal = products.Single(r => r.ProductName.Equals("Kapacitet"));
            List<int> capacityValuesForOriginals = machineValuesForOriginal.MachineValues.Select(int.Parse).ToList();

            Product product = products[2];

            int indexer = 0;
            for (int i = 0; i < product.MachineValues.Count; i++)
            {
                List<int> temps = new List<int>();
                foreach (var item in products)
                {
                    if (item.ProductName.Equals("Kapacitet") == false && item.ProductName.Equals("Ograničenje") == false)
                    {
                        if (indexer < item.MachineValues.Count)
                        {
                            temps.Add(int.Parse(item.MachineValues[indexer]));
                        }
                    }
                }
                temps.Add(capacityValuesForOriginals[i]);
                originals.Add(temps);
                indexer++;
            }
        }
        
        public void SetDataForDualProblemInListDuals()
        {
            //Funkcija cilja (Z = ) u prvom redu liste
            Product machineValuesForDual = products.Single(r => r.ProductName.Equals("Kapacitet"));
            duals.Add(machineValuesForDual.MachineValues.Select(int.Parse).ToList());

            //Postavljanje ostalih varijabla redom u listu
            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet") || item.ProductName.Equals("Ograničenje"))
                {
                    return;
                }

                List<int> temps = new List<int>();
                foreach (int var in item.MachineValues.Select(int.Parse).ToList())
                {
                    temps.Add(var);
                }
                temps.Add(int.Parse(item.NetIncome));
                duals.Add(temps);
            }
        }
    }
}
