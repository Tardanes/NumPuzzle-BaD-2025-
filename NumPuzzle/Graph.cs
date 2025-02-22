using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumPuzzle
{
    public class Graph
    {
        public List<Node> Nodes { get; }

        public Graph() 
        {
            Nodes = new List<Node>();
        }

        public Graph(List<Node> nodes)
        {
            this.Nodes = nodes;
        }

        public void AutoAddEdges()
        {
            if (Nodes.Count > 0)
            {
                for (int i = 0; i < Nodes.Count; i++) 
                {
                    for (int j = 0; j < Nodes.Count; j++)
                    {                        
                        if (Nodes[i].FrontId == Nodes[j].RearId && Nodes[i] != Nodes[j])
                        {
                            Nodes[i].AddEdge(new Edge(Nodes[j], Nodes[j].Id.ToString()));
                        }
                    }
                }
            }
        }
    }
}