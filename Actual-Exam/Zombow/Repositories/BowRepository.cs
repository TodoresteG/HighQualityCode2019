namespace Zombow.Repositories
{
    using Contracts;
    using Models.Bows.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class BowRepository : IRepository<IBow>
    {
        private readonly List<IBow> models;

        public BowRepository()
        {
            this.models = new List<IBow>();
        }

        public IReadOnlyCollection<IBow> Models =>
            this.models.AsReadOnly();

        public void Add(IBow model)
        {
            if (!this.models.Any(x => x.Name == model.Name))
            {
                this.models.Add(model);
            }
        }

        public IBow Find(string name)
        {
            IBow bow = this.models.FirstOrDefault(x => x.Name == name);
            return bow;
        }

        public bool Remove(IBow model)
        {
            return this.models.Remove(model);
        }
    }
}