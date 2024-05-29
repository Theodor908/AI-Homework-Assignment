using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class LeastCostSearch : ITSPGraphTraversalAlgorithm
    {
        // This class implements the Least-Cost Search algorithm for the Travelling Salesman Problem.
        public String Name => "Least-Cost Search";
        private IGraph _graph;
        private int _cost;
        private List<int> _route;

        public LeastCostSearch()
        {
            _cost = int.MaxValue;
            _route = new List<int>();
        }

        // This method traverses the graph using the Least-Cost Search algorithm.
        /* The algorithm works as follows:
         * 1. Start at the initial node.
         * 2. Visit the unvisited node with the smallest edge cost.
         * 3. Repeat step 2 until all nodes are visited.
         * 4. Return to the initial node.
         * 5. If the cost of the current path is less than the current minimum cost, update the minimum cost and the route.
         * 
         * For large graphs, it may not be the best choice due to its exponential time complexity. 
         * Experimentaly, it is slower than the A* algorithm and Depth-First Search algorithm.
         **/
        public void TraverseGraph(IGraph graph)
        {
            _graph = graph;
            PriorityQueue<State, int> pq = new PriorityQueue<State, int>();
            List<bool> initialVisited = new List<bool>(new bool[_graph.Size]);
            initialVisited[0] = true;
            State initialState = new State(0, 1, 0, initialVisited, new List<int> { 0 });
            pq.Enqueue(initialState, initialState.Cost);

            while (pq.Count > 0)
            {
                State currentState = pq.Dequeue();

                if (currentState.Depth == _graph.Size && _graph.ValueAt(currentState.CurrentNode, 0) != 0)
                {
                    int totalCost = currentState.Cost + _graph.ValueAt(currentState.CurrentNode, 0);
                    if (totalCost < _cost)
                    {
                        _cost = totalCost;
                        _route = new List<int>(currentState.Path);
                        _route.Add(0);
                    }
                    continue;
                }

                for (int i = 0; i < _graph.Size; i++)
                {
                    if (!currentState.Visited[i] && _graph.ValueAt(currentState.CurrentNode, i) != 0)
                    {
                        List<bool> newVisited = new List<bool>(currentState.Visited);
                        newVisited[i] = true;
                        List<int> newPath = new List<int>(currentState.Path);
                        newPath.Add(i);
                        int newCost = currentState.Cost + _graph.ValueAt(currentState.CurrentNode, i);
                        State newState = new State(i, currentState.Depth + 1, newCost, newVisited, newPath);
                        pq.Enqueue(newState, newState.Cost);
                    }
                }
            }
        }

        public List<int> MinimumCostRoute()
        {
            return _route;
        }

        public int MinimumCost()
        {
            return _cost;
        }
    }
}
