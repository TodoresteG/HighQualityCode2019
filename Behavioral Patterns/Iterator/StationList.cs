namespace Iterator
{
    using System.Collections;
    using System.Collections.Generic;

    public class StationList : IEnumerable<RadioStation>
    {
        private List<RadioStation> stations;

        public StationList()
        {
            this.stations = new List<RadioStation>();
        }

        public RadioStation this[int index] 
        {
            get { return this.stations[index]; }
            set { this.stations.Insert(index, value); }
        }

        public void Add(RadioStation radioStation) 
        {
            this.stations.Add(radioStation);
        }

        public void Remove(RadioStation radioStation) 
        {
            this.stations.Remove(radioStation);
        } 

        public IEnumerator<RadioStation> GetEnumerator()
        {
            for (int i = 0; i < this.stations.Count; i++)
            {
                yield return this.stations[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
