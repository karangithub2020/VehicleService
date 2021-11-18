using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Abstracts
{
   public interface IVehicleRepository
    {
        public List<Vehicle> GetAllVehicles();
        public Vehicle GetVehicleById(int id);
        public bool InsertVehicle(Vehicle vehicle);
        public Vehicle UpdateVehicle(Vehicle vehicle);
        public bool DeleteVehicleById(int id);
    }
}
