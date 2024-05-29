using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class DepthFirstSearch : ITSPGraphTraversalAlgorithm
    {

        // This class implements the Depth-First Search algorithm for the Travelling Salesman Problem.
        public String Name => "Depth-First Search";
        private IGraph _graph;
        private int _cost;
        private List<int> _route;

        public DepthFirstSearch()
        {
            _cost = int.MaxValue;
            _route = new List<int>();
        }

        /* The algorithm works as follows:
         * 1. We start at the initial node (0) and mark it as visited.
         * 2. Visit every unvisited node connected to the current node.
         * 3. Repeat step 2 until all nodes are visited.
         * 4. Return to the initial node.
         * 5. If the cost of the current path is less than the current minimum cost, update the minimum cost and the route.
         * 6. Repeat the process until all possible paths are explored.
         * 
         * It is important to note that this algorithm is computationally expensive for large graphs due to its exponential time complexity.
         * Experimentaly, it is slower than the A* algorithm and faster than Least-Cost Search algorithm.
         * **/

        public void TraverseGraph(IGraph graph)
        {
            _graph = graph;
            Stack<State> stack = new Stack<State>();
            List<bool> visited = new List<bool>(new bool[_graph.Size]);
            List<int> bestPath = new List<int>();
            int cost = int.MaxValue;

            visited[0] = true;
            State initialState = new State(0, 1, 0, visited, new List<int> { 0 });
            stack.Push(initialState);

            while (stack.Count > 0)
            {
                State currentState = stack.Pop();

                if (currentState.Depth == _graph.Size && _graph.ValueAt(currentState.CurrentNode, 0) != 0)
                {
                    int totalCost = currentState.Cost + _graph.ValueAt(currentState.CurrentNode, 0);
                    if (totalCost < cost)
                    {
                        cost = totalCost;
                        bestPath = new List<int>(currentState.Path);
                        bestPath.Add(0);
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
                        stack.Push(newState);
                    }
                }
            }

            _route = bestPath;
            _cost = cost;
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
