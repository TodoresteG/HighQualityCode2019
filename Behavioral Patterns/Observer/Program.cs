namespace Observer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Create Subscribers
            var johnDoe = new JobSeeker("John Doe");
            var janeDoe = new JobSeeker("Jane Doe");

            //Create publisher and attch subscribers
            var jobPostings = new JobPostings();
            jobPostings.Subscribe(johnDoe);
            jobPostings.Subscribe(janeDoe);

            //Add a new job and see if subscribers get notified
            jobPostings.AddJob(new JobPost("Software Engineer"));
        }
    }
}
