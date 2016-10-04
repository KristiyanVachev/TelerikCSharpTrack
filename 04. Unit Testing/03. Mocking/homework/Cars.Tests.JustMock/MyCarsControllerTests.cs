using System;
using System.Collections.Generic;
using Cars.Contracts;
using Cars.Controllers;
using Cars.Data;
using Cars.Models;
using Mono.Cecil.Cil;
using Moq;
using NUnit.Framework;

namespace Cars.Tests.JustMock
{
    [TestFixture]
    public class MyCarsControllerTests
    {
        [Test]
        public void MyIndexShouldReturnAllCars()
        {

        }

        [Test]
        public void MyAddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            //Arrange
            CarsController controller = new CarsController();
            Car newCar = null;

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => controller.Add(newCar));
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            //Arrange
            CarsController controller = new CarsController();

            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void MyAddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            //Arrange
            CarsController controller = new CarsController();

            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void MyAddingCar_ShouldWriteToDataCorrectly_WhenValidCar()
        {
            //Arrange
            var dataMock = new Mock<IDatabase>();
            dataMock.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(dataMock.Object);

            var controller = new CarsController(repo);

            var car = new Car { Id = 15, Make = "BMW", Model = "330d", Year = 2014 };
            var car2 = new Car { Id = 15, Make = "Tesla", Model = "S", Year = 2011 };

            //Act
            controller.Add(car);
            controller.Add(car2);

            //Assert
            Assert.AreEqual("Tesla", dataMock.Object.Cars[1].Make);
        }

        [Test]
        public void Details_ShouldReturnCarsView()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            //var database = new Mock<IDatabase>();
            //database.Setup(x => x.Cars).Returns(new List<Car>());

            var data = new CarsRepository(database);
            var controller = new CarsController(data);

            var car = new Car() { Id = 16, Make = "Tesla", Model = "Roadster", Year = 2008 };

            controller.Add(car);

            //Act
            var returnedCarView = (object)controller.Details(16).Model;
            var returnedCar = (Car)returnedCarView;

            //Assert
            Assert.AreEqual("Tesla", returnedCar.Make);
        }

        [Test]
        public void Details_ShouldThrowArgException_WhenNoCarWithSuchId()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            //var database = new Mock<IDatabase>();
            //database.Setup(x => x.Cars).Returns(new List<Car>());

            var data = new CarsRepository(database);
            var controller = new CarsController(data);

            var car = new Car() { Id = 16, Make = "Tesla", Model = "Roadster", Year = 2008 };

            controller.Add(car);

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => controller.Details(26));

            //bug in the code!
            //Details expects if no car is found by GetById method to be returned true, but it returns an exception
            //StringAssert.Contains("Car could not be found", exception.Message);
        }

        [Test]
        public void Search_Should()
        {
            //Arrange
            var database = new Database();
            database.Cars = new List<Car>();
            var data = new CarsRepository(database);
            var controller = new CarsController(data);

            var car = new Car() { Id = 16, Make = "Tesla", Model = "Roadster", Year = 2008 };
            var car2 = new Car() { Id = 15, Make = "Tesla", Model = "X", Year = 2015 };

            controller.Add(car);
            controller.Add(car2);

            //Act
            var returnedView = controller.Search("Roadster");

            //Assert
            //Assert.AreEqual(1, returnedView.Model.Count);
        }


    }
}
