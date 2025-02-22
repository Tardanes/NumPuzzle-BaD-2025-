using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NumPuzzle
{
    public class FileManager
    {
        public string InPath { get; }
        public string OutPath { get; }

        public FileManager(string InPath = "raw.txt", string OutPath = "out.txt")
        {
            this.InPath = InPath;
            this.OutPath = OutPath;
        }

        public Graph GetGraph()
        {
            if (!File.Exists(InPath)) return new Graph();
            Graph graph = new Graph();
            using (var fs = new FileStream(InPath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs)) 
            {
                string line;
                int iter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    graph.Nodes.Add(new Node(iter, line.Substring(2, 2), line.Substring(4, 2), line.Substring(0, 2)));
                    iter++;
                }
            }
            graph.AutoAddEdges();
            return graph;
        }

        public string PrintSolution(List<int> nodesId, Graph graph)
        {
            string result;
            if (nodesId.Count != 0)
                result = graph.Nodes[nodesId.First()].RearId;
            else return null;

            foreach (int i in nodesId)
            {
                result += graph.Nodes[i].Value + graph.Nodes[i].FrontId;
            }

            return result;
        }

        public void SaveSolution(string result)
        {
            using (var fs = new FileStream(OutPath, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs)) sw.WriteLine(result);            
        }
    }
}