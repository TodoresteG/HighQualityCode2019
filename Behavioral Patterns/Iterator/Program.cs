namespace Iterator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stations = new StationList();
            var station1 = new RadioStation(89);
            stations.Add(station1);

            var station2 = new RadioStation(101);
            stations.Add(station2);

            var station3 = new RadioStation(102);
            stations.Add(station3);

            foreach (var radioStation in stations)
            {
                Console.WriteLine("Radio frequency is " + radioStation.GetFrequency());
            }

            var q = stations.Where(x => x.GetFrequency() == 89).FirstOrDefault();
            Console.WriteLine("Searched Frequency is " + q.GetFrequency());
        }
    }
}
