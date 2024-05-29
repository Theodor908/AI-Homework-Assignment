using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class ManualMatrixGraphBuilder : IGraphBuilder
    {
        // This class is used to build a graph from a manually entered matrix.
        private int[,] _matrix;

        public ManualMatrixGraphBuilder(int[,] matrix)
        {
            _matrix = matrix;
        }
        public IGraph GenerateGraph()
        {
            int size = _matrix.GetLength(0);
            return new AdjacencyMatrixGraph(_matrix, size);
        }
    }
}
