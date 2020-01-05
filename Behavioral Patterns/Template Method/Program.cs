namespace Template_Method
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var androidBuilder = new AndroidBuilder();
            androidBuilder.Build();

            var iosBuilder = new IosBuilder();
            iosBuilder.Build();
        }
    }
}
