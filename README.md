# AI-Homework-Assignment
Homework assignment
The Program class is the main entry point of the program. It is where the application is built according to user specific needs. In this class you create graph builders and algorithms that implement certain interfaces. These algorithms are put in a dictionary and then they, alongside the builder, are passed to TSP class. This class uses them to create the desired application. After this phase the desired algorithm can be chosen to run and display the associated result.
The manual builder lets the user insert the desired graph in form of an adjacency matrix.
The random builder generates random graphs based on the given number of nodes and weights.
A* Search, DFS, LCS are all put in a dictionary which is passed to TSP class. They all have an associated ID which is used to tell TSP class which of them to run.
The provided graphs are in a range which returns the result quickly. I've managed to make use of some inputs from the specified site but the number of nodes is so great that it will take hours, even days to get a result.
