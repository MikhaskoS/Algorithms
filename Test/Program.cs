using Utility;
using Utility.Sorting;



namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] ar = new double[] { 5, 4, 9, 0, 10 };

            BubbleSort.Sort(ar);

            ar.PrintArray();
        }
    }
}
