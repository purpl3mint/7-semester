using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double densityRejection = Convert.ToDouble(numericUpDown1.Value);
            double densityDelay = Convert.ToDouble(numericUpDown2.Value);
            double densityOrders = Convert.ToDouble(numericUpDown3.Value);
            int numberOfIterations = Convert.ToInt32(numericUpDown4.Value);
            double densityExecution = Convert.ToDouble(numericUpDown5.Value);
            double densityRecovery = Convert.ToDouble(numericUpDown6.Value);
            //Using instead densityRecovery
            double tRecovery = 10;

            double ordersTotal = 0;
            double ordersProcessed = 0;
            double quality = 0;

            double tOrdersCurrent = 0;
            double tExecutionCurrent = 0;
            double tRejection = 0;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            for (; ; )
            {
                if (tRejection != 0) tRejection += tRecovery;
                if (tOrdersCurrent != 0) tOrdersCurrent = tRejection;

                tRejection = tRejection + (-1 / densityRejection) * Math.Log(rnd.NextDouble());

                dataGridView2.Rows.Add(tRejection.ToString(), tRecovery.ToString());
                dataGridView2.Rows[dataGridView2.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightPink;

                while (tOrdersCurrent < tRejection)
                {
                    if (ordersTotal >= numberOfIterations)
                    {
                        break;
                    }
                    double tDelay = (-1 / densityDelay) * Math.Log(rnd.NextDouble());
                    double tOrder = (-1 / densityOrders) * Math.Log(rnd.NextDouble());
                    double tExecution = (-1 / densityExecution) * Math.Log(rnd.NextDouble()) + tDelay;

                    tOrdersCurrent += tOrder;

                    if (tExecutionCurrent < tOrdersCurrent)
                    {
                        tExecutionCurrent = tOrdersCurrent;
                    }

                    if (tExecutionCurrent < tRejection)
                    {
                        tExecutionCurrent += tExecution;
                    }
                    dataGridView1.Rows.Add(tOrdersCurrent.ToString(), tExecutionCurrent.ToString(), tExecution.ToString());

                    
                    if (tExecutionCurrent < tRejection)
                    {
                        
                    } else
                    {
                        
                    }
                    

                    if (tOrdersCurrent < tRejection && tExecutionCurrent < tRejection)
                    {
                        ordersProcessed += 1;
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    } else
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    ordersTotal += 1;
                }

                if (ordersTotal >= numberOfIterations)
                {
                    break;
                }

                tOrdersCurrent = tRejection + tRecovery;
                tExecutionCurrent = tOrdersCurrent;
            }

            quality = ordersProcessed / ordersTotal;

            textBox4.Text = ordersTotal.ToString();
            textBox5.Text = ordersProcessed.ToString();
            textBox6.Text = quality.ToString();
        }
    }
}
