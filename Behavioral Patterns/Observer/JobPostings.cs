namespace Observer
{
    using System;
    using System.Collections.Generic;

    public class JobPostings : IObservable<JobPost>
    {
        private List<IObserver<JobPost>> observers;
        private List<JobPost> jobPosts;

        public JobPostings()
        {
            this.observers = new List<IObserver<JobPost>>();
            this.jobPosts = new List<JobPost>();
        }

        public IDisposable Subscribe(IObserver<JobPost> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!this.observers.Contains(observer))
            {
                this.observers.Add(observer);
            }

            return new Unsubscriber<JobPost>(this.observers, observer);
        }

        public void AddJob(JobPost jobPost) 
        {
            this.jobPosts.Add(jobPost);
            this.Notify(jobPost);
        }

        private void Notify(JobPost jobPost) 
        {
            foreach (var observer in this.observers)
            {
                observer.OnNext(jobPost);
            }
        }
    }
}
