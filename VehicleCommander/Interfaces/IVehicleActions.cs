using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommander.Models;

namespace VehicleCommander.Interfaces
{
    public interface IVehicleActions<T>
    {
        Result<T> CreateVehicle(string vehicleCommand, string vehicleName);
    }
}
