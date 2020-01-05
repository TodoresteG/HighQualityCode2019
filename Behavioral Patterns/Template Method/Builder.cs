namespace Template_Method
{
    public abstract class Builder
    {
        // Template method
        public void Build() 
        {
            this.Test();
            this.Lint();
            this.Assemble();
            this.Deploy();
        }

        abstract public void Test();

        abstract public void Lint();

        abstract public void Assemble();

        abstract public void Deploy();
    }
}
