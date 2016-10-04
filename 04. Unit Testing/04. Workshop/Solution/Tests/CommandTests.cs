using System;
using NUnit.Framework;
using Cosmetics.Engine;


namespace Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ShouldReturnNewCommand_WhenInputStringIsValid()
        {
            Command returnCommand = Command.Parse("Something");

            Assert.IsInstanceOf<Command>(returnCommand);
        }

        [Test]
        public void Parse_ShouldSetCorrectValues_WhenInputStringIsCorrect()
        {
            //Arrange

            //Act
            var testCommand = Command.Parse("Demagorgon scary unreal");

            //Assert
            Assert.AreEqual("Demagorgon", testCommand.Name);
            Assert.AreEqual("scary", testCommand.Parameters[0]);
            Assert.AreEqual("unreal", testCommand.Parameters[1]);
        }

        [Test]
        public void Parse_ShouldThrow_WhenNameIsNullOrEmpty()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(""));
            Assert.That(ex.Message, Does.Contain("Name"));
        }

        [Test]
        public void Parse_ShouldThrow_WhenParamsAreNullOrEmpty()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse("Name "));
            Assert.That(ex.Message, Does.Contain("List"));
        }
    }
}
