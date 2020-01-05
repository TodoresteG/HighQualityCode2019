namespace Iterator
{
    public class RadioStation
    {
        private float frequency;

        public RadioStation(float frequency)
        {
            this.frequency = frequency;
        }

        public float GetFrequency() 
        {
            return this.frequency;
        }
    }
}
