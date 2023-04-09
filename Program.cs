using genetic_algo;
using genetic_algo.Algorithm;

// Initialize graph
Graph graph = new Graph();

graph.AddNodes(new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16});

graph.AddEdges(1, new List<int>{2,3,4,13,15,16});
graph.AddEdges(2, new List<int>{1,3,5,9,8,14,15,16});
graph.AddEdges(3, new List<int>{1,2,5,6,4});
graph.AddEdges(4, new List<int>{1,3,6,13});
graph.AddEdges(5, new List<int>{2,3,6,7,10,9});
graph.AddEdges(6, new List<int>{3,5,7,11,13,4});
graph.AddEdges(7, new List<int>{5,6,10,11});
graph.AddEdges(8, new List<int>{2,9,14});
graph.AddEdges(9, new List<int>{2,5,8,10,12,14});
graph.AddEdges(10, new List<int>{5,7,9,11,12});
graph.AddEdges(11, new List<int>{7,6,10,12,13});
graph.AddEdges(12, new List<int>{10,11,9,13,14,15});
graph.AddEdges(13, new List<int>{1,6,4,11,12,15});
graph.AddEdges(14, new List<int>{8,9,12,15,2});
graph.AddEdges(15, new List<int>{12,13,14,1,2,16});
graph.AddEdges(16, new List<int>{1,2,15});

// Run algorithm
GeneticAlgo.Apply(graph);

// Print colors
Console.WriteLine("RESULTS");
foreach (var i in graph.Nodes)
{
    Console.Write("Node: ");
    Console.Write(i.Key);
    Console.Write(", Color: ");
    Console.Write(i.Value.Color);
    Console.WriteLine();
}
