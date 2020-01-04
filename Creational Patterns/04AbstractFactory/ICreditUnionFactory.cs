namespace AbstractFactory
{
    public interface ICreditUnionFactory
    {
        ISavingsAccount CreateSavingsAccount();

        ILoanAccount CreateLoanAccount();
    }
}