using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class Graph
    {
        List<GraphNode> children { get; set; }

        public Graph()
        {
            this.children = new List<GraphNode>();
        }

        public void AddChild(GraphNode child)
        {
            if (child != null)
                this.children.Add(child);
        }
        public GraphNode GetChildByValue(string value)
        {
            foreach(GraphNode node in this.children)
            {
                if (node.value == value)
                    return node;
            }

            return null;
        }
        

        public void AddTransaction(List<string> transaction)
        {
            if (transaction.Count == 0)
                return;

            foreach(GraphNode node in this.children)
            {
                if (node.value == transaction[0])
                {
                    transaction.RemoveAt(0);
                    node.AddTransaction(transaction);
                    return;
                }
            }

            this.children.Add(new GraphNode(transaction[0], 0, null));
            transaction.RemoveAt(0);
            this.children[this.children.Count - 1].AddTransaction(transaction);
        }
    }
}
