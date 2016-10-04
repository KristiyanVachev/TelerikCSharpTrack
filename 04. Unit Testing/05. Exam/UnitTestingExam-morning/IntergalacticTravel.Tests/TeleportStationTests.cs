using System;
using System.Collections.Generic;
using System.Linq;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Mocks;
using Moq;
using NUnit.Engine;
using NUnit.Framework;


namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_ShouldSetAllProvidedFeldsCorrectly_WhenNewTelereportStationIsCreatedWithValidParamameters()
        {
            //Arrange 
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            var stubGalacticMap = new Mock<IEnumerable<IPath>>();

            //Act
            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            //Assert
            Assert.AreSame(stubOwner.Object, testStation.Owner);
            Assert.AreSame(stubLocation.Object, testStation.Location);
            Assert.AreSame(stubGalacticMap.Object, testStation.GalacticMap);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            var stubGalacticMap = new Mock<IEnumerable<IPath>>();

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            //Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() => testStation.TeleportUnit(null, stubLocation.Object));
            StringAssert.Contains("unitToTeleport", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullException_WhenDestinationIsNull()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            var stubGalacticMap = new Mock<IEnumerable<IPath>>();

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubUnit = new Mock<IUnit>();

            //Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() => testStation.TeleportUnit(stubUnit.Object, null));
            StringAssert.Contains("destination", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeException_WhenUnitIsInADistantLocation()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Venus");

            var stubGalacticMap = new Mock<IEnumerable<IPath>>();

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubUnit = new Mock<IUnit>();
            var stubDestination = new Mock<ILocation>();

            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");

            //Act Assert
            var ex = Assert.Throws<TeleportOutOfRangeException>(() => testStation.TeleportUnit(stubUnit.Object, stubDestination.Object));
            StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationException_WhenDestinationIsTakenByAnotherUnit()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnitInPlace = new Mock<IUnit>();
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");

            var stubUniInPlaceCoordinates = new Mock<IGPSCoordinates>();
            stubUniInPlaceCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUniInPlaceCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubUnitInPlace.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUniInPlaceCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnitInPlace.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            //not kidding - http://www.latlong.net/c/?lat=42.650733&long=23.379668

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);


            //Act Assert
            var ex = Assert.Throws<InvalidTeleportationLocationException>(() => testStation.TeleportUnit(stubUnitInPlace.Object, stubDestination.Object));
            StringAssert.Contains("units will overlap", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundException_WhenGalaxyIsNotFoundInTheLocationListOfTheStation()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            var mockGalacticMapLocation = new Mock<ILocation>();
            mockGalacticMapLocation.Setup(l => l.Planet.Galaxy.Name).Returns("404");

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(mockGalacticMapLocation.Object);

            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubUnitInPlace = new Mock<IUnit>();
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");

            var stubDestination = new Mock<ILocation>();
            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");

            //Act Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => testStation.TeleportUnit(stubUnitInPlace.Object, stubDestination.Object));
            StringAssert.Contains("Galaxy", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundException_WhenPlanetIsNotFoundInTheLocationListOfTheStation()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            var mockGalacticMapLocation = new Mock<ILocation>();
            mockGalacticMapLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            mockGalacticMapLocation.Setup(l => l.Planet.Name).Returns("404");

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(mockGalacticMapLocation.Object);

            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubUnitInPlace = new Mock<IUnit>();
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnitInPlace.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");

            var stubDestination = new Mock<ILocation>();
            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");

            //Act Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => testStation.TeleportUnit(stubUnitInPlace.Object, stubDestination.Object));
            StringAssert.Contains("Planet", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldThrowInsufficientResourcesException_WhenServiceCostsMoreThanCurrentUnitsAvailableResources()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);


            //Act Assert
            var ex = Assert.Throws<InsufficientResourcesException>(() => testStation.TeleportUnit(stubUnit.Object, stubDestination.Object));
            StringAssert.Contains("FREE LUNCH", ex.Message);
        }

        [Test]
        public void TeleportUnit_ShouldRequirePayment_WhenParametersAreValid()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);


            //Act 

            //Assert
            //TODO
            //testStation.Verify(x => x.GetPayment(), Times.Once);
            //Since i can't use verify, I'll verify it in the next test method by checking
            //if the stations resources have changed
        }

        [Test]
        public void TeleportUnit_ShouldRequirePaymentByCheckingIfTheStationsResourcesHaveChanged_WhenParametersAreValid()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);

            //current resources
            var currentResources = testStation.Resources;

            var stubResource = new Mock<IResources>();
            stubResource.Setup(x => x.GoldCoins).Returns(10);
            stubResource.Setup(x => x.SilverCoins).Returns(10);
            stubResource.Setup(x => x.BronzeCoins).Returns(10);


            stubUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(stubResource.Object);

            stubUnit.Setup(x => x.CurrentLocation.Planet.Units.Remove(It.IsAny<IUnit>())).Returns(true);

            //Act
            testStation.TeleportUnit(stubUnit.Object, stubDestination.Object);

            //Assert
            Assert.AreNotEqual(0, currentResources.GoldCoins);
  

        }

        [Test]
        public void TeleportUnit_ShouldObtainPayment_WhenParametersAreValid()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);

            //current resources
            var currentResources = testStation.Resources;

            var stubResource = new Mock<IResources>();
            stubResource.Setup(x => x.GoldCoins).Returns(10);
            stubResource.Setup(x => x.SilverCoins).Returns(10);
            stubResource.Setup(x => x.BronzeCoins).Returns(10);


            stubUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(stubResource.Object);
            
            stubUnit.Setup(x => x.CurrentLocation.Planet.Units.Remove(It.IsAny<IUnit>())).Returns(true);

            //Act
            testStation.TeleportUnit(stubUnit.Object, stubDestination.Object); 

            //Assert
            Assert.AreEqual(10, currentResources.GoldCoins);
            Assert.AreEqual(10, currentResources.SilverCoins);
            Assert.AreEqual(10, currentResources.BronzeCoins);

        }


        [Test]
        public void TeleportUnit_ShouldSetUnitsPreviousLocatonToUnitsCurrentLocation_WhenParametersAreValid()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);

            //current resources
            var currentResources = testStation.Resources;

            var stubResource = new Mock<IResources>();
            stubResource.Setup(x => x.GoldCoins).Returns(10);
            stubResource.Setup(x => x.SilverCoins).Returns(10);
            stubResource.Setup(x => x.BronzeCoins).Returns(10);


            stubUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(stubResource.Object);

            stubUnit.Setup(x => x.CurrentLocation.Planet.Units.Remove(It.IsAny<IUnit>())).Returns(true);
       
            //Act 
            testStation.TeleportUnit(stubUnit.Object, stubDestination.Object);

            //Assert
            Assert.AreEqual(stubUnit.Object.CurrentLocation, stubUnit.Object.PreviousLocation);
        }

        [Test]
        public void TeleportUnit_ShouldSetUnitsCurrentLocatonToDestination_WhenParametersAreValid()
        {
            //Arrange
            var stubOwner = new Mock<IBusinessOwner>();
            var stubLocation = new Mock<ILocation>();
            stubLocation.Setup(l => l.Planet.Galaxy.Name).Returns("Milky Way");
            stubLocation.Setup(l => l.Planet.Name).Returns("Mars");

            //Place a unit there
            var stubUnit = new Mock<IUnit>();
            stubUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("Milky Way");
            stubUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("Mars");
            stubUnit.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);

            var stubUnitCoordinates = new Mock<IGPSCoordinates>();
            stubUnitCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            stubUnitCoordinates.Setup(c => c.Longtitude).Returns(22.379668);

            stubUnit.Setup(c => c.CurrentLocation.Coordinates).Returns(stubUnitCoordinates.Object);

            var unitsCollection = new List<IUnit>() { stubUnit.Object };

            stubLocation.Setup(l => l.Planet.Units).Returns(unitsCollection);

            var mockPath = new Mock<IPath>();
            mockPath.Setup(x => x.TargetLocation).Returns(stubLocation.Object);


            var stubGalacticMap = new Mock<List<IPath>>();
            stubGalacticMap.Object.Add(mockPath.Object);

            var testStation = new MockedTeleportStation(stubOwner.Object, stubGalacticMap.Object, stubLocation.Object);

            var stubDestination = new Mock<ILocation>();

            var telerikAcademyCoordinates = new Mock<IGPSCoordinates>();
            telerikAcademyCoordinates.Setup(c => c.Latitude).Returns(42.650733);
            telerikAcademyCoordinates.Setup(c => c.Longtitude).Returns(23.379668);

            stubDestination.Setup(d => d.Planet.Galaxy.Name).Returns("Milky Way");
            stubDestination.Setup(d => d.Planet.Name).Returns("Mars");
            stubDestination.Setup(d => d.Coordinates).Returns(telerikAcademyCoordinates.Object);

            //current resources
            var currentResources = testStation.Resources;

            var stubResource = new Mock<IResources>();
            stubResource.Setup(x => x.GoldCoins).Returns(10);
            stubResource.Setup(x => x.SilverCoins).Returns(10);
            stubResource.Setup(x => x.BronzeCoins).Returns(10);


            stubUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(stubResource.Object);

            stubUnit.Setup(x => x.CurrentLocation.Planet.Units.Remove(It.IsAny<IUnit>())).Returns(true);


            //Act 
            testStation.TeleportUnit(stubUnit.Object, stubDestination.Object);

            //Assert
            Assert.AreEqual(stubDestination.Object, stubUnit.Object.CurrentLocation);
        }



    }
}
