using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].LegendText = "Измерения времени";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";

            //1
            //dataGridView1.Rows.Add(1, 2, 1);
            //dataGridView1.Rows.Add(2, 4, 2);
            //dataGridView1.Rows.Add(4, 5, 3);
            //dataGridView1.Rows.Add(4, 6, 4);
            //dataGridView1.Rows.Add(6, 7, 5);
            //dataGridView1.Rows.Add(1, 3, 6);
            //dataGridView1.Rows.Add(3, 8, 7);
            //dataGridView1.Rows.Add(8, 9, 8);
            //dataGridView1.Rows.Add(9, 10, 9);
            //dataGridView1.Rows.Add(10, 11, 10);
            //dataGridView1.Rows.Add(10, 12, 11);

            //dataGridView2.Rows.Add(1, 2, 1);
            //dataGridView2.Rows.Add(2, 3, 2);
            //dataGridView2.Rows.Add(3, 4, 3);
            //dataGridView2.Rows.Add(4, 7, 4);
            //dataGridView2.Rows.Add(3, 5, 5);
            //dataGridView2.Rows.Add(5, 9, 6);
            //dataGridView2.Rows.Add(4, 6, 7);
            //dataGridView2.Rows.Add(6, 10, 8);
            //dataGridView2.Rows.Add(5, 8, 9);
            //dataGridView2.Rows.Add(8, 18, 10);
            //dataGridView2.Rows.Add(8, 15, 11);
            //dataGridView2.Rows.Add(15, 17, 12);
            //dataGridView2.Rows.Add(3, 10, 13);
            //dataGridView2.Rows.Add(10, 11, 14);
            //dataGridView2.Rows.Add(11, 12, 15);
            //dataGridView2.Rows.Add(12, 13, 16);
            //dataGridView2.Rows.Add(12, 14, 17);


            //dataGridView3.Rows.Add(0.25, 1, 2, 4, 5);
            //dataGridView3.Rows.Add(0.25, 1, 2, 4, 6, 7);
            //dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 11);
            //dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 12);

            //dataGridView4.Rows.Add(0.4, 1, 2, 3, 4, 7);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 5, 9);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 4, 6, 10);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 5, 8, 18);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 5, 8, 15, 17);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 10, 11, 12, 13);
            //dataGridView4.Rows.Add(0.1, 1, 2, 3, 10, 11, 12, 14);
            //1
            
            //2
            //dataGridView1.Rows.Add(1, 2, 23);
            //dataGridView1.Rows.Add(2, 4, 42);
            //dataGridView1.Rows.Add(4, 5, 20);
            //dataGridView1.Rows.Add(4, 6, 36);
            //dataGridView1.Rows.Add(6, 7, 20);
            //dataGridView1.Rows.Add(1, 3, 11);
            //dataGridView1.Rows.Add(3, 8, 6);
            //dataGridView1.Rows.Add(8, 9, 123);
            //dataGridView1.Rows.Add(9, 10, 2);
            //dataGridView1.Rows.Add(10, 11, 1);
            //dataGridView1.Rows.Add(10, 12, 3);

            //dataGridView2.Rows.Add(1, 2, 13);
            //dataGridView2.Rows.Add(2, 4, 12);
            //dataGridView2.Rows.Add(4, 5, 11);
            //dataGridView2.Rows.Add(4, 6, 5);
            //dataGridView2.Rows.Add(6, 7, 1);
            //dataGridView2.Rows.Add(1, 3, 2);
            //dataGridView2.Rows.Add(3, 8, 6);
            //dataGridView2.Rows.Add(8, 9, 6);
            //dataGridView2.Rows.Add(9, 10, 41);
            //dataGridView2.Rows.Add(10, 11, 3);
            //dataGridView2.Rows.Add(10, 12, 5);


            //dataGridView3.Rows.Add(0.25, 1, 2, 4, 5);
            //dataGridView3.Rows.Add(0.25, 1, 2, 4, 6, 7);
            //dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 11);
            //dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 12);

            //dataGridView4.Rows.Add(0.25, 1, 2, 4, 5);
            //dataGridView4.Rows.Add(0.25, 1, 2, 4, 6, 7);
            //dataGridView4.Rows.Add(0.25, 1, 3, 8, 9, 10, 11);
            //dataGridView4.Rows.Add(0.25, 1, 3, 8, 9, 10, 12);
            //2
            
            //3
            dataGridView1.Rows.Add(1, 2, 23);
            dataGridView1.Rows.Add(2, 4, 42);
            dataGridView1.Rows.Add(4, 5, 20);
            dataGridView1.Rows.Add(4, 6, 36);
            dataGridView1.Rows.Add(6, 7, 20);
            dataGridView1.Rows.Add(1, 3, 11);
            dataGridView1.Rows.Add(3, 8, 6);
            dataGridView1.Rows.Add(8, 9, 123);
            dataGridView1.Rows.Add(9, 10, 2);
            dataGridView1.Rows.Add(10, 11, 1);
            dataGridView1.Rows.Add(10, 12, 3);

            dataGridView2.Rows.Add(1, 2, 13);
            dataGridView2.Rows.Add(2, 4, 12);
            dataGridView2.Rows.Add(4, 5, 11);
            dataGridView2.Rows.Add(4, 6, 5);
            dataGridView2.Rows.Add(6, 7, 1);
            dataGridView2.Rows.Add(1, 3, 2);
            dataGridView2.Rows.Add(3, 8, 6);
            dataGridView2.Rows.Add(8, 9, 6);
            dataGridView2.Rows.Add(9, 10, 41);
            dataGridView2.Rows.Add(10, 11, 3);
            dataGridView2.Rows.Add(10, 12, 5);


            dataGridView3.Rows.Add(0.25, 1, 2, 4, 5);
            dataGridView3.Rows.Add(0.25, 1, 2, 4, 6, 7);
            dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 11);
            dataGridView3.Rows.Add(0.25, 1, 3, 8, 9, 10, 12);

            dataGridView4.Rows.Add(0.25, 1, 2, 4, 5);
            dataGridView4.Rows.Add(0.25, 1, 2, 4, 6, 7);
            dataGridView4.Rows.Add(0.25, 1, 3, 8, 9, 10, 11);
            dataGridView4.Rows.Add(0.25, 1, 3, 8, 9, 10, 12);
            //3
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

            for (int i = 0; i < source.RowCount - 1; i++)
            {
                List<Double> newItem = new List<double>();

                newItem.Add(Convert.ToDouble(source[0, i].Value));
                newItem.Add(Convert.ToDouble(source[1, i].Value));
                newItem.Add(Convert.ToDouble(source[2, i].Value));

                result.Add(newItem);
            }

            return result;
        }                       
        
        private List<List<Double>> getRoutes(DataGridView source)
        {
            List<List<Double>> result = new List<List<double>>();

            for (int i = 0; i < source.RowCount - 1; i++)
            {
                List<Double> newItem = new List<double>();

                for (int j = 0; j < 10; j++)
                {
                    newItem.Add(Convert.ToDouble(source[j, i].Value));
                }

                result.Add(newItem);
            }

            return result;
        }

        private int chooseTheme(Random rnd, double Psub1)
        {
            int result = 1;
            double probabilityTheme = rnd.NextDouble();

            if (probabilityTheme > Psub1)
                result = 2;

            return result;
        }

        private int chooseRoute(Random rnd, List<List<double>> routes)
        {
            double probability = rnd.NextDouble();
            double currProbability = 0;
            int counter = -1;

            do
            {
                currProbability += routes[++counter][0];
            } while (currProbability < probability);

            return counter;
        }

        private double findTime(List<List<Double>> nodes, double nodeStart, double nodeEnd)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i][0] == nodeStart && nodes[i][1] == nodeEnd)
                    return nodes[i][2];
            }

            return 0;
        }

        private double makeExperiment(Random rnd, 
            double Perr, 
            List<List<Double>> nodes, 
            List<List<Double>> routes)
        {
            int routeNumber = chooseRoute(rnd, routes);
            int counter = 0;
            double time = 0;

            do
            {
                double errorProbability = rnd.NextDouble();
                if (errorProbability < Perr && counter > 0)
                {
                    counter--;
                    continue;
                }

                time += findTime(nodes,
                                routes[routeNumber][counter],
                                routes[routeNumber][counter + 1]);

                counter++;
            } while (counter < 9 && routes[routeNumber][counter] > 0);

            return time;
        }
                                                                    
        private void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            double Psub1 = (int)this.numericUpDown1.Value / 100.0;
            double Psub2 = (int)this.numericUpDown2.Value / 100.0;
            double Perr = (int)this.numericUpDown3.Value / 100.0;
            int N = (int)this.numericUpDown4.Value;

            List<List<Double>> nodesSub1 = getNodes(dataGridView1);
            List<List<Double>> nodesSub2 = getNodes(dataGridView2);

            List<List<Double>> routesSub1 = getRoutes(dataGridView3);
            List<List<Double>> routesSub2 = getRoutes(dataGridView4);

            List<Double> measuringTime = new List<double>();
            List<int> themeNumberTime = new List<int>();
            
            for (int i = 0; i < N; i++)
            {
                int themeNumber = chooseTheme(rnd, Psub1);

                if (themeNumber == 1)
                {
                    double time = makeExperiment(rnd, Perr, nodesSub1, routesSub1);
                    measuringTime.Add(time);
                    themeNumberTime.Add(1);
                } else
                {
                    double time = makeExperiment(rnd, Perr, nodesSub2, routesSub2);
                    measuringTime.Add(time);
                    themeNumberTime.Add(2);
                }
            }

            int K = (int)Math.Floor(1 + 3.22 * Math.Log10(N));
            List<int> gistData = new List<int>();
            double minTime = measuringTime.Min();
            double maxTime = measuringTime.Max() + 1;
            double step = (maxTime - minTime) / K;

            for (int i = 0; i < K; i++)
            {
                gistData.Add(0);
            }

            for (int i = 0; i < N; i++)
            {
                int column = (int)Math.Floor((measuringTime[i] - minTime) / step);
                gistData[column]++;
            }

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < K; i++)
            {
                chart1.Series[0].Points.AddXY(minTime + step * i, gistData[i]);
            }

            double avgTime1 = 0, avgTime2 = 0, avgTotal = 0;
            int times1 = 0, times2 = 0;
            for (int i = 0; i < N; i++)
            {
                switch (themeNumberTime[i])
                {
                    case 1:
                        if (avgTime1 == 0)
                            avgTime1 = measuringTime[i];
                        else
                            avgTime1 += measuringTime[i];
                        times1++;
                        break;
                    case 2:
                        if (avgTime2 == 0)
                            avgTime2 = measuringTime[i];
                        else
                            avgTime2 += measuringTime[i];
                        times2++;
                        break;
                }

            }

            avgTotal = (avgTime1 + avgTime2) / N;
            avgTime1 /= times1;
            avgTime2 /= times2;

            textBox1.Text = Convert.ToString(avgTime1);
            textBox2.Text = Convert.ToString(avgTime2);
            textBox3.Text = Convert.ToString(avgTotal);
        }

    }
}
