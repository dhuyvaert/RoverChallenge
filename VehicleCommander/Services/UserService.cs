using System;
using System.Collections.Generic;
using VehicleCommander.Constants;
using VehicleCommander.Models;
using VehicleCommander.Utility;

namespace VehicleCommander.Services
{
    public class UserService
    {
        private AreaServices areaServices { get; set; }
        private LocationService locationService { get; set; }
        private VehicleServices vehicleServices { get; set; }
        private MovementService movementServices { get; set; }
        private Area plateau { get; set; }
        private List<Rover> rovers { get; set; }
        public UserService()
        {
            areaServices = new AreaServices();
            locationService = new LocationService();
            vehicleServices = new VehicleServices();
            movementServices = new MovementService();
            rovers = new List<Rover>();
        }
        public void SetArea()
        {
            Console.WriteLine("Enter the area coordinates. e.x. 4 4. Whole numbers only with a space between the X axis and Y axis.");
            var area = Console.ReadLine();
            var validLocation = locationService.ParseLocationCommand(area);
            if (validLocation.Success)
            {
                var response = areaServices.SetArea(validLocation.Data.XLocation, validLocation.Data.YLocation);
                if (response.Success)
                {
                    plateau = response.Data;
                    Console.WriteLine("Area has been set!");
                }
                else
                {
                    Console.WriteLine(response.ErrorMessage);
                    SetArea();
                }
            }
            else
            {
                Console.WriteLine(validLocation.ErrorMessage);
                SetArea();
            }
        }
        public void AddVehicles(int vehicleCount)
        {
            for(int i = 0; i < vehicleCount; i++)
            {
                var rover = tryAddVehicle(i);
                DisplayUtility.DisplayUserMessage("has been created!", rover.VehicleName);
                var roverWithCommands = tryAddMovementCommands(rover);
                rovers.Add(roverWithCommands); 
                DisplayUtility.DisplayUserMessage("movement commands have been added!", rover.VehicleName);
            }
           
        }
        private Rover tryAddVehicle(int i)
        {
            var addVehicle = getVehicleInformation();
            var vehicle = vehicleServices.CreateVehicle(addVehicle, i.ToString());
            if (vehicle.Success)
            {
                if (!areaServices.IsWithinBoundary(vehicle.Data.VehicleLocation.XLocation, vehicle.Data.VehicleLocation.YLocation, plateau))
                {
                    DisplayUtility.DisplayUserMessage(ErrorCodes.VEHICLE_OUTSIDE_BOUNDARY, vehicle.Data?.VehicleName);
                    vehicle.Data = tryAddVehicle(i);
                }
            }
            else
            {
                DisplayUtility.DisplayUserMessage(ErrorCodes.INVALID_VEHICLE_LOCATION, vehicle.Data?.VehicleName);
                vehicle.Data = tryAddVehicle(i);
            }
            return vehicle.Data;
        }
        private Rover tryAddMovementCommands(Rover rover)
        {
            var movementCommands = getVehicleMovement(rover.VehicleName);
            if (!Validation.ValidateMovementCommands(movementCommands))
            {
                DisplayUtility.DisplayUserMessage(ErrorCodes.INVALID_MOVEMENT_COMMAND, rover?.VehicleName);
                tryAddMovementCommands(rover);
            }
            var movementCommandSet = vehicleServices.SetMovementCommands(rover, movementCommands);
            if (!movementCommandSet.Success)
            {
                DisplayUtility.DisplayUserMessage(ErrorCodes.INVALID_MOVEMENT_COMMAND, rover?.VehicleName);
                tryAddMovementCommands(rover);
            }
            return movementCommandSet.Data;
        }
        private string getVehicleInformation()
        {
            Console.WriteLine($"Enter the initial location for this vehicle");
            return Console.ReadLine();
        }
        private string getVehicleMovement(string vehicleName)
        {
            Console.WriteLine($"Enter the movement commands for vehicle {vehicleName}");
            return Console.ReadLine();

        }
        public void MoveVehicles()
        {
            foreach (var rover in rovers)
            {
                rover.VehicleLocation = tryMoveRover(rover);
                Console.WriteLine($"Rover {rover.VehicleName} moved to final location of {rover.VehicleLocation.XLocation} {rover.VehicleLocation.YLocation} {rover.VehicleLocation.Direction}");
            }
        }
        private Location tryMoveRover(Rover rover)
        {
            var roverMovement = movementServices.MoveVehicle(rover, plateau);
            if (roverMovement.Success)
            {
                rover.VehicleLocation = roverMovement.Data;
                DisplayUtility.DisplayUserMessage("movement completed!", rover.VehicleName);
            }
            else
            {
                rover.VehicleLocation = roverMovement.Data;
                DisplayUtility.DisplayUserMessage(roverMovement.ErrorMessage, rover.VehicleName);
                tryAddMovementCommands(rover);
                rover.VehicleLocation = tryMoveRover(rover);
            }
            
            return rover.VehicleLocation;
        }
    }
}
