namespace CSharpCompiler
{
    using Contracts;
    using ValidationStrategies;

    using System.IO;

    class Program
    {
        private const string ProgramPath = "../../CSharpProgram.cs";
        private const string EntryClassName = "Strategy.Program";

        static void Main()
        {
            string code = File.ReadAllText(ProgramPath);

                                                      // new CodeLenghtValidatior();
            ICodeValidationStrategy validationStrategy = new SystemNetValidator();

            var compiler = new CSharpCompiler(validationStrategy);
            compiler.Compile(code);
            compiler.Execute(EntryClassName);
        }
    }
}
