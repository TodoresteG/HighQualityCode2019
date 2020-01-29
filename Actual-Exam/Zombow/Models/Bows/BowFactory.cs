namespace Zombow.Models.Bows
{
    using Contracts;

    using System;
    public class BowFactory : IBowFactory
    {
        public IBow CreateBow(string type, string name)
        {
            switch (type)
            {
                case "Takedown":
                    return new Takedown(name);
                case "Recurve":
                    return new Recurve(name);
                default:
                    throw new ArgumentException("Invalid bow type!");
            }
        }
    }
}
