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
    public partial class AddMachine : Form
    {
        public string NazivStroja { get; set; }
        public AddMachine()
        {
            InitializeComponent();
        }

        public void AddMachineToList()
        {
            if (TxtMachineName.Text == "")
            {
                MessageBox.Show("Niste unijeli naziv stroja", "Error");
            }
            else
            {
                ProductMachine proizvodStroj = new ProductMachine();
                Machine stroj = new Machine(TxtMachineName.Text);
                proizvodStroj.InputNewMachine(stroj);
                Close();
            }
        }

        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            AddMachineToList();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtMachineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMachineToList();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
