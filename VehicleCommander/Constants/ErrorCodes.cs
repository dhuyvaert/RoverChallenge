using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCommander.Constants
{
    public static class ErrorCodes
    {
        public const string INVALID_MOVEMENT_COMMAND = "Invalid move command. Vehicle did not move.";
        public const string INVALID_MOVEMENT_COMMAND_SET = "Invalid move command. Cannot set vehicle movements.";
        public const string INVALID_TURN_COMMAND = "Invalid turn command. Vehicle did not make a turn.";
        public const string OUTSIDE_BOUNDARY_MOVEMENT = "Movement would place this vehicle outside of the boundary. Vehicle was not moved. Please re-enter movement commands for this vehicle.";
        public const string OUTSIDE_BOUNDARY_SET = "Location is outside of the boundary. Location not set";
        public const string VEHICLE_OUTSIDE_BOUNDARY = "Location would place this vehicle outside of the boundary. Please re-enter initial location for this vehicle.";
        public const string INVALID_LOCATION = "Location must be 0 or greater and contain an X axis and Y axis value.";
        public const string INVALID_VEHICLE_LOCATION = "Invalid vehicle location. Please enter the initial location for the vehicle. (X location, Y location, Direction) e.x. 3 4 S";
        
    }
}
