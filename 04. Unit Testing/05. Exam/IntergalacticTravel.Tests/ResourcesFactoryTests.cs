using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]

        public void GetResources_ShouldReturnNewResourcesCorrectly_WhenInputCommandIsValid(string command)
        {
            //Arrange
            var testFactory = new ResourcesFactory();

            //Act
            var retResource = testFactory.GetResources(command);

            //Assert
            Assert.AreEqual(20, retResource.GoldCoins);
            Assert.AreEqual(30, retResource.SilverCoins);
            Assert.AreEqual(40, retResource.BronzeCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_ShouldThrowInvalidOperationException_WhenInputCommandIsInvalid(string command)
        {
            //Arrange
            var testFactory = new ResourcesFactory();

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => testFactory.GetResources(command));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ShouldThrowOverflowException_WhenInputCommandIsValidButAnyOfValuesIsLargerThanIntMaxValue(string command)
        {
            //Arrange
            var testFactory = new ResourcesFactory();

            //Act and Assert
            Assert.Throws<OverflowException>(() => testFactory.GetResources(command));
        }
    }
}
