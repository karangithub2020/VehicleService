using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleService.Models;

namespace VehicleServiceTest.Mock
{
    internal class MockVehicleRepository : IVehicleRepository
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        public MockVehicleRepository()
        {
            vehicles.Add(new Vehicle { Id = 10001, Year = 2010, Make = "Honda", Model = "Civic" });
            vehicles.Add(new Vehicle { Id = 10002, Year = 2020, Make = "Nisan", Model = "Path Finder" });
            vehicles.Add(new Vehicle { Id = 10003, Year = 1988, Make = "Audi", Model = "A3" });
            vehicles.Add(new Vehicle { Id = 10004, Year = 1999, Make = "Audi", Model = "A4" });
           
        }

        public bool DeleteVehicleById(int id)
        {
          return  vehicles.Remove(vehicles.Find(v => v.Id == id));
           
        }

        public List<Vehicle> GetAllVehicles()
        {
            return vehicles;
        }

        public Vehicle GetVehicleById(int id)
        {
            return vehicles.Find(v => v.Id == id);
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            return true;
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            var _vehicle = vehicles.Find(v => v.Id == vehicle.Id);
            if(_vehicle is not null)
            {
                _vehicle = vehicle;
            }

            return _vehicle;
        }
    }
}
