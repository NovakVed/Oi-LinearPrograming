using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingSolutionOI1
{
    class LinearSolver
    {
        public double FindAxisX(int index)
        {
            List<int> lists = ProductMachine.originals[index];
            double a = lists[2];
            double b = lists[0];

            //Ako je varijabla jednaka 0 vrati a
            if (a == 0 || b == 0)
            {
                return 0;
            }

            double result = a / b;
            return result;
        }

        public double FindAxisY(int index)
        {
            List<int> lists = ProductMachine.originals[index];
            double a = lists[2];
            double b = lists[1];

            if (a == 0 || b == 0)
            {
                return 0;
            }

            double result = a / b;
            return result;
        }

        public double FindAxisXDual(int index)
        {
            List<int> lists = ProductMachine.duals[index];
            double a = lists[2];
            double b = lists[0];

            if (a == 0 || b == 0)
            {
                return 0;
            }

            double result = a / b;
            return result;
        }

        public double FindAxisYDual(int index)
        {
            List<int> lists = ProductMachine.duals[index];
            double a = lists[2];
            double b = lists[1];

            if (a == 0 || b == 0)
            {
                return 0;
            }

            double result = a / b;
            return result;
        }

        public List<double> FindGoalFunctionOriginals()
        {
            List<double> results = new List<double>();
            double tempTemp = 0;
            foreach (var item in FindAllLine_LineIntersections_Originals())
            {
                if (CheckLimitations(item) == true)
                {
                    List<int> goalsListFunctions = ProductMachine.originals[0];
                    if (results.Any())
                    {
                        tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                    }
                    double temp = double.Parse(goalsListFunctions[0].ToString()) * item[0] + double.Parse(goalsListFunctions[1].ToString()) * item[1];
                    if (temp > tempTemp)
                    {
                        results.Clear();
                        results = item;
                    }
                }
            }

            int counter = 0;
            foreach (var item in ProductMachine.originals)
            {
                if (item.Count != 2)
                {
                    List<double> newListX = new List<double>();
                    newListX.Add(FindAxisX(counter));
                    newListX.Add(0);
                    List<double> newListY = new List<double>();
                    newListY.Add(0);
                    newListY.Add(FindAxisY(counter));
                    if (CheckLimitations(newListX) == true)
                    {
                        List<int> goalsListFunctions = ProductMachine.originals[0];
                        if (results.Any())
                        {
                            tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                        }
                        double temp = double.Parse(goalsListFunctions[0].ToString()) * newListX[0] + double.Parse(goalsListFunctions[1].ToString()) * newListX[1];
                        if (temp > tempTemp)
                        {
                            results.Clear();
                            results = newListX;
                        }
                    }
                    if (CheckLimitations(newListY) == true)
                    {
                        List<int> goalsListFunctions = ProductMachine.originals[0];
                        if (results.Any())
                        {
                            tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                        }
                        double temp = double.Parse(goalsListFunctions[0].ToString()) * newListY[0] + double.Parse(goalsListFunctions[1].ToString()) * newListY[1];
                        if (temp > tempTemp)
                        {
                            results.Clear();
                            results = newListX;
                        }
                    }
                }
                counter++;
            }

            return results;
        }

        public List<double> FindGoalFunctionDuals()
        {
            List<double> results = new List<double>();
            double tempTemp = 0;
            foreach (var item in FindAllLine_LineIntersections_Duals())
            {
                if (CheckLimitationsDuals(item) == true)
                {
                    List<int> goalsListFunctions = ProductMachine.duals[0];
                    if (results.Any())
                    {
                        tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                    }
                    double temp = double.Parse(goalsListFunctions[0].ToString()) * item[0] + double.Parse(goalsListFunctions[1].ToString()) * item[1];
                    if (tempTemp != 0)
                    {
                        if (temp < tempTemp)
                        {
                            results.Clear();
                            results = item;
                        }
                    }
                    else
                    {
                        results = item;
                    }
                }
            }

            int counter = 0;
            foreach (var item in ProductMachine.duals)
            {
                if (item.Count != 2)
                {
                    List<double> newListX = new List<double>();
                    newListX.Add(FindAxisXDual(counter));
                    newListX.Add(0);
                    List<double> newListY = new List<double>();
                    newListY.Add(0);
                    newListY.Add(FindAxisYDual(counter));
                    if (CheckLimitationsDuals(newListX) == true)
                    {
                        List<int> goalsListFunctions = ProductMachine.duals[0];
                        if (results.Any())
                        {
                            tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                        }
                        double temp = double.Parse(goalsListFunctions[0].ToString()) * newListX[0] + double.Parse(goalsListFunctions[1].ToString()) * newListX[1];
                        if (temp < tempTemp)
                        {
                            results.Clear();
                            results = newListX;
                        }
                    }
                    if (CheckLimitationsDuals(newListY) == true)
                    {
                        List<int> goalsListFunctions = ProductMachine.duals[0];
                        if (results.Any())
                        {
                            tempTemp = double.Parse(goalsListFunctions[0].ToString()) * results[0] + double.Parse(goalsListFunctions[1].ToString()) * results[1];
                        }
                        double temp = double.Parse(goalsListFunctions[0].ToString()) * newListY[0] + double.Parse(goalsListFunctions[1].ToString()) * newListY[1];
                        if (temp < tempTemp)
                        {
                            results.Clear();
                            results = newListY;
                        }
                    }
                }
                counter++;
            }
            return results;
        }

        //TOOD: ubaci točke sjecišta sa grafom
        public List<List<double>> FindAllLine_LineIntersections_Originals()
        {
            List<List<double>> linesIntersectionPoints = new List<List<double>>();
            foreach (var item in ProductMachine.originals)
            {
                int index = ProductMachine.originals.IndexOf(item);
                if (index != 0)
                {
                    int A1 = item[0];
                    int B1 = item[1];
                    int C1 = item[2];
                    foreach (var secondItem in ProductMachine.originals)
                    {
                        int secondIndex = ProductMachine.originals.IndexOf(secondItem);
                        if (secondIndex != 0 && secondIndex != index)
                        {
                            int A2 = secondItem[0];
                            int B2 = secondItem[1];
                            int C2 = secondItem[2];
                            double det = A1 * B2 - A2 * B1;
                            if (det == 0)
                            {
                                //Lines are parallel
                            }
                            else
                            {
                                double x = (B2 * C1 - B1 * C2) / det;
                                double y = (A1 * C2 - A2 * C1) / det;
                                if (x >= 0 || y >= 0)
                                {
                                    List<double> itemResults = new List<double>
                                    {
                                        x,
                                        y
                                    };

                                    if (ContainsList(linesIntersectionPoints, itemResults) == false)
                                    {
                                        linesIntersectionPoints.Add(itemResults);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return linesIntersectionPoints;
        }

        //Provjeri dali se ponavljaju elementi u listi (ako postoji lista unutar liste)
        public bool ContainsList(List<List<double>> listsLists, List<double> lists )
        {
            foreach (var item in listsLists)
            {
                if (lists.SequenceEqual(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckLimitations(List<double> linesIntersectionPoints)
        {
            List<int> goalsListFunctions = ProductMachine.originals[0];
            Product machineValuesForOriginal = ProductMachine.productsLinearSolver.Single(r => r.ProductName.Equals("Kapacitet"));
            Product limitationsProduct = ProductMachine.productsLinearSolver.Single(r => r.ProductName.Equals("Ograničenje"));
            int counter = 0;
            int counterInsideOriginals = 1;
            bool correct = false;
            foreach (var item in limitationsProduct.MachineValues)
            {
                if (item == "<=")
                {
                    double temp = double.Parse(ProductMachine.originals[counterInsideOriginals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.originals[counterInsideOriginals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp <= int.Parse(machineValuesForOriginal.MachineValues[counter]))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals(">="))
                {
                    double temp = double.Parse(ProductMachine.originals[counterInsideOriginals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.originals[counterInsideOriginals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp >= int.Parse(machineValuesForOriginal.MachineValues[counter]))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals("="))
                {
                    double temp = double.Parse(ProductMachine.originals[counterInsideOriginals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.originals[counterInsideOriginals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp == int.Parse(machineValuesForOriginal.MachineValues[counter]))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals(">"))
                {
                    double temp = double.Parse(ProductMachine.originals[counterInsideOriginals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.originals[counterInsideOriginals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp > int.Parse(machineValuesForOriginal.MachineValues[counter]))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals("<"))
                {
                    double temp = double.Parse(ProductMachine.originals[counterInsideOriginals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.originals[counterInsideOriginals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp < int.Parse(machineValuesForOriginal.MachineValues[counter]))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                counter++;
                counterInsideOriginals++;
            }
            return correct;
        }

        public List<List<double>> FindAllLine_LineIntersections_Duals()
        {
            List<List<double>> linesIntersectionPoints = new List<List<double>>();
            foreach (var item in ProductMachine.duals)
            {
                int index = ProductMachine.duals.IndexOf(item);
                if (index != 0)
                {
                    int A1 = item[0];
                    int B1 = item[1];
                    int C1 = item[2];
                    foreach (var secondItem in ProductMachine.duals)
                    {
                        int secondIndex = ProductMachine.duals.IndexOf(secondItem);
                        if (secondIndex != 0 && secondIndex != index)
                        {
                            int A2 = secondItem[0];
                            int B2 = secondItem[1];
                            int C2 = secondItem[2];
                            double det = A1 * B2 - A2 * B1;
                            if (det == 0)
                            {
                                //Lines are parallel
                            }
                            else
                            {
                                double x = (B2 * C1 - B1 * C2) / det;
                                double y = (A1 * C2 - A2 * C1) / det;
                                if (x >= 0 || y >= 0)
                                {
                                    List<double> itemResults = new List<double>
                                    {
                                        x,
                                        y
                                    };

                                    if (ContainsList(linesIntersectionPoints, itemResults) == false)
                                    {
                                        linesIntersectionPoints.Add(itemResults);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return linesIntersectionPoints;
        }

        public bool CheckLimitationsDuals(List<double> linesIntersectionPoints)
        {
            List<int> goalsListFunctions = ProductMachine.duals[0];
            Product machineValuesForDuals = ProductMachine.productsLinearSolver.Single(r => r.ProductName.Equals("Kapacitet"));
            Product limitationsProduct = ProductMachine.productsLinearSolver.Single(r => r.ProductName.Equals("Ograničenje"));
            int counter = 0;
            int counterInsideDuals = 1;
            bool correct = false;
            foreach (var item in limitationsProduct.MachineValues)
            {
                if (item == "<=")
                {
                    double temp = double.Parse(ProductMachine.duals[counterInsideDuals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.duals[counterInsideDuals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp >= double.Parse(ProductMachine.duals[counterInsideDuals][2].ToString()))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals(">="))
                {
                    double temp = double.Parse(ProductMachine.duals[counterInsideDuals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.duals[counterInsideDuals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp <= double.Parse(ProductMachine.duals[counterInsideDuals][2].ToString()))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals("="))
                {
                    double temp = double.Parse(ProductMachine.duals[counterInsideDuals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.duals[counterInsideDuals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp == double.Parse(ProductMachine.duals[counterInsideDuals][2].ToString()))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals(">"))
                {
                    double temp = double.Parse(ProductMachine.duals[counterInsideDuals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.duals[counterInsideDuals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp < double.Parse(ProductMachine.duals[counterInsideDuals][2].ToString()))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item.Equals("<"))
                {
                    double temp = double.Parse(ProductMachine.duals[counterInsideDuals][0].ToString()) * linesIntersectionPoints[0] + double.Parse(ProductMachine.duals[counterInsideDuals][1].ToString()) * linesIntersectionPoints[1];
                    if (temp > double.Parse(ProductMachine.duals[counterInsideDuals][2].ToString()))
                    {
                        correct = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                counter++;
                counterInsideDuals++;
            }
            return correct;
        }
    }
}
