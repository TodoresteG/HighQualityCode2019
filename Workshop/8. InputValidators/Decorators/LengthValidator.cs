namespace InputValidaotrs.Decorators
{
    using Interfaces;

    public class LengthValidator : BaseDecorator
    {
        private int minLength;
        private int maxLength;

        public LengthValidator(IValidator validator, int minLength, int maxLength) 
            : base(validator)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public override bool Validate(string input)
        {
            if (this.validator.Validate(input))
            {
                return input.Length >= this.minLength && input.Length <= this.maxLength;
            }

            return false;
        }
    }
}
