using VehicleCommander.Enums;

namespace VehicleCommander.Models
{
    public class Location
    {
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public CardinalDirection Direction { get; set; }
        public Location(int xLocation, int yLocation, CardinalDirection direction)
        {
            XLocation = xLocation;
            YLocation = yLocation;
            Direction = direction;
        }
    }
}
