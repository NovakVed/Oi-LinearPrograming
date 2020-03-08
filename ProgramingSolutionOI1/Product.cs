using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingSolutionOI1
{
    class Product
    {
        public string ProductName { get; set; }
        public List<int> MachineValues { get; set; }
        //TODO change NetIncome to int
        public string NetIncome { get; set; }
        public Product(string productName, List<int> values, string netIncome)
        {
            ProductName = productName;
            MachineValues = values;
            NetIncome = netIncome;
        }
    }
}
