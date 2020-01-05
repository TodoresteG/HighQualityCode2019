namespace Observer
{
    using System;

    public class JobSeeker : IObserver<JobPost>
    {
        public JobSeeker(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        //Method is not being called by JobPostings class currently
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        //Method is not being called by JobPostings class currently
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(JobPost value)
        {
            Console.WriteLine($"Hi {this.Name}! New job posted: {value.Title}");
        }
    }
}
