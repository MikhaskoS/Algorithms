namespace Utility.Sorting
{
    public class  MergeSort
    {
        public static void Sort(int[] A)
        {
            Sort(A, 0, A.Length - 1);
        }

        private static void Sort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                Sort(A, p, q);
                Sort(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }

        // Объединение отсортированных!!! последовательностей
        // { 2, 10, 0, 8, 9 } p = 0, q = 1, r = 4 ->  {2, 10} {0, 8, 9}
        private static void Merge(int[] A, int p, int q, int r)
        {
            // разбиение на 2 под-массива
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];

            for (int l = 0; l < n1; l++)
                L[l] = A[p + l];

            for (int m = 0; m < n2; m++)
                R[m] = A[q + m + 1];

            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;


            int i = 0;
            int j = 0;

            // слияние массивов
            for (int k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
            }
        }
    }
}
