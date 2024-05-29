using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public interface IGraph
    {
        int Size { get; }
        int ValueAt(int x, int y);
        IEnumerable<int> GetNeighbors(int nodeIndex);
        int GetEdgeCost(int fromNodeIndex, int toNodeIndex);
        void Display(); 

    }
}
