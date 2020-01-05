namespace Strategy
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var unsortedDataset = new List<int>()
            {
                1, 10, 2, 16, 19
            };

            var sorter = new Sorter(new BubbleSortStrategy());
            sorter.Sort(unsortedDataset);

            sorter = new Sorter(new QuickSortStrategy());
            sorter.Sort(unsortedDataset);
        }
    }
}
