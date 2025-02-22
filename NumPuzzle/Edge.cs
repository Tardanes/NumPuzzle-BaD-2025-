using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumPuzzle
{
    public class Edge
    {
        public Node ConnNode { get; set; }
        public string Name { get; set; }

        public Edge(Node connNode, string name)
        {
            ConnNode = connNode;
            Name = name;
        }
    }
}