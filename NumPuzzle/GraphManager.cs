using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumPuzzle
{
    public class GraphManager
    {
        public Graph Graph { get; }
        private Dictionary<int, List<int>> memo;
        private Dictionary<int, int> longestPathMemo;
        private List<int> longestPath;

        public GraphManager(Graph graph)
        {
            Graph = graph;
            memo = new Dictionary<int, List<int>>();
            longestPathMemo = new Dictionary<int, int>();
            longestPath = new List<int>();
        }

        public GraphManager(FileManager initializator)
        {
            Graph = initializator.GetGraph();
            memo = new Dictionary<int, List<int>>();
            longestPathMemo = new Dictionary<int, int>();
            longestPath = new List<int>();
        }

        public List<int> LongestPath()
        {
            int maxLength = 0;
            List<int> bestPath = new List<int>();

            foreach (var node in Graph.Nodes)
            {
                var path = DFS(node.Id, new HashSet<int>());
                if (path.Count > maxLength)
                {
                    maxLength = path.Count;
                    bestPath = path;
                }
            }

            return bestPath;
        }

        private List<int> DFS(int nodeId, HashSet<int> visited)
        {
            if (visited.Contains(nodeId))
                return new List<int>();

            if (memo.ContainsKey(nodeId))
                return memo[nodeId];

            visited.Add(nodeId);
            List<int> longestSubPath = new List<int>();

            foreach (var edge in Graph.Nodes[nodeId].Connections)
            {
                var subPath = DFS(edge.ConnNode.Id, new HashSet<int>(visited));
                if (subPath.Count > longestSubPath.Count)
                {
                    longestSubPath = subPath;
                }
            }

            visited.Remove(nodeId);
            longestSubPath.Insert(0, nodeId);
            memo[nodeId] = longestSubPath;

            return longestSubPath;
        }
    }
}