using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class DisplayResults
    {
        // Display the results of the algorithm.
        private String _name;
        private List<int> _path;
        private int _cost;
        private double _runTime;

        public DisplayResults(String name, List<int> path, int cost, double runTime)
        {
            _name = name;
            _path = path;
            _cost = cost;
            _runTime = runTime;
        }
        public void Display()
        {
            Console.WriteLine("Algorithm: " + _name);
            Console.WriteLine("Path: ");

            // Represent the roads in pairs (1, 2), (2, 4), ...

            for (int i = 0; i < _path.Count - 1; i++)
            {
                Console.Write("(" + _path[i] + ", " + _path[i + 1] + ") ");
                if (i != _path.Count - 2)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("Cost: " + _cost);
            Console.WriteLine("Run Time: " + _runTime + " ms");
            Console.WriteLine();

        }
    }
}
