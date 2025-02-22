using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumPuzzle
{
    public class Node
    {
        public int Id { get; set; }
        public string Value { get; set; }     
        public string RearId { get; set; }
        public string FrontId { get; set; }
        public List<Edge> Connections { get; set; } = new List<Edge>();
        public Node(int id, string value, string frontId, string rearId) 
        {
            Id = id;
            Value = value;
            FrontId = frontId;
            RearId = rearId;
        }

        public void AddEdge (Edge edge) 
        { 
            Connections.Add(edge); 
        }
        public void AddEdge (Node nextNode, string edgeName)
        {
            Connections.Add(new Edge(nextNode, edgeName));
        }
    }
}