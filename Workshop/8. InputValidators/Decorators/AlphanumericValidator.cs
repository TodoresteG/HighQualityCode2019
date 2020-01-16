namespace InputValidaotrs.Decorators
{
    using Interfaces;

    using System;

    public class AlphanumericValidator : BaseDecorator
    {
        public AlphanumericValidator(IValidator validator)
            : base(validator)
        {
        }

        public override bool Validate(string input)
        {
            if (this.validator.Validate(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char symbol = input[i];

                    if (!char.IsLetterOrDigit(symbol))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
