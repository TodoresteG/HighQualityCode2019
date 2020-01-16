namespace CSharpCompiler.Contracts
{
    public interface ICodeValidationStrategy
    {
        void Validate(string codeString);
    }
}
