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

        private List<List<Double>> getNodes(DataGridView source)
        {
            List<List<Double>> result = new List<List<double>>();

            for (int i = 0; i < source.RowCount; i++)
            {
                List<Double> newItem = new List<double>();

                newItem.Add(Convert.ToDouble(source[i, 0].Value));
                newItem.Add(Convert.ToDouble(source[i, 1].Value));
                newItem.Add(Convert.ToDouble(source[i, 2].Value));
                newItem.Add(Convert.ToDouble(source[i, 3].Value));

                result.Add(newItem);
            }

            return result;
        }                       
        
        private List<List<Double>> getRoutes(DataGridView source)
        {
            List<List<Double>> result = new List<List<double>>();

            for (int i = 0; i < source.RowCount; i++)
            {
                List<Double> newItem = new List<double>();

                for (int j = 0; j < 10; j++)
                {
                    if (source[i, j].Value != null)
                        newItem.Add(Convert.ToDouble(source[i, j].Value));
                }

                result.Add(newItem);
            }

            return result;
        }
                                                                    
        private void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int Psub1 = (int)this.numericUpDown1.Value;
            int Psub2 = (int)this.numericUpDown2.Value;
            int Perr = (int)this.numericUpDown3.Value;
            int N = (int)this.numericUpDown4.Value;

            List<List<Double>> nodesSub1 = getNodes(dataGridView1);
            List<List<Double>> nodesSub2 = getNodes(dataGridView2);

            List<List<Double>> routesSub1 = getRoutes(dataGridView3);
            List<List<Double>> routesSub2 = getRoutes(dataGridView4);



            for (int i = 0; i < N; i++)
            {
                double probabilityTheme = rnd.NextDouble();
                int themeNumber = 1;

                if (probabilityTheme > Psub1)
                    themeNumber = 2;


            }
        }
    }
}
