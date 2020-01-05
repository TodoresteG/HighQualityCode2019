namespace Strategy
{
    using System.Collections.Generic;

    public class Sorter
    {
        private readonly ISortStrategy sortStrategy;

        public Sorter(ISortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public List<int> Sort(List<int> unsortedDataset) 
        {
            return this.sortStrategy.Sort(unsortedDataset);
        }
    }
}
