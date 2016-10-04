using System;
using System.Collections.Generic;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Moq;
using NUnit.Framework;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [Test]
        public void CreateShampoo_ShouldThrowNullRefException_WhenPassedNameIsInvalid()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testFactory.CreateShampoo("" , "Nivea", 2M, GenderType.Men, 125, UsageType.EveryDay));
        }

        [TestCase("t")]
        [TestCase("Longeeeeeeeeeer")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedNameIsOutOfRange(string productName)
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => testFactory.CreateShampoo(productName, "Nivea", 2M, GenderType.Men, 125, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenPassedNameIsNullOrEmpty()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testFactory.CreateShampoo("Poop", "", 2M, GenderType.Men, 125, UsageType.EveryDay));
        }

        [TestCase("t")]
        [TestCase("Longeeeeeeeeeer")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenPassedBrandLenghtOutOfRange(string brand)
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => testFactory.CreateShampoo("Poop", brand, 2M, GenderType.Men, 125, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_ShouldReturnNewShampoo_WhenPassedParametersAreValid()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();
            //Act 
            var retShampoo = testFactory.CreateShampoo("White", "Poop", 2M, GenderType.Men, 125, UsageType.EveryDay);

            //Assert
            Assert.IsInstanceOf<IShampoo>(retShampoo);
        }

        [Test]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenNameIsNullOrEmpty()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testFactory.CreateCategory(""));
        }

        [TestCase("s")]
        [TestCase("loooooooooooooog")]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_WhenNameIsShorterThan3orLongerThan10(string categoryName)
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => testFactory.CreateCategory(categoryName));
        }

        [Test]
        public void CreateCategory_ShouldReturnNewCategory_WhenPassedParametersAreValid()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();
            //Act 
            var retCategory = testFactory.CreateCategory("Poops");

            //Assert
            Assert.IsInstanceOf<ICategory>(retCategory);
        }

        [Test]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenNameIsNullOrEmpty()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testFactory.CreateToothpaste("", "Koala", 2.5M, GenderType.Unisex, new List<string>() { "poop", "eucalyptus" }));
        }

        [TestCase("t")]
        [TestCase("Longeeeeeeeeeer")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenPassedNameIsOutOfRange(string productName)
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => testFactory.CreateToothpaste(productName, "Koala", 2.5M, GenderType.Unisex, new List<string>() { "poop", "eucalyptus" }));
        }

        [Test]
        public void CreateTootpaste_ShouldThrowNullReferenceException_WhenPassedBrandIsNullOrEmpty()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => testFactory.CreateToothpaste("Poop", "", 2.5M, GenderType.Unisex, new List<string>() { "poop", "eucalyptus" }));
        }

        [TestCase("t")]
        [TestCase("Longeeeeeeeeeer")]
        public void CreateTootpaste_ShouldThrowIndexOutOfRangeException_WhenPassedBrandLenghtOutOfRange(string brand)
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => testFactory.CreateToothpaste("Poop", brand, 2.5M, GenderType.Unisex, new List<string>() { "poop", "eucalyptus" }));
        }

        [Test]
        public void CreateTootpaste_ShouldReturnNewTootpaste_WhenPassedParametersAreValid()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();
            //Act 
            var retTootpaste = testFactory.CreateToothpaste("Poop", "Koala", 2.5M, GenderType.Unisex, new List<string>() { "poop", "eucalyptus" });

            //Assert
            Assert.IsInstanceOf<IToothpaste>(retTootpaste);
        }

        [Test]
        public void CreateTootpaste_ShouldThrowIndexOutOfRangeException_WhenAnyItemsNameIsOutOfRange()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act and Assert
            Assert.Throws<IndexOutOfRangeException>(
                () =>
                    testFactory.CreateToothpaste("Poop", "Koala", 12M, GenderType.Unisex,
                        new List<string>() {"po", "poop"}));
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnNewShopingCart_Always()
        {
            //Arrange
            var testFactory = new CosmeticsFactory();

            //Act
            var retShoppingCart = testFactory.CreateShoppingCart();

            //Assert
            Assert.IsInstanceOf<IShoppingCart>(retShoppingCart);
        }
    }
}
