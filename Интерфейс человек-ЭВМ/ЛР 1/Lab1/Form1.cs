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

            dataGridView1.Rows.Add(1, 2, 10, 1);
            dataGridView2.Rows.Add(1, 2, 4, 1);
            dataGridView3.Rows.Add(1, 1, 2);
            dataGridView4.Rows.Add(1, 1, 2);
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
                newItem.Add(Convert.ToDouble(source[3, i].Value));

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
            
            for (int i = 0; i < N; i++)
            {
                int themeNumber = chooseTheme(rnd, Psub1);

                if (themeNumber == 1)
                {
                    double time = makeExperiment(rnd, Perr, nodesSub1, routesSub1);
                    measuringTime.Add(time);
                } else
                {
                    double time = makeExperiment(rnd, Perr, nodesSub2, routesSub2);
                    measuringTime.Add(time);
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
        }

    }
}
