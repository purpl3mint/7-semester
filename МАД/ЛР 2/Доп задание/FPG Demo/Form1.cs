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
                .OrderByDescending(pair => pair.Value)
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
                    if (Data.occurencies[x] == Data.occurencies[y])
                    {
                        return String.Compare(x, y);
                    }
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

        private string GetPathFromNode (GraphNode node)
        {
            if (node.parent != null)
            {
                return node.value + " " + GetPathFromNode(node.parent);
            }

            return node.value;
        }

        private Dictionary<string, int> GetLocalOccurencies(string path, Dictionary<string, int> localOccurencies)
        {
            List<string> items = new List<string>(path.Split(' '));

            foreach (string item in items)
            {
                if (localOccurencies.ContainsKey(item))
                {
                    localOccurencies[item] += 1;
                } else
                {
                    localOccurencies[item] = 1;
                }
            }

            return localOccurencies;
        }

        private List<Rule> GetRulesFromConvolutionTree(List<GraphNode> currentNodes, string prefix)
        {
            List<Rule> result = new List<Rule>();

            foreach(GraphNode node in currentNodes)
            {
                if (node.children.Count == 0)
                {
                    if (prefix.Length > 0)
                        result.Add(new Rule(node.value, prefix, node.parent.count));
                } else
                {
                    List<Rule> resultFromNextLevel = GetRulesFromConvolutionTree(node.children, prefix + " " + node.value);
                    resultFromNextLevel.ForEach(r => result.Add(r));
                }
            }          

            return result;
        }

        private void GenerateConditionalRules(Graph tree, string conclusion, List<string> prefix, string target)
        {
            List<GraphNode> foundNodes = tree.FindNodes(target, tree.children);

            List<string> paths = new List<string>();

            //Getting paths
            foreach (GraphNode node in foundNodes)
            {
                string path = new string(GetPathFromNode(node).Reverse().ToArray());
                if (path == target)
                    continue;

                for (int i = 0; i < node.count; i++)
                {
                    paths.Add(path);
                }
            }

            if (paths.Count == 0)
                return;

            //Getting occurencies for conditional tree
            Dictionary<string, int> localOccurencies = new Dictionary<string, int>();
            foreach (string path in paths)
            {
                localOccurencies = GetLocalOccurencies(path, localOccurencies);
            }

            //Generating conditional tree
            Graph newTree = new Graph();
            foreach (string path in paths)
            {
                List<string> preparedPath = new List<string>(path.Split(' '));
                newTree.AddTransaction(preparedPath);
            }

            int totalTransactions = Data.transactions.Count;

            //Getting rules
            foreach(string item in localOccurencies.Keys)
            {
                if (localOccurencies[item] * 100 / totalTransactions < Data.minSupport 
                    || localOccurencies[item] * 100 / totalTransactions > Data.maxSupport
                    || item == target)
                    continue;

                List<string> newPrefix = new List<string>(prefix);
                newPrefix.Add(item);
                string newPrefixStringified = String.Join(" ", newPrefix.ToArray());
                Data.rules.Add(
                    new Rule(
                        conclusion, 
                        newPrefixStringified, 
                        localOccurencies[item] / (double)totalTransactions, 
                        0
                ));

                GenerateConditionalRules(newTree, conclusion, newPrefix, item);
            }
        }

        private Rule FindRuleBySearching(string prefix, string target)
        {
            if (prefix == "" || target == "")
                return null;

            foreach (Rule rule in Data.rules)
            {
                if (rule.prefixItems == prefix && rule.targetItem == target)
                    return rule;
            }

            return null;
        }

        private Rule FindRuleByCreating(string prefix, string target)
        {
            Rule result = new Rule();

            return result;
        }
        private void GetRules()
        {
            foreach (string value in Data.occurencies.Keys)
            {
                GenerateConditionalRules(Data.graph, value, new List<string>(), value);
            }

            //Calculating confidences
            List<Rule> newRules = new List<Rule>();
            foreach (Rule rule in Data.rules)
            {
                Rule newRule;
                if (rule.prefixItems.Length == 1)
                {
                    newRule = new Rule(
                        rule.targetItem, 
                        rule.prefixItems, 
                        rule.support,
                        rule.support * Data.transactions.Count / Data.occurencies[rule.prefixItems] );
                } else
                {
                    List<string> rulePrefixSplitted = new List<string>(rule.prefixItems.Split(' '));
                    string newConclusion = rulePrefixSplitted[0];
                    rulePrefixSplitted.RemoveAt(0);
                    string newPrefix = String.Join(" ", rulePrefixSplitted);
                    Rule ruleWithoutConclusion = FindRuleBySearching(newPrefix, newConclusion);

                    if (ruleWithoutConclusion == null)
                        ruleWithoutConclusion = rule;

                    newRule = new Rule(
                        rule.targetItem,
                        rule.prefixItems,
                        rule.support,
                        rule.support / (double)ruleWithoutConclusion.support );
                }

                if (newRule.confidence * 100 >= Data.minConfidence && newRule.confidence * 100 <= Data.maxConfidence)
                    newRules.Add(newRule);
            }

            Data.rules = newRules;
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
            Data.minSupport = Convert.ToInt32(numericUpDown1.Value);
            Data.maxSupport = Convert.ToInt32(numericUpDown2.Value);
            Data.minConfidence = Convert.ToInt32(numericUpDown3.Value);
            Data.maxConfidence = Convert.ToInt32(numericUpDown4.Value);

            if (Data.minSupport >= Data.maxSupport)
            {
                MessageBox.Show(
                    "Некорректные значения поддержки",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (Data.minConfidence >= Data.maxConfidence)
            {
                MessageBox.Show(
                    "Некорректные значения достоверности",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (Data.records.Count == 0 || Data.transactions.Count == 0)
            {
                MessageBox.Show(
                    "Файл не загружен или считан некорректно", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }

            Data.rules = new List<Rule>();
            dataGridView3.Rows.Clear();

            GetRules();

            int i = 1;
            foreach(Rule rule in Data.rules)
            {
                dataGridView3.Rows.Add(
                    i++, 
                    rule.prefixItems, 
                    rule.targetItem, 
                    rule.support * 100, 
                    rule.confidence * 100);
            }
        }
    }
}
