using System;
using System.Collections.Generic;
using VehicleCommander.Models;
using VehicleCommander.Services;

namespace VehicleCommander
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Mars Rover Command Center----------");
            Console.WriteLine("---------------------------------------------");
            var userServices = new UserService();

            userServices.SetArea();
            userServices.AddVehicles(2);
            userServices.MoveVehicles();

            Console.ReadLine();
        }
    }
}
