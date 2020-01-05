namespace Observer
{
    using System;
    using System.Collections.Generic;

    internal class Unsubscriber<JobPost> : IDisposable
    {
        private List<IObserver<JobPost>> observers;
        private IObserver<JobPost> observer;

        public Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (this.observers.Contains(this.observer))
            {
                this.observers.Remove(this.observer);
            }
        }
    }
}
