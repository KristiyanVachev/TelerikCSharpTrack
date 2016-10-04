namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    
    [TestFixture]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
            // : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [OneTimeSetUp]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [Test]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            //var model = (Car)this.GetModel(() => this.controller.Add(null));
           Assert.Throws<ArgumentNullException>((() => this.controller.Add(null)));
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            //var model = (Car)this.GetModel(() => this.controller.Add(car));
            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            //var model = (Car)this.GetModel(() => this.controller.Add(car));
            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
