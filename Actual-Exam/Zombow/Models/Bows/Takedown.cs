namespace Zombow.Models.Bows
{
    public class Takedown : Bow
    {
        private const int DefaultQuiverCapacity = 50;
        private const int DefaultTotalArrows = 500;
        private const int DefaultShootedArrows = 5;

        public Takedown(string name)
            : base(name, DefaultQuiverCapacity, DefaultTotalArrows)
        {
        }

        protected override void Reload()
        {
            if (this.TotalArrows > 0)
            {
                this.QuiverCapacity += DefaultQuiverCapacity;
                this.TotalArrows -= DefaultQuiverCapacity;
            }
        }

        public override int Shoot()
        {
            if (this.QuiverCapacity == 0)
            {
                this.Reload();

                if (this.QuiverCapacity == 0)
                {
                    return 0;
                }
            }

            this.QuiverCapacity -= DefaultShootedArrows;
            return DefaultShootedArrows;
        }
    }
}

