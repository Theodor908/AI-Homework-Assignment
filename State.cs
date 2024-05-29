using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class State : IComparable<State>
    {
        // This class represents a state in the search space for the TSP problem used in Depth-First Search and Least-Cost Search. Different approach was used for the A* algorithm.
        public int CurrentNode { get; set; }
        public int Depth { get; set; }
        public int Cost { get; set; }
        public List<bool> Visited { get; set; }
        public List<int> Path { get; set; }

        public State(int currentNode, int depth, int cost, List<bool> visited, List<int> path)
        {
            CurrentNode = currentNode;
            Depth = depth;
            Cost = cost;
            Visited = visited;
            Path = path;

        }

        public int CompareTo(State other)
        {
            return other.Cost.CompareTo(Cost);
        }

    }
}
