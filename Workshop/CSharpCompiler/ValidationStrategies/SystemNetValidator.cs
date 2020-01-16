namespace CSharpCompiler.ValidationStrategies
{
    using Contracts;
    using Exceptions;

    public class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (!codeString.Contains("using System.Net"))
            {
                throw new CompilationException("Project is not using System.Net");
            }
        }
    }
}
