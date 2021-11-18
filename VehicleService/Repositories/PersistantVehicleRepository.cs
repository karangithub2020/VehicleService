using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleService.Models;

namespace VehicleService.Repositories
{
    public class PersistantVehicleRepository : IVehicleRepository
    {
        string _connectionString = "";
        public PersistantVehicleRepository(string connectionString)
        {
            _connectionString = connectionString;
            //connect to db using connection string
        }
        //Implement some kind of persistant repository - sql or document db - mongo etc
        public bool DeleteVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public  List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
