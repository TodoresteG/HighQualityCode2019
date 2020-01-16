namespace CSharpCompiler.ValidationStrategies
{
    using Contracts;
    using Exceptions;

    public class CodeLengthValidator : ICodeValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (codeString.Length < 20)
            {
                throw new CompilationException("Code must be at least 20 charactesr long");
            }
        }
    }
}
