namespace Strategy
{
    using System.Collections.Generic;

    public interface ISortStrategy
    {
        List<int> Sort(List<int> dataset);
    }
}
