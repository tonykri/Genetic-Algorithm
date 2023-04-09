namespace genetic_algo.Algorithm;

public abstract class GeneticAlgo
{
    private static int numOfNodes;
    private static int numOfSamples;
    private static int bestScore = 0;
    private static List<char> bestSample = new List<char>();

    private static bool GetBestScore(int[] scores, List<List<char>> samples)
    {
        int position = 0;
        bool foundBestScore = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] > bestScore)
            {
                position = i;
                bestScore = scores[i];
                foundBestScore = true;
            }
        }
        if (foundBestScore){
            bestSample = samples[position];
            Console.WriteLine("Current best score: "+ bestScore);
            return true;
        }
        return false;
    }

    private static void DrawGraph(Graph graph){
        int i = 0;
        foreach(var node in graph.Nodes){
            node.Value.Color = bestSample[i];
            i++;
        }
    }

    public static void Apply(Graph graph)
    {
        numOfNodes = graph.Nodes.Count;
        numOfSamples = 2 * numOfNodes;
        List<List<char>> samples = Helper.Init(numOfNodes, numOfSamples);
        int[] scores;
        List<int[]> couples;
        int itersToBreak = 0;

        for (int iters = 0; iters < 1000; iters++)
        {
            scores = Helper.GetScores(samples, graph);
            if(!GetBestScore(scores, samples))
                itersToBreak++;
            else
                itersToBreak = 0;
            if(itersToBreak > 500)
                break;
            couples = Helper.GetCouples(scores);
            samples = Helper.GetChildren(samples, couples);
        }

        DrawGraph(graph);
    }
}
