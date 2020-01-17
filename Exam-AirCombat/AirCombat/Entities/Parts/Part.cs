namespace AirCombat.Entities.Parts
{
    using Contracts;
    using Utils;

    using System;

    // TODO: maybe asbtract
    public abstract class Part : IPart
    {
        private string model;
        private double weight;
        private decimal price;

        public Part(string model, double weight, decimal price)
        {
            this.Model = model;
            this.Weight = weight;
            this.Price = price;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidModelPartMessage);
                }

                this.model = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.InvalidWeightPartMessage);
                }

                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.InvalidPricePartMessage);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            // TODO: use stringBuilder

            string partName = this.GetType().Name.Replace("Part", "");
            string result = $"{partName} Part - {this.Model}";

            //if (this.Type == "ArsenalPart")
            //{
            //    result += $"+{this.Modifier} Attack";
            //}
            //else if (this.Type == "EndurancePart")
            //{
            //    result += $"+{this.Modifier} HitPoints";
            //}
            //else if (this.Type == "ShellPart")
            //{
            //    result += $"+{this.Modifier} Defense";
            //}

            return result;
        }
    }
}