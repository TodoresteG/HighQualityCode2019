namespace _031FactoryMethod
{
    public abstract class HiringManager
    {
        abstract protected IInterviewer MakeInterviewer();

        public string TakeInterview() 
        {
            IInterviewer interviewer = this.MakeInterviewer();

            return interviewer.AskQuestions();
        }
    }
}
