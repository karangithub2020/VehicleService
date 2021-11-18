using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleService.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleService.Controllers
{
    [Controller]
    [EnableCors("CorsPolicy")]
    [Route("api/vehicles")]
    public class VehicleController : ControllerBase
    {
        IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {
         return  _vehicleService.VehicleGetAll();
        }


        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(int id) => _vehicleService.VehicleGetById(id);

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Vehicle newVehicle)
        {
            if(string.IsNullOrEmpty(newVehicle.Make) || string.IsNullOrEmpty(newVehicle.Model) || newVehicle.Year < 1900) //some kind of validation
            {
                return BadRequest(); // error response
            }

            return _vehicleService.VehicleCreate(newVehicle) ? true : false;
        }

        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put(int id, [FromBody] Vehicle vehicle)
        {
            if(_vehicleService.VehicleGetById(id) != null )
            {
                vehicle.Id = id; // To make sure id is correct on vehicle object being updated
              return  _vehicleService.VehicleModify(vehicle);
            }

            return BadRequest(); // error response
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_vehicleService.VehicleGetById(id) != null)
            {
                return _vehicleService.VehicleRemove(id);
            }

            return BadRequest(); // error response
        }
    }
}
