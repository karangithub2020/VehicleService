using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleService.Models;

namespace VehicleService.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly InMemoryContext _memoryContext;
        public InMemoryVehicleRepository(InMemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
        }
        public bool DeleteVehicleById(int id)
        {
            bool isDeleted = _memoryContext.DeleteVehicleRecord(id);
            if (isDeleted)
            {
                _memoryContext.SaveChanges();
            }

            return isDeleted;
        }

        public List<Vehicle> GetAllVehicles() => _memoryContext.GetVehicles();

        public Vehicle GetVehicleById(int id) => _memoryContext.GetVehicleById(id);

        public bool InsertVehicle(Vehicle vehicle)
        {
            if (_memoryContext.AddVehicleRecord(vehicle))
            {
                return _memoryContext.SaveChanges() > 0;
            }

            return false;
        }


        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            var updatedVehicle = _memoryContext.UpdateVehicleRecord(vehicle);
            if (_memoryContext != null)
            {
                _memoryContext.SaveChanges(true);                
            }
            return updatedVehicle;
        }
    }

    public class InMemoryContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public InMemoryContext(DbContextOptions options) : base(options)
        {
            SetupVechileData();
        }

        public void SetupVechileData()
        {   
            if (Vehicles.Local.Count < 1) // initialize only for the first time //TODO: sometimes it is taking little longer to load the data from memory and savechange errors out with message that key already exists
            {
                //initializing some default data
                Vehicles.Add(new Vehicle { Id = 10001, Year = 2010, Make = "Honda", Model = "Civic" });
                Vehicles.Add(new Vehicle { Id = 10002, Year = 2020, Make = "Nisan", Model = "Path Finder" });
              //  SaveChanges();
            }
        }

        public List<Vehicle> GetVehicles() => Vehicles.Local.ToList();

        public Vehicle GetVehicleById(int id) => Vehicles.Local.Where(vehicle => vehicle.Id == id).FirstOrDefault(); //find vehicle and return

        public bool AddVehicleRecord(Vehicle newVehicle)
        {
            int seed = 10000;
            newVehicle.Id = (seed + Vehicles.Local.Count() + 1); //auto generating some kind of id
            Vehicles.Add(newVehicle);
            return ((Vehicles.Local.Where(vehicle => vehicle.Id == newVehicle.Id)).Count() >= 0); //confirm
        }

        public Vehicle UpdateVehicleRecord(Vehicle updatedVehicle)
        {
            var vehicleToUpdate = Vehicles.Local.Where(vehicle => vehicle.Id == updatedVehicle.Id).FirstOrDefault(); //find vehicle to update
            if (vehicleToUpdate != null)
            {
                vehicleToUpdate.Make = updatedVehicle.Make;
                vehicleToUpdate.Model = updatedVehicle.Model;
                vehicleToUpdate.Year = updatedVehicle.Year;
            }

            return vehicleToUpdate;
        }

        public bool DeleteVehicleRecord(int id)
        {
            var vehicleToDelete = Vehicles.Local.Where(vehicle => vehicle.Id == id).FirstOrDefault(); //find vehicle to delete
            if (vehicleToDelete != null)
            {
                Vehicles.Local.Remove(vehicleToDelete);
                return true;
            }
            return false;
        }
    }
}
