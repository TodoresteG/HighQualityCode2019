namespace Zombow.Repositories.Contracts
{
    using Models.Bows.Contracts;

    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IBow model);

        bool Remove(IBow model);

        IBow Find(string name);
    }
}