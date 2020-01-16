namespace InputValidaotrs.Decorators
{
    using Interfaces;

    public class PasswordSecurityValidator : BaseDecorator
    {
        public PasswordSecurityValidator(IValidator validator) 
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

                    if (char.IsSymbol(symbol))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
