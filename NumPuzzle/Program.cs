using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumPuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager("source.txt");
            GraphManager graphManager = new GraphManager(fileManager);

            string longestNumber = fileManager.PrintSolution(graphManager.LongestPath(), graphManager.Graph);
            Console.WriteLine(longestNumber);
            fileManager.SaveSolution(longestNumber);
            Console.ReadKey();
        }
    }
}
