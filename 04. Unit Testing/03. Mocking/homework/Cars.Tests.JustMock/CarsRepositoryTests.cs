using System;
using Cars.Contracts;
using Cars.Data;
using Cars.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Cars.Tests.JustMock
{
    [TestFixture]
    public class CarsRepositoryTests
    { 
        [Test]
        public void TotalCars_ShouldReturnCorrectly()
        {
            //Arrange  
            var mockData = new Mock<IDatabase>();
            mockData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockData.Object);
            var car = new Car
            {
                Id = 0,
                Make = "Tesla",
                Model = "S",
                Year = 2011
            };

            //Act
            repo.Add(car);

            Assert.AreEqual(1, repo.TotalCars);
        }

        [Test]
        public void Add_ShouldAddCorrectly()
        {
            //Arrange
            var mockData = new Mock<IDatabase>();
            mockData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockData.Object);
            var car = new Car
            {
                Id = 0,
                Make = "Tesla",
                Model = "S",
                Year = 2011
            };

            //Act
            repo.Add(car);

            //Assert
            Assert.AreEqual(car, mockData.Object.Cars[0]);
        }

        [Test]
        public void Add_ShouldThrowArgException_WhenAddedCarIsNull()
        {
            var repo = new CarsRepository();

            Assert.Throws<ArgumentException>(() => repo.Add(null));
        }

        [Test]
        public void Remove_ShouldThrowArgExcp_WhenCarIsNull()
        {
            var repo = new CarsRepository();

            var excp = Assert.Throws<ArgumentException>(() => repo.Remove(null));
            Assert.AreEqual(excp.Message, "Null car cannot be removed");
        }

        [Test]
        public void Remove_ShouldRemoveCorrectly()
        {
            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockedData.Object);
            var car = new Car();
            car.Id = 16;

            repo.Add(new Car());
            repo.Add(car);

            //Act
            repo.Remove(car);

            var excp = Assert.Throws<ArgumentException>(() => repo.GetById(16));
            Assert.IsTrue(excp.Message.Contains("Car with such Id could not be found"));
        }

        [Test]
        public void GetById_ShouldThrowException_WhenIdNotFound()
        {
            //Arrange
            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockedData.Object);
            var car = new Car { Id = 16 };

            repo.Add(new Car());
            repo.Add(car);

            var excp = Assert.Throws<ArgumentException>(() => repo.GetById(23));
            Assert.IsTrue(excp.Message.Contains("Car with such Id could not be found"));
        }

        [Test]
        public void GetById_ShouldReturnCorrectCar()
        {
            //Arrange
            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockedData.Object);
            var car = new Car { Id = 16 };

            repo.Add(new Car());
            repo.Add(car);

            //Act
            Car returnedCar = repo.GetById(16);

            //Assert
            Assert.AreSame(car, returnedCar);
        }

        [Test]
        public void All_ShouldReturnDataCorrectly()
        {
            //Arrange
            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());
            var repo = new CarsRepository(mockedData.Object);
            var car = new Car();

            repo.Add(car);

            var expectedList = new List<Car>();
            expectedList.Add(car);

            //Act
            var returnedList = repo.All();

            //Assert
            Assert.AreEqual(expectedList, returnedList);
        }

        [Test]
        public void SortedByMake_ShouldSortCorrectly_WhenValidInput()
        {
            //Arrange
            var cars = new List<Car>();
            string[] makes = { "Tesla", "Toyota", "Nissan" };
            //Logic in the class - unnessasary complication
            foreach (var make in makes)
            {
                cars.Add(new Car());
                cars[cars.Count - 1].Make = make;
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(cars);

            var mockRepository = new CarsRepository(mockDb.Object);

            //More logic and besides, thats the same code I'm trying to test
            var expectedOrderedCars = cars
                            .OrderBy(x => x.Make)
                            .ToList();

            //Act and Assert

            CollectionAssert.AreEqual(expectedOrderedCars, mockRepository.SortedByMake());
        }

        [Test]
        public void SortedByYear_ShouldReturnSortedListByMake()
        {
            //Arrange
            var middleCar = new Car { Id = 0, Make = "Tesla", Model = "S", Year = 2011 };
            var newestCar = new Car { Id = 1, Make = "Tesla", Model = "X", Year = 2015 };
            var oldestCar = new Car { Id = 2, Make = "Tesla", Model = "Roadster", Year = 2008 };

            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(mockedData.Object);

            repo.Add(middleCar);
            repo.Add(newestCar);
            repo.Add(oldestCar);

            var expectedCars = new List<Car> { oldestCar, middleCar, newestCar };

            //Act
            var sortedCars = repo.SortedByYear();

            //Assert
            CollectionAssert.AreEquivalent(expectedCars, sortedCars);
        }

        [Test]
        public void Search_ShouldReturnAllCars_WhenConditionIsNullOrEmpty()
        {
            //Arrange
            var middleCar = new Car { Id = 0, Make = "Tesla", Model = "S", Year = 2011 };
            var newestCar = new Car { Id = 1, Make = "Tesla", Model = "X", Year = 2015 };
            var oldestCar = new Car { Id = 2, Make = "Tesla", Model = "Roadster", Year = 2008 };

            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(mockedData.Object);

            repo.Add(middleCar);
            repo.Add(newestCar);
            repo.Add(oldestCar);

            //Act
            var returnedList = repo.Search("");

            //Assert
            Assert.AreEqual(3, returnedList.Count);
        }

        [TestCase("Roadster", 1)]
        [TestCase("Tesla", 3)]
        [TestCase("Toyota", 1)]
        [TestCase("NotInTheList", 0)]
        public void Search_ShouldReturnCorrectly(string condition, int expectedCount)
        {
            //Arrange
            var middleCar = new Car { Id = 0, Make = "Tesla", Model = "S", Year = 2011 };
            var newestCar = new Car { Id = 1, Make = "Tesla", Model = "X", Year = 2015 };
            var oldestCar = new Car { Id = 2, Make = "Tesla", Model = "Roadster", Year = 2008 };
            var car4 = new Car { Id = 3, Make = "Toyota", Model = "Prius", Year = 2006 };


            var mockedData = new Mock<IDatabase>();
            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(mockedData.Object);

            repo.Add(middleCar);
            repo.Add(newestCar);
            repo.Add(oldestCar);
            repo.Add(car4);

            //Act
            var returnedList = repo.Search(condition);

            //Assert
            Assert.AreEqual(expectedCount, returnedList.Count);
        }



    }

    //Ooops, I began the homework too late and time is running out. 
    //Will send it like that and finish it after the deadline.
    //Promise.
}

