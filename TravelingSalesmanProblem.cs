using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Vasile Theodor-Gabriel CEN2.3B
namespace HomeworkAssignmentAI
{
    public class TravelingSalesmanProblem
    {
        // This class is the main class of the application. It is used to run the algorithms and display the results.
        private Dictionary<int, ITSPGraphTraversalAlgorithm> _traversalAlgorithms;
        private ITSPGraphTraversalAlgorithm _currentAlgorithm;
        private IGraphBuilder _graphBuilder;
        private DisplayResults _displayResults;
        private IGraph _graph;
        private int _algorithm;
        private double _runTime;

        public TravelingSalesmanProblem(IGraphBuilder matrixGraphBuilder, Dictionary<int, ITSPGraphTraversalAlgorithm> traversalAlgorithms)
        {
            _traversalAlgorithms = traversalAlgorithms;
            _graphBuilder = matrixGraphBuilder;
            _graph = _graphBuilder.GenerateGraph();
            _graph.Display();
        }

        // While running the application, the user can select an algorithm and run it. The algorithm will traverse the graph and display the results while it is chronometrated.
        public void SelectAlgorithmAndRun(int algorithm)
        {
            _currentAlgorithm = _traversalAlgorithms[algorithm];
            var watch = System.Diagnostics.Stopwatch.StartNew();
            _currentAlgorithm.TraverseGraph(_graph);
            watch.Stop();
            _runTime = watch.ElapsedMilliseconds;
            ShowResult();
        }

        public void ShowResult()
        {
            _displayResults = new DisplayResults(_currentAlgorithm.Name, _currentAlgorithm.MinimumCostRoute(), _currentAlgorithm.MinimumCost(), _runTime);
            _displayResults.Display();
        }

    }
}
