using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class AStar : ITSPGraphTraversalAlgorithm
    {
        // AStar class is used to solve the Travelling Salesman Problem using the A* search algorithm.
        public string Name => "A* Search";
        private IGraph _graph;
        private List<int> _route;
        private int _cost;

        public AStar()
        {
            _cost = int.MaxValue;
        }

        /* The TraverseGraph method is used to traverse the graph and find the minimum cost route.
         * The AStarTSP method is a recursive method that uses the A* search algorithm to find the minimum cost route.
         * The MSTHeuristic method calculates the minimum spanning tree heuristic for the given node.
         * The PrimMSTCost method calculates the minimum spanning tree cost for the given nodes. It uses Prim's algorithm but Kruskal's algorithm can also be used.
         * The MinKey method finds the minimum key value in the key array.
         * The MinimumCostRoute method returns the minimum cost route.
         * The MinimumCost method returns the minimum cost.
         * 
         * In order to be able to use the A* I needed to implement a MST heuristic to estimate the cost of the remaining path.
         * Experimentaly, A* is significantly faster than the other algorithms for large graphs. 
         */

        public void TraverseGraph(IGraph graph)
        {
            _graph = graph;
            int n = graph.Size;
            _route = new List<int>(new int[n]);
            List<bool> visited = new List<bool>(new bool[n]);
            List<int> route = new List<int>(new int[n]);
            route[0] = 0;
            visited[0] = true;
            AStarTSP(0, 1, 0, route, visited);
            _route.Add(0);
            
        }

        private void AStarTSP(int current, int level, int currentCost, List<int> route, List<bool> visited)
        {
            if (level == _graph.Size)
            {
                int finalCost = currentCost + _graph.GetEdgeCost(current, 0);
                if (finalCost < _cost)
                {
                    _cost = finalCost;
                    _route = new List<int>(route);
                }
                return;
            }

            for (int i = 1; i < _graph.Size; i++)
            {
                if (!visited[i])
                {
                    int newCost = currentCost + _graph.GetEdgeCost(current, i);
                    if (newCost < _cost)
                    {
                        visited[i] = true;
                        route[level] = i;
                        int h = MSTHeuristic(i, visited);
                        if (newCost + h < _cost)
                        {
                            AStarTSP(i, level + 1, newCost, route, visited);
                        }
                        visited[i] = false;
                    }
                }
            }
        }

        private int MSTHeuristic(int current, List<bool> visited)
        {
            List<int> remainingCities = new List<int>();
            for (int i = 0; i < _graph.Size; i++)
            {
                if (!visited[i])
                {
                    remainingCities.Add(i);
                }
            }

            if (remainingCities.Count == 0)
            {
                return _graph.GetEdgeCost(current, 0);
            }

            int mstCost = PrimMSTCost(remainingCities);
            int minToMST = remainingCities.Min(city => _graph.GetEdgeCost(current, city));
            int minFromMST = remainingCities.Min(city => _graph.GetEdgeCost(city, 0));

            return mstCost + minToMST + minFromMST;
        }

        private int PrimMSTCost(List<int> nodes)
        {
            int n = nodes.Count;
            List<int> key = new List<int>(Enumerable.Repeat(int.MaxValue, n));
            List<bool> inMST = new List<bool>(Enumerable.Repeat(false, n));
            List<int> parent = new List<int>(Enumerable.Repeat(-1, n));
            key[0] = 0;
            int mstCost = 0;

            for (int count = 0; count < n - 1; count++)
            {
                int u = MinKey(key, inMST);
                inMST[u] = true;

                for (int v = 0; v < n; v++)
                {
                    int weight = _graph.GetEdgeCost(nodes[u], nodes[v]);
                    if (!inMST[v] && weight < key[v])
                    {
                        parent[v] = u;
                        key[v] = weight;
                    }
                }
            }

            for (int i = 1; i < n; i++)
            {
                mstCost += _graph.GetEdgeCost(nodes[i], nodes[parent[i]]);
            }

            return mstCost;
        }

        private int MinKey(List<int> key, List<bool> inMST)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < key.Count; v++)
            {
                if (!inMST[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
        public List<int> MinimumCostRoute()
        {
            return new List<int>(_route);
        }

        public int MinimumCost()
        {
            return _cost;
        }


    }
}
