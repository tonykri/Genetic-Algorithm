namespace genetic_algo;

public class Node {
    public int Value;
    public char? Color;
    public List<Node> Neighbors;

    public Node(int value) {
        Value = value;
        Color = null;
        Neighbors = new List<Node>();
    }

    public void AddNeighbor(Node node) {
        Neighbors.Add(node);
    }
}



public class Graph {
    public Dictionary<int, Node> Nodes;

    public Graph() {
        Nodes = new Dictionary<int, Node>();
    }

    public void AddNode(int value) {
        Node node = new Node(value);
        Nodes.Add(value, node);
    }

    public void AddNodes(List<int> values) {
        foreach(int value in values)
            AddNode(value);
    }

    public void AddEdge(int fromValue, int toValue) {
        Node fromNode = Nodes[fromValue];
        Node toNode = Nodes[toValue];
        fromNode.AddNeighbor(toNode);
    }

    public void AddEdges(int fromValue, List<int> toValues) {
        foreach(int toValue in toValues)
            AddEdge(fromValue, toValue);
    }
}
