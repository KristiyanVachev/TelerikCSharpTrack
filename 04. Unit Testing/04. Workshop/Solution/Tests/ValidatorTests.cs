using System;
using System.Security.Cryptography.X509Certificates;
using Cosmetics.Common;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ShouldThrow_WhenObjIsNUll()
        {
            //Arrange
            object nullObject = null;
            //Act

            //Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(nullObject));
        }

        [Test]
        public void CheckIfNull_ShouldNotThrow_WhenObjIsNotNull()
        {
            //Arrange
            object validObject = new object();

            //Act and Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(validObject));
        }

        [TestCase(null)]
        [TestCase((""))]
        public void CheckIfStringIsNullOrEmtpy_ShouldThrow_WhenTestIsNullOrEmpty(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrow_WhenTestIsNotNullOrEmpty()
        {
            string text = "poop";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        //Is it right do split it in two methods or not
        [TestCase("poop", 3, 0)]
        [TestCase("poop", 10, 5)]
        public void CheckIfStringLengthIsValid_shouldThrow_WhenTextLenghtIsLowerOrHigher(string text, int max, int min)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_shouldNotThrow_WhenTextLenghtIsValid()
        {
            
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("poop", 4, 0));
        }
    }
}
