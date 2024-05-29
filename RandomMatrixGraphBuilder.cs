using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    internal class RandomMatrixGraphBuilder : IGraphBuilder
    {
        // RandomMatrixGraphBuilder class is used to generate a random graph with a given size and weight range.
        private int _size;
        private int _minWeightValue;
        private int _maxWeightValue;

        public RandomMatrixGraphBuilder(int size, int minWeightValue, int maxWeightValue)
        {
            _size = size;
            _minWeightValue = minWeightValue;
            _maxWeightValue = maxWeightValue;
        }

        public IGraph GenerateGraph()
        {
            int[,] matrix = new int[_size, _size];

            Random random = new Random();

            for(int i = 0; i < _size; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    int weight = random.Next(_minWeightValue, _maxWeightValue);
                    matrix[i, j] = weight;
                    matrix[j, i] = weight;
                }
            }

            return new AdjacencyMatrixGraph(matrix, _size);
        }

    }
}
