using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Abstracts
{
    //Vehicle interface
   public interface IVehicleService
    {
        public List<Vehicle> VehicleGetAll();
        public Vehicle VehicleGetById(int id);
        public bool VehicleCreate(Vehicle vehicle);
        public Vehicle VehicleModify(Vehicle vehicle);
        public bool VehicleRemove(int id);
    }
}
