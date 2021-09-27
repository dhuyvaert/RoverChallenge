namespace VehicleCommander.Models
{
    public class Rover
    {
        public string VehicleName { get; set; }
        public Location VehicleLocation { get; set; }
        public char[] MovementCommands { get; set; }
    }
}
