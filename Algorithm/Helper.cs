namespace genetic_algo.Algorithm;

internal abstract partial class Helper
{
    private static char[] Colors = { 'R', 'G', 'B', 'Y' };

    public static List<List<char>> Init(int numOfNodes, int numOfSamples)
    {
        Random rand = new Random();
        List<List<char>> samples = new List<List<char>>();
        List<char> sample;
        int iters = numOfNodes;
        while (numOfSamples > 0)
        {
            sample = new List<char>();
            while (iters > 0)
            {
                sample.Add(Colors[rand.Next(0, Colors.Length)]);
                iters--;
            }
            samples.Add(sample);
            numOfSamples--;
            iters = numOfNodes;
        }
        return samples;
    }

    public static int[] GetScores(List<List<char>> samples, Graph graph)
    {
        List<int> scores = new List<int>();
        List<Node> neighbors;
        int scoreCount = 0;
        foreach (List<char> sample in samples)
        {
            for (int i = 1; i < sample.Count + 1; i++)
            {
                neighbors = graph.Nodes[i].Neighbors;
                foreach (Node neighbor in neighbors)
                    if (!sample[neighbor.Value - 1].Equals(sample[i - 1]))
                        scoreCount++;
            }
            scores.Add(scoreCount);
            scoreCount = 0;
        }
        return scores.ToArray();
    }

    public static List<int[]> GetCouples(int[] scores)
    {
        List<int[]> couples = new List<int[]>();
        int[] positions = SortArray(scores);
        Random rand = new Random();
        int randNum;
        int[] scoresSum = GetScoresSum(scores);
        for (int i = 0; i < scores.Length / 2; i++)
        {
            int[] couple = new int[2];
            randNum = rand.Next(0, scoresSum[scoresSum.Length - 1]);
            for (int j = 0; j < scoresSum.Length; j++)
            {
                if (randNum < scoresSum[j])
                {
                    couple[0] = j;
                    break;
                }
            }
            randNum = rand.Next(0, scoresSum[scoresSum.Length - 1]);
            for (int j = 0; j < scoresSum.Length; j++)
            {
                if (randNum < scoresSum[j])
                {
                    couple[1] = j;
                    break;
                }
            }
            couples.Add(couple);
        }
        return couples;
    }

    public static List<List<char>> GetChildren(List<List<char>> samples, List<int[]> couples)
    {
        List<List<char>> children = new List<List<char>>();
        List<char> child1 = new List<char>();
        List<char> child2 = new List<char>();
        List<char> parent1;
        List<char> parent2;
        Random rand = new Random();
        double pred;
        foreach (var couple in couples)
        {
            parent1 = samples[couple[0]];
            parent2 = samples[couple[1]];
            for (int j = 0; j < parent1.Count / 2; j++)
            {
                child1.Add(parent1[j]);
                child2.Add(parent2[j]);
            }
            for (int j = parent1.Count / 2; j < parent1.Count; j++)
            {
                child1.Add(parent2[j]);
                child2.Add(parent1[j]);
            }
            pred = rand.NextDouble();
            if (pred < 0.1)
                child1[rand.Next(0, child1.Count)] = Colors[rand.Next(0, Colors.Length)];
            if (pred < 0.1)
                child2[rand.Next(0, child1.Count)] = Colors[rand.Next(0, Colors.Length)];
            children.Add(child1);
            children.Add(child2);
            child1 = new List<char>();
            child2 = new List<char>();
        }
        return children;
    }
}
