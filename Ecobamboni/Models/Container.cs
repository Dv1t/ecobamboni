namespace Ecobamboni.Models
{
    public class Container
    {
        public readonly int ID;
        public string Location;
        public bool Fullness;

        public Container(int id, string location)
        {
            ID = id;
            Location = location;
            Fullness = false;
        }
    }
}