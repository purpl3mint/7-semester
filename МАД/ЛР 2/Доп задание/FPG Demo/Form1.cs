using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPG_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowTransactions()
        {
            dataGridView2.Rows.Clear();
            foreach (Transaction transaction in Data.transactions)
            {
                dataGridView2.Rows.Add(transaction.id, transaction.value);
            }
        }

        private void GetRecords()
        {
            string[] lines = Data.fileContent.Split('\n');
            Data.records.Clear();

            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim('\r');

            foreach (string line in lines) 
            {
                string[] lineParts = line.Split(',');

                Data.records.Add(new Record(Convert.ToInt32(lineParts[0]), lineParts[1]));
            }

            Data.records.Sort(delegate (Record x, Record y)
            {
                if (x == null && y == null) return 0;
                else if (x == null) return -1;
                else if (y == null) return 1;
                else return x.id.CompareTo(y.id);
            });

            dataGridView1.Rows.Clear();
            foreach (Record record in Data.records)
            {
                dataGridView1.Rows.Add(record.id, record.value);
            }
        }

        private void GetTransactions()
        {
            string value = "";
            int currentId = 0;
            Data.transactions.Clear();

            foreach (Record record in Data.records)
            {
                if (value == "")
                {
                    currentId = record.id;
                    value += record.value + " ";
                }
                else if (currentId == record.id)
                {
                    value += record.value + " ";
                }
                else
                {
                    value = value.TrimEnd();
                    Data.transactions.Add(new Transaction(currentId, value));
                    value = record.value + " ";
                    currentId = record.id;
                }
            }

            if (value != "")
            {
                value = value.TrimEnd();
                Data.transactions.Add(new Transaction(currentId, value));
            }
        }

        private void GetOccurencies()
        {
            foreach(Record record in Data.records)
            {
                if (Data.occurencies.ContainsKey(record.value))
                {
                    Data.occurencies[record.value] += 1;
                }
                else
                {
                    Data.occurencies.Add(record.value, 1);
                }
            }

            Data.occurencies = Data.occurencies
                .OrderBy(pair => pair.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private void SortValuesInTransactions()
        {
            for (int i = 0; i < Data.transactions.Count; i++)
            {
                string currentString = Data.transactions[i].value;
                List<string> splittedString = new List<string>(currentString.Split(' '));

                splittedString.Sort(delegate (string x, string y)
                {
                    if (Data.occurencies[x] == Data.occurencies[y]) return 0;
                    else if (Data.occurencies[x] > Data.occurencies[y]) return -1;
                    else return 1;
                });

                Data.transactions[i].value = String.Join(" ", splittedString.ToArray());
            }
        }

        private void BuildGraph()
        {
            foreach(Transaction transaction in Data.transactions)
            {
                string currentValue = transaction.value;
                List<string> splittedValue = new List<string>(currentValue.Split(' '));

                Data.graph.AddTransaction(splittedValue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Data.filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        Data.fileContent = reader.ReadToEnd();
                    }
                }
            }

            if (Data.fileContent.Length > 0)
            {
                GetRecords();
            }

            if (Data.records.Count > 0)
            {
                GetTransactions();
                GetOccurencies();
                SortValuesInTransactions();
            }

            ShowTransactions();

            BuildGraph();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            progressBar2.Value = Convert.ToInt32(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            progressBar3.Value = Convert.ToInt32(numericUpDown3.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            progressBar4.Value = Convert.ToInt32(numericUpDown4.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Data.records.Count == 0 || Data.transactions.Count == 0)
            {
                MessageBox.Show(
                    "Файл не загружен или считан некорректно", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }

            GetOccurencies();
            SortValuesInTransactions();

        }
    }
}
