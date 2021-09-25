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


            chart1.Series.Clear();

            chart1.Series.Add("ChartA");
            chart1.Series.Add("ChartB");
            chart1.Series.Add("ChartC");

            chart1.Series["ChartA"].LegendText = "График А";
            chart1.Series["ChartB"].LegendText = "График B";
            chart1.Series["ChartC"].LegendText = "График C";

            chart1.Series["ChartA"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["ChartB"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["ChartC"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
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

        private List<Level> operationValues(List<Level> valuesA, List<Level> valuesB, char operation)
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

        private double summarizeAllLevels(List<Level> values)
        {
            double result = 0;
            int k = values.Count;

            foreach (Level level in values)
            {
                result += level.low + level.high;
            }
            result /= k;

            return result;
        }


        //valuesA = valuesB => result = 0
        //valuesA > valuesB => result = 1
        //valuesA < valuesB => result = -1
        private int compareValues(List<Level> valuesA, List<Level> valuesB)
        {
            double sumLevelsA = summarizeAllLevels(valuesA);
            double sumLevelsB = summarizeAllLevels(valuesB);

            if (sumLevelsA == sumLevelsB)
                return 0;
            else if (sumLevelsA > sumLevelsB)
                return 1;

            return -1;
        }

        private void drawChart(string seriesName, DataGridView data)
        {
            chart1.Series[seriesName].Points.Clear();

            List<Level> values = getValues(data);
            sortValues(values);

            for (int i = values.Count - 1; i >= 0; i--)
                chart1.Series[seriesName].Points.AddXY(values[i].low, values[i].alpha);

            for (int i = 0; i < values.Count; i++)
                chart1.Series[seriesName].Points.AddXY(values[i].high, values[i].alpha);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = operationValues(valuesA, valuesB, '+');

            showValues(valuesC, dataGridView3);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = operationValues(valuesA, valuesB, '-');

            showValues(valuesC, dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = operationValues(valuesA, valuesB, '*');

            showValues(valuesC, dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            List<Level> valuesC = operationValues(valuesA, valuesB, '/');

            showValues(valuesC, dataGridView3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            int comparisonResult = compareValues(valuesA, valuesB);

            switch(comparisonResult)
            {
                case -1:
                    button9.BackColor = Color.LightPink;
                    button10.BackColor = Color.LightPink;
                    button12.BackColor = Color.LightGreen;
                    button11.BackColor = Color.LightGreen;
                    button14.BackColor = Color.LightPink;
                    button13.BackColor = Color.LightGreen;
                    break;
                case 0:
                    button9.BackColor = Color.LightPink;
                    button10.BackColor = Color.LightGreen;
                    button12.BackColor = Color.LightPink;
                    button11.BackColor = Color.LightGreen;
                    button14.BackColor = Color.LightGreen;
                    button13.BackColor = Color.LightPink;
                    break;
                case 1:
                    button9.BackColor = Color.LightGreen;
                    button10.BackColor = Color.LightGreen;
                    button12.BackColor = Color.LightPink;
                    button11.BackColor = Color.LightPink;
                    button14.BackColor = Color.LightPink;
                    button13.BackColor = Color.LightGreen;
                    break;
                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawChart("ChartA", dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawChart("ChartB", dataGridView2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            drawChart("ChartC", dataGridView3);
        }
    }
}
