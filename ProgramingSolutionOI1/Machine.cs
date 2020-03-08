using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingSolutionOI1
{
    class Machine
    {
        public string MachineName { get; set; }

        public Machine(string machineName)
        {
            MachineName = machineName;
        }

        public override string ToString()
        {
            return MachineName;
        }
    }
}
