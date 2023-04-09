namespace genetic_algo.Algorithm;
partial class Helper
{
    private static int[] SortArray(int[] scores)
    {
        int[] positions = new int[scores.Length];
        void QuickSort(int[] array, int left, int right, int[] pos)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right, pos);
                QuickSort(array, left, pivotIndex - 1, pos);
                QuickSort(array, pivotIndex + 1, right, pos);
            }
        }
        int Partition(int[] array, int left, int right, int[] pos)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    int tempPos = pos[i];
                    pos[i] = pos[j];
                    pos[j] = tempPos;
                }
            }
            int temp2 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp2;

            int tempPos2 = pos[i + 1];
            pos[i + 1] = pos[right];
            pos[right] = tempPos2;

            return i + 1;
        }
        QuickSort(scores, 0, scores.Length - 1, positions);
        return positions;
    }

    private static int[] GetScoresSum(int[] scores){
        int[] scoresSum = new int[scores.Length];
        int sum = 0;
        for(int i = 0; i < scores.Length; i++){
            sum += scores[i];
            scoresSum[i] = sum;
        }
        return scoresSum;
    }
}
