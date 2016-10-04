using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_ShouldReturnNewProcryon_WhenCommandIsValid()
        {
            //Arrange
            var testFactory = new UnitsFactory();
            const string command = "create unit Procyon Gosho 1";

            //No need to Assert that the returned object is the same.
            //Just that it's an instance.
            //var mockProcryon = new Procyon(1, "Gosho");

            //Act
            var retUnit = testFactory.GetUnit(command);

            //Assert
            Assert.IsInstanceOf<Procyon>(retUnit);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLuyten_WhenCommandIsValid()
        {
            //Arrange
            var testFactory = new UnitsFactory();
            const string command = "create unit Luyten Pesho 2";

            //Act
            var retUnit = testFactory.GetUnit(command);

            //Assert
            Assert.IsInstanceOf<Luyten>(retUnit);
        }

        [Test]
        public void GetUnit_ShouldReturnNewLacaille_WhenCommandIsValid()
        {
            //Arrange
            var testFactory = new UnitsFactory();
            const string command = "create unit Lacaille Doncho 3";

            //Act
            var retUnit = testFactory.GetUnit(command);

            //Assert
            Assert.IsInstanceOf<Lacaille>(retUnit);
        }

        [TestCase("create unit Doncho 1")]
        [TestCase("create unit Procyon Gosho Doncho")]
        [TestCase("create unit 1")]
        [TestCase("create notAUnit Procyon Doncho NotADigit")]
        [TestCase("create notAUnit 1 Doncho 2")]
        [TestCase("create notAUnit Procryon 23 2")]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenCommandIsInvalid(string command)
        {
            //Arrange
            var testFactory = new UnitsFactory();

            //Act and Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => testFactory.GetUnit(command));
        }


    }
}
