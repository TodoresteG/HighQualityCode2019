namespace Singleton
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = Logger.Instance;
            var secondLogger = Logger.Instance;

            Console.WriteLine(logger.GetHashCode() == secondLogger.GetHashCode());
        }
    }
}