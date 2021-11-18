using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPG_Demo
{
    public class Graph
    {
        public List<GraphNode> children { get; set; }

        public Graph()
        {
            this.children = new List<GraphNode>();
        }

        public void AddChild(GraphNode child)
        {
            if (child != null)
                this.children.Add(child);
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

        public List<GraphNode> FindNodes(string targetValue, List<GraphNode> currentNodes)
        {
            List<GraphNode> result = new List<GraphNode>();
            foreach (GraphNode node in currentNodes)
            {
                if (node.value == targetValue)
                {
                    result.Add(node);
                } 
                else if (node.children.Count > 0)
                {
                    List<GraphNode> resultFromNextLevel = Data.graph.FindNodes(targetValue, node.children);
                    resultFromNextLevel.ForEach(n => result.Add(n));
                }
            }

            return result;
        }

    }
}
