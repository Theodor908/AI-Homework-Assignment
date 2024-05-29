using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class AdjacencyMatrixGraph : IGraph
    {
        // This class represents a graph as an adjacency matrix. By using an interface any kind of graph representation can be used as long as it implements the IGraph interface.
        private int[,] _matrix;
        private int _size;

        public int Size => _size;

        public AdjacencyMatrixGraph(int[,] matrix, int size)
        {
            _matrix = matrix;
            _size = size;
        }

        public int ValueAt(int x, int y)
        {
            return _matrix[x, y];
        }

        public IEnumerable<int> GetNeighbors(int nodeIndex)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_matrix[nodeIndex, i] != 0) 
                {
                    yield return i;
                }
            }
        }

        public int GetEdgeCost(int fromNodeIndex, int toNodeIndex)
        {
            return _matrix[fromNodeIndex, toNodeIndex];
        }

        public void Display()
        {
            Console.WriteLine("Adjacency Matrix: ");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
