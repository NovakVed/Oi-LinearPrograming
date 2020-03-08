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

        //test
        List<List<int>> listMaxs = new List<List<int>>();

        public void InputNewMachine(Machine machine)
        {
            machines.Add(machine);
        }

        public static void RemoveMachineFromList(string machineName)
        {
            Machine itemToRemove = machines.Single(r => r.MachineName.Equals(machineName));
            machines.Remove(itemToRemove);
        }

        public void AddProduct(string productName, List<int> MachinesValues, string netIncome)
        {
            Product product = new Product(productName, MachinesValues, netIncome);
            products.Add(product);
        }

        public void AddDataToCapacityValues()
        {
            Product machineValues = products.Single(r => r.ProductName.Equals("Kapacitet"));
            capacityValues = machineValues.MachineValues.ToList();
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
            string z = " Z = ";
            int counter = 1;

            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet"))
                {
                    z += " --> max \n";
                }
                else
                {
                    if (item.Equals(products.Last()))
                    {
                        z += item.NetIncome + "x" + counter;
                    }
                    else
                    {
                        z += item.NetIncome + "x" + counter + " + ";
                        counter++;
                    }
                }
            }

            counter = 1;

            
            //If list already exists then do nothing
            if (!listMaxs.Any())
            {
                foreach (Product item in products)
                {
                    if (item.ProductName.Equals("Kapacitet") == false)
                    {
                        listMaxs.Add(item.MachineValues);
                    }
                }
            }

            int indexer = 0;
            //TODO: Fix bug that works only if you have the same pair of products and machines
            for (int i = 0; i < products.Count - 1; i++)
            {
                foreach (List<int> item in listMaxs)
                {
                    if (indexer < listMaxs.Count)
                    {
                        z += item[indexer].ToString() + "x" + counter + " + ";
                        counter++;
                    }
                }
                z += " ≤ " + capacityValues[indexer] + "\n";
                indexer++;
                counter = 1;
            }

            //Ograničenja
            for (int i = 1; i <= capacityValues.Count; i++)
            {
                if (i == capacityValues.Count)
                {
                    z += "x" + i + " ≥ 0 -> uvjet nenegativnosti";
                }
                else
                {
                    z += "x" + i + ", ";
                }
            }

            return z;
        }

        public string GetStringForDualProblemForMax()
        {
            string z = " Z = ";

            int counter = 1;

            if (!capacityValues.Any())
            {
                AddDataToCapacityValues();
            }

            foreach (int machineValue in capacityValues)
            {
                if (counter == capacityValues.Count)
                {
                    z += machineValue + "y" + counter;
                    z += " --> min \n";
                }
                else
                {
                    z += machineValue + "y" + counter + " + ";
                    counter++;
                }
            }

            counter = 1;
            int capacityCounter = 1;

            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet") == false)
                {
                    foreach (int machineValueOfProduct in item.MachineValues)
                    {
                        if (machineValueOfProduct.Equals(item.MachineValues.Last()))
                        {
                            z += machineValueOfProduct + "y" + counter + " ≥ " + item.NetIncome + "\n";
                            counter = 1;
                        }
                        else
                        {
                            z += machineValueOfProduct + "y" + counter + " + ";
                            capacityCounter++;
                            counter++;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= item.MachineValues.Count; i++)
                    {
                        z += "y" + i + ", ";
                    }
                    z += " ≥ 0 -> uvjet nenegativnosti";
                }
            }

            return z;
        }

        public void SetDataForOriginalProblemInListOriginals()
        {
            //Funkcija cilja (Z = ) u prvom redu liste
            List<int> dataNetWorth = new List<int>();
            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet"))
                {
                    originals.Add(dataNetWorth);
                }
                else
                {
                    dataNetWorth.Add(int.Parse(item.NetIncome));
                }
            }

            //Postavljanje ostalih varijabla redom u listu
            Product machineValuesForOriginal = products.Single(r => r.ProductName.Equals("Kapacitet"));
            List<int> capacityValuesForOriginals = machineValuesForOriginal.MachineValues.ToList();

            int indexer = 0;
            for (int i = 0; i < products.Count - 1; i++)
            {
                List<int> temps = new List<int>();
                foreach (var item in products)
                {
                    if (item.ProductName.Equals("Kapacitet") == false)
                    {
                        if (indexer < item.MachineValues.Count)
                        {
                            temps.Add(item.MachineValues[indexer]);
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
            duals.Add(machineValuesForDual.MachineValues.ToList());

            //Postavljanje ostalih varijabla redom u listu
            foreach (Product item in products)
            {
                if (item.ProductName.Equals("Kapacitet"))
                {
                    return;
                }

                List<int> temps = new List<int>();
                foreach (int var in item.MachineValues)
                {
                    temps.Add(var);
                }
                temps.Add(int.Parse(item.NetIncome));
                duals.Add(temps);
            }
        }
    }
}
