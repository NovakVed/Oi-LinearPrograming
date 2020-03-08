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
            double result = a / b;
            return result;
        }

        public double FindAxisY(int index)
        {
            List<int> lists = ProductMachine.originals[index];
            double a = lists[2];
            double b = lists[1];
            double result = a / b;
            return result;
        }

        public double FindAxisXDual(int index)
        {
            List<int> lists = ProductMachine.duals[index];
            double a = lists[2];
            double b = lists[0];
            double result = a / b;
            return result;
        }

        public double FindAxisYDual(int index)
        {
            List<int> lists = ProductMachine.duals[index];
            double a = lists[2];
            double b = lists[1];
            double result = a / b;
            return result;
        }

        public List<double> FindGoalFunctionOriginals()
        {
            List<double> results = FindAllLine_LineIntersections_Originals();

            return results;
        }

        public List<double> FindGoalFunctionDuals()
        {
            List<double> results = FindAllLine_LineIntersections_Duals();

            return results;
        }

        public List<double> FindAllLine_LineIntersections_Originals()
        {
            List<double> results = new List<double>();
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
                                    if (results.Contains(x) == false && results.Contains(y) == false)
                                    {
                                        results.Add(x);
                                        results.Add(y);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }

        public List<double> FindAllLine_LineIntersections_Duals()
        {
            List<double> results = new List<double>();
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
                                    if (results.Contains(x) == false && results.Contains(y) == false)
                                    {
                                        results.Add(x);
                                        results.Add(y);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }
    }
}
