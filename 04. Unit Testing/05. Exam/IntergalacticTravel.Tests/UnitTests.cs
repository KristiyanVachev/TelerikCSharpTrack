using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_ShouldThrowNullReferenceException_WhenPassedObjectIsNull()
        {
            //Arrange
            var testUnit = new Unit(1, "Koala");

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testUnit.Pay(null));
        }

        [Test]
        public void Pay_ShouldDecreeseOwnersResoursesByAmoutOfCost_WhenPassedResourcesAreValid()
        {
            //Arrange
            var testUnit = new Unit(1, "Koala");
            testUnit.Resources.GoldCoins = 10;
            testUnit.Resources.SilverCoins = 15;
            testUnit.Resources.BronzeCoins = 10;

            const uint costAmount = 5;
            var cost = new Resources(costAmount, costAmount, costAmount);

            //Act
            testUnit.Pay(cost);

            //Assert
            Assert.AreEqual(5, testUnit.Resources.GoldCoins);
            Assert.AreEqual(10, testUnit.Resources.SilverCoins);
            Assert.AreEqual(5, testUnit.Resources.BronzeCoins);
        }

        [Test]
        public void Pay_ShouldReturnCostResources_WhenPassedResourcesAreValid()
        {
            //Arrange
            var testUnit = new Unit(1, "Koala");

            const uint costAmount = 5;
            var cost = new Resources(costAmount, costAmount, costAmount);

            //Act
            var retResources = testUnit.Pay(cost);

            //Assert
            Assert.AreEqual(costAmount, retResources.GoldCoins);
            Assert.AreEqual(costAmount, retResources.SilverCoins);
            Assert.AreEqual(costAmount, retResources.BronzeCoins);
        }
    }
}
