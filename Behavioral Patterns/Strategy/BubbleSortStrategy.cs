namespace Strategy
{
    using System;
    using System.Collections.Generic;

    public class BubbleSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting dataset with bubble sort");
            return dataset;
        }
    }
}
