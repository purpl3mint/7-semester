using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Rows.Add(1, 3, 4);
            dataGridView1.Rows.Add("0,5", 2, 5);
            dataGridView1.Rows.Add(0, 1, 6);

            dataGridView2.Rows.Add(1, 9, 10);
            dataGridView2.Rows.Add("0,5", 8, 11);
            dataGridView2.Rows.Add(0, 7, 12);
        }

        private List<Level> getValues (DataGridView dataTable)
        {
            List<Level> values = new List<Level>() { };

            for (int i = 0; i < dataTable.RowCount - 1 ; i++)
            {
                Level newItem = new Level(Convert.ToDouble(dataTable[0, i].Value), Convert.ToDouble(dataTable[1, i].Value), Convert.ToDouble(dataTable[2, i].Value));
                values.Add(newItem);
            }

            return values;
        }

        private List<Level> sortValues (List<Level> source)
        {
            var sortValuesA = from v in source
                              orderby v.alpha
                              select v;

            List<Level> sortedValues = new List<Level>() { };
            foreach (Level l in sortValuesA)
            {
                sortedValues.Add(l);
            }

            return sortedValues;
        }

        private void showValues(List<Level> values, DataGridView table)
        {
            table.Rows.Clear();

            foreach (Level l in values)
            {
                table.Rows.Add(l.alpha, l.low, l.high);
            }
        }

        private List<Level> actionValues(List<Level> valuesA, List<Level> valuesB, char operation)
        {
            int currentItemA = 0;
            int currentItemB = 0;
            List<Level> valuesC = new List<Level>() { };

            while (currentItemA < valuesA.Count && currentItemB < valuesB.Count)
            {
                if (valuesA[currentItemA].alpha < valuesA[currentItemB].alpha
                    || currentItemB == valuesB.Count)
                {
                    valuesC.Add(valuesA[currentItemA++]);
                }
                else if (valuesA[currentItemA].alpha > valuesA[currentItemB].alpha
                        || currentItemA == valuesA.Count)
                {
                    valuesC.Add(valuesB[currentItemB++]);
                }
                else
                {
                    switch (operation)
                    {
                        case '+': 
                            valuesC.Add(valuesA[currentItemA++] + valuesB[currentItemB++]);
                            break;
                        case '-':
                            valuesC.Add(valuesA[currentItemA++] - valuesB[currentItemB++]);
                            break;
                        case '*':
                            valuesC.Add(valuesA[currentItemA++] * valuesB[currentItemB++]);
                            break;
                        case '/':
                            valuesC.Add(valuesA[currentItemA++] / valuesB[currentItemB++]);
                            break;
                    }
                }
            }

            return valuesC;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = actionValues(valuesA, valuesB, '+');

            showValues(valuesC, dataGridView3);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = actionValues(valuesA, valuesB, '-');

            showValues(valuesC, dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = actionValues(valuesA, valuesB, '*');

            showValues(valuesC, dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = actionValues(valuesA, valuesB, '/');

            showValues(valuesC, dataGridView3);
        }
    }
}
