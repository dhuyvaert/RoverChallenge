using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommander.Models;

namespace VehicleCommander.Interfaces
{
    public interface IMovement
    {
        Result<Location> MoveVehicle(Rover rover, Area plateau);
        Result<Rover> Move(Rover rover);
        Result<Rover> Turn(Rover rover, string command);
    }
}
