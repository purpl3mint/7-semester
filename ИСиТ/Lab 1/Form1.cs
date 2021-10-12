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

            dataGridView1.Rows.Add(1, 10, 11);
            dataGridView1.Rows.Add("0,5", 9, 12);
            dataGridView1.Rows.Add("0,3", 7, 14);
            dataGridView1.Rows.Add(0, 0, 21);

            dataGridView2.Rows.Add(1, 8, 10);
            dataGridView2.Rows.Add("0,5", 6, 12);
            dataGridView2.Rows.Add(0, 1, 17);


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
            Level currentLevelA;
            Level currentLevelB;

            while (currentItemA < valuesA.Count && currentItemB < valuesB.Count)
            {
                if (valuesA[currentItemA].alpha < valuesB[currentItemB].alpha)
                {
                    currentLevelA = valuesA[currentItemA++];
                    currentLevelB = Level.getLevelByAlpha(
                        valuesB[currentItemB - 1],
                        valuesB[currentItemB],
                        valuesA[currentItemA - 1].alpha);

                }
                else if (valuesA[currentItemA].alpha > valuesB[currentItemB].alpha)
                {
                    currentLevelB = valuesB[currentItemB++];
                    currentLevelA = Level.getLevelByAlpha(
                        valuesA[currentItemA - 1],
                        valuesA[currentItemA],
                        valuesB[currentItemB - 1].alpha);
                }
                else
                {
                    currentLevelA = valuesA[currentItemA++];
                    currentLevelB = valuesB[currentItemB++];
                }

                switch (operation)
                {
                    case '+':
                        valuesC.Add(currentLevelA + currentLevelB);
                        break;
                    case '-':
                        valuesC.Add(currentLevelA - currentLevelB);
                        break;
                    case '*':
                        valuesC.Add(currentLevelA * currentLevelB);
                        break;
                    case '/':
                        valuesC.Add(currentLevelA / currentLevelB);
                        break;
                }
            }
            /*
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
            */

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

        private void drawChart(string valuesName, DataGridView data)
        {
            string seriesName = "Chart" + valuesName;
            chart1.Series["Chart" + valuesName].Points.Clear();

            List<Level> values = getValues(data);
            values = sortValues(values);

            if (!verifyValues(values, valuesName))
                return;

            for (int i = values.Count - 1; i >= 0; i--)
                chart1.Series[seriesName].Points.AddXY(values[i].low, values[i].alpha);

            for (int i = 0; i < values.Count; i++)
                chart1.Series[seriesName].Points.AddXY(values[i].high, values[i].alpha);
        }

        private void errorHandler(string valuesName)
        {
            string errorMessageBoxTitle = "Ошибка";
            string message = "Некорректное множество " + valuesName;

            MessageBox.Show(message, errorMessageBoxTitle, MessageBoxButtons.OK);
        }

        private bool verifyValues(List<Level> values, string valuesName)
        {
            bool result = true;

            for (int i = 0; i < values.Count - 1; i++)
            {
                if (values[i].alpha < 0 || values[i].alpha > 1 ||   //check alpha levels
                    values[i].alpha == values[i + 1].alpha ||       //check unequality diff alpha values
                    values[i].low > values[i].low ||                //check increasing diff left parts
                    values[i].high < values[i].high)                //check decreasing diff right parts
                {
                    result = false;
                }
            }

            if (result == false)
                errorHandler(valuesName);

            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            if (!verifyValues(valuesA, "A"))
                return;

            if (!verifyValues(valuesB, "B"))
                return;

            List<Level> valuesC = operationValues(valuesA, valuesB, '+');

            showValues(valuesC, dataGridView3);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            if (!verifyValues(valuesA, "A"))
                return;

            if (!verifyValues(valuesB, "B"))
                return;

            List<Level> valuesC = operationValues(valuesA, valuesB, '-');

            showValues(valuesC, dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            if (!verifyValues(valuesA, "A"))
                return;

            if (!verifyValues(valuesB, "B"))
                return;

            List<Level> valuesC = operationValues(valuesA, valuesB, '*');

            showValues(valuesC, dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            if (!verifyValues(valuesA, "A"))
                return;

            if (!verifyValues(valuesB, "B"))
                return;

            List<Level> valuesC = operationValues(valuesA, valuesB, '/');

            showValues(valuesC, dataGridView3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Level> valuesA = getValues(dataGridView1);
            List<Level> valuesB = getValues(dataGridView2);

            valuesA = sortValues(valuesA);
            valuesB = sortValues(valuesB);

            if (!verifyValues(valuesA, "A"))
                return;

            if (!verifyValues(valuesB, "B"))
                return;

            int comparisonResult = compareValues(valuesA, valuesB);

            switch (comparisonResult)
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
            drawChart("A", dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawChart("B", dataGridView2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            drawChart("C", dataGridView3);
        }
    }
}
