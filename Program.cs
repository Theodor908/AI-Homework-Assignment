using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class Program
    {
        // Main method.
        public static void Main(string[] args)
        {
            // Structure with real life distances between cities in Europe (I got the distances from a website).
            IGraphBuilder manualMatrixGraphBuilder1 = new ManualMatrixGraphBuilder(new int[,] {
                {0, 250, 350, 450, 600, 700, 800, 900, 1000, 1100},
                {250, 0, 150, 250, 400, 500, 600, 700, 800, 900},
                {350, 150, 0, 100, 250, 350, 450, 550, 650, 750},
                {450, 250, 100, 0, 150, 250, 350, 450, 550, 650},
                {600, 400, 250, 150, 0, 100, 200, 300, 400, 500},
                {700, 500, 350, 250, 100, 0, 100, 200, 300, 400},
                {800, 600, 450, 350, 200, 100, 0, 100, 200, 300},
                {900, 700, 550, 450, 300, 200, 100, 0, 100, 200},
                {1000, 800, 650, 550, 400, 300, 200, 100, 0, 100},
                {1100, 900, 750, 650, 500, 400, 300, 200, 100, 0} }); 

            // Complex structure with random distances between cities. (I tried to make it as complex as possible)
            IGraphBuilder manualMatrixGraphBuilder2 = new ManualMatrixGraphBuilder(new int[,] {
                {0, 2, 9, 10, 1, 11, 15, 8, 6, 14},
                {2, 0, 7, 12, 3, 13, 5, 9, 4, 16},
                {9, 7, 0, 4, 8, 6, 14, 10, 12, 1},
                {10, 12, 4, 0, 13, 5, 3, 7, 11, 2},
                {1, 3, 8, 13, 0, 15, 6, 4, 2, 9},
                {11, 13, 6, 5, 15, 0, 7, 3, 14, 12},
                {15, 5, 14, 3, 6, 7, 0, 2, 9, 11},
                {8, 9, 10, 7, 4, 3, 2, 0, 5, 13},
                {6, 4, 12, 11, 2, 14, 9, 5, 0, 10},
                {14, 16, 1, 2, 9, 12, 11, 13, 10, 0} });



            // Random matrix graph builder. Randomly generate the matrix.
            IGraphBuilder randomMatrixGraphBuilder = new RandomMatrixGraphBuilder(10, 1, 100);

            // Define the algorithms to be used.
            DepthFirstSearch dfs = new DepthFirstSearch();
            LeastCostSearch lcs = new LeastCostSearch();
            AStar astar = new AStar();

            // Add the algorithms to a dictionary.
            Dictionary<int, ITSPGraphTraversalAlgorithm> traversalAlgorithms = new Dictionary<int, ITSPGraphTraversalAlgorithm>();
            traversalAlgorithms.Add(1, dfs);
            traversalAlgorithms.Add(2, lcs);
            traversalAlgorithms.Add(3, astar);

            // Create the Traveling Salesman Problem object and insert the graph builder and algorithms.
            // You can freely interchange the graph builder and algorithms.
            TravelingSalesmanProblem tsp = new TravelingSalesmanProblem(manualMatrixGraphBuilder1, traversalAlgorithms);


            // Select the algorithm and run it.
            tsp.SelectAlgorithmAndRun(1);
            tsp.SelectAlgorithmAndRun(2);
            tsp.SelectAlgorithmAndRun(3);

        }
    }
}