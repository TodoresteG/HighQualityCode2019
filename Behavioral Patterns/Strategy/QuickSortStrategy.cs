namespace Strategy
{
    using System;
    using System.Collections.Generic;

    public class QuickSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting dataset with Qick Sort");
            return dataset;
        }
    }
}
