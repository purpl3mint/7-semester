using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown2.Value = 100 - this.numericUpDown1.Value;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = 100 - this.numericUpDown2.Value;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int Psub1 = (int)this.numericUpDown1.Value;
            int Psub2 = (int)this.numericUpDown2.Value;
            int Perr = (int)this.numericUpDown3.Value;
            int N = (int)this.numericUpDown4.Value;

            List<List<int>> nodesSub1 = new List<List<int>>();
            List<List<int>> nodesSub2 = new List<List<int>>();
            List<List<int>> routesSub1 = new List<List<int>>();
            List<List<int>> routesSub2 = new List<List<int>>();


        }
    }
}
