namespace HAD.Core.Factory
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType, string name)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == heroType);

            IHero hero = Activator.CreateInstance(type, new object[] { name }) as IHero;

            if (hero == null)
            {
                throw new ArgumentException("Given hero type is not supported");
            }

            return hero;
        }
    }
}
