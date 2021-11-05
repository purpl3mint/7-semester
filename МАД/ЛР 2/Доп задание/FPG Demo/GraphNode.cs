using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class GraphNode
    {
        public string value { get; set; }
        public int count { get; set; }
        public GraphNode parent { get; set; }
        public List<GraphNode> children { get; set; }

        public GraphNode(string value = "", int count = 0, GraphNode parent = null)
        {
            this.value = value;
            this.count = count;
            this.parent = parent;
            this.children = new List<GraphNode>();
        }

        public void AddChild(GraphNode child)
        {
            if (child != null)
                this.children.Add(child);
        }

        public void AddTransaction(List<string> transaction)
        {
            this.count++;

            if (transaction.Count == 0)
                return;

            foreach (GraphNode node in this.children)
            {
                if (node.value == transaction[0])
                {
                    transaction.RemoveAt(0);
                    node.AddTransaction(transaction);
                    return;
                }
            }

            this.children.Add(new GraphNode(transaction[0], 0, this));
            transaction.RemoveAt(0);
            this.children[this.children.Count - 1].AddTransaction(transaction);
        }
    }
}
