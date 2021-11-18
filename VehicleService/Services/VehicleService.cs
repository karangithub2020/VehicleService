using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleService.Models;

namespace VehicleService.Services
{
    public class VehicleService : IVehicleService
    {
        IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public bool VehicleCreate(Vehicle vehicle) => _vehicleRepository.InsertVehicle(vehicle);        

        public List<Vehicle> VehicleGetAll() =>  _vehicleRepository.GetAllVehicles();

        public Vehicle VehicleGetById(int id) => _vehicleRepository.GetVehicleById(id);

        public Vehicle VehicleModify(Vehicle vehicle) => _vehicleRepository.UpdateVehicle(vehicle);

        public bool VehicleRemove(int id) => _vehicleRepository.DeleteVehicleById(id);        
    }
}
