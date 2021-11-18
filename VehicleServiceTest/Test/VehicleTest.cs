using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Abstracts;
using VehicleServiceTest.Mock;
using VehicleService.Services;
using VehicleService.Models;

namespace VehicleServiceTest.Test
{
    public class VehicleTest
    {
        StandardKernel kernel = new StandardKernel();
        IVehicleService vehicleService;

        [SetUp]
        public void Setup()
        {
            //setup //initialization //injecting mock object
            if (kernel.TryGet<IVehicleRepository>() is null) //To make sure it is registered only once and not for every test case
            {
                kernel.Bind<IVehicleRepository>().To<MockVehicleRepository>(); // all call of IVehicleRepository will be represented by MockVehicleRepository
                vehicleService = new VehicleService.Services.VehicleService(kernel.Get<IVehicleRepository>()); //inject mock repository for testing
            }

        }

        [Test]
        public void TestGetAllVehicle()
        {
            Assert.AreEqual(vehicleService.VehicleGetAll().Count, 4);
        }

        [Test]
        public void TestGetVehicleById()
        {

            //Arrange
            int id = 10003;
            string expectedMake = "Audi";
            string expectedModel = "A3";
            //Act
            var vehicle = vehicleService.VehicleGetById(id);

            Assert.IsTrue(vehicle is Vehicle); //Assert
            Assert.AreEqual(vehicle.Make, expectedMake); //Assert
            Assert.AreEqual(vehicle.Model, expectedModel); //Assert
        }

        [Test]
        public void TestNoVehicleFoundById()
        {

            //Arrange
            int id = 10009;
            var vehicle = vehicleService.VehicleGetById(id); //Act
            Assert.IsTrue(vehicle is null); //Assert

        }

        //Other positive & Negative test cases here.......
    }




}
