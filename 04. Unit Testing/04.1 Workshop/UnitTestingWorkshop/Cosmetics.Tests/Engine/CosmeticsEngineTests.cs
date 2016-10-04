using System;
using System.Collections.Generic;
using System.IO;
using Cosmetics.Common;
using Cosmetics.Contracts;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Tests.Engine.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        //PrivateObjectTest
        [Test]
        public void Start_ShouldExecuteCreateCategory_WhenCommandIsValid()
        {
            //Assert
            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();
            var mockCommmandParser = new Mock<ICommandParser>();

            CosmeticsEngine testEngine = new CosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Name).Returns("CreateCategory");
            mockCommand.Setup(x => x.Parameters[0]).Returns("CategoryName");

            //Act
            PrivateObject obj = new PrivateObject(testEngine);
            var retVal = obj.Invoke("ProcessSingleCommand", mockCommand.Object);

            //Assert
            Assert.AreEqual("Category with name CategoryName was created!", retVal);
        }

        [Test]
        public void Start_ShouldCreateCategory_WhenInputStringInCorrectFormat()
        {
            //Arrange
            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Name).Returns("CreateCategory");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { "Koala" });

            var mockCommmandParser = new Mock<ICommandParser>();
            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var mockCategory = new Mock<ICategory>();
            mockCategory.Setup(x => x.Name).Returns("Koala");

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            mockCosmeticFactory.Setup(x => x.CreateCategory("Koala")).Returns(mockCategory.Object);

            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine =
                new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            //Act
            testEngine.Start();

            //Assert
            Assert.IsTrue(testEngine.Categories.ContainsKey("Koala"));
            Assert.AreSame(mockCategory.Object, testEngine.Categories["Koala"]);
        }

        [Test]
        public void Start_ShouldAddToCategory_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productToAdd = "Poop";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            mockCommand.Setup(x => x.Name).Returns("AddToCategory");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName, productToAdd });

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);
            testEngine.Products.Add(productToAdd, mockProduct.Object);

            //Act
            testEngine.Start();

            //Assert
            mockCategory.Verify(x => x.AddProduct(mockProduct.Object), Times.Once);
        }

        [Test]
        public void Start_ShouldRemoveFromCategory_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productName = "Poop";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            mockCommand.Setup(x => x.Name).Returns("RemoveFromCategory");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName, productName });

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);
            testEngine.Products.Add(productName, mockProduct.Object);

            //Act
            testEngine.Start();

            //Assert
            mockCategory.Verify(x => x.RemoveProduct(mockProduct.Object), Times.Once);
        }


        [Test]
        public void Start_ShouldExecuteShowCategory_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();

            mockCommand.Setup(x => x.Name).Returns("ShowCategory");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName });

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);

            //Act
            testEngine.Start();

            //Assert
            mockCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_ShouldExecuteCreateShampoo_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productName = "Poop";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IShampoo>();

            mockCommand.Setup(x => x.Name).Returns("CreateShampoo");
            mockCommand.Setup(x => x.Parameters).Returns(
                new List<string>() { productName, "Nivea", "0.50", "men", "500", "everyday" }
                );

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);

            mockCosmeticFactory.Setup(
                x => x.CreateShampoo(productName, "Nivea", 0.50M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(mockProduct.Object);

            //Act
            testEngine.Start();

            //Assert
            Assert.IsTrue(testEngine.Products.ContainsKey(productName));
            Assert.AreEqual(testEngine.Products[productName], mockProduct.Object);
        }

        [Test]
        public void Start_ShouldExecuteCreateToothpaste_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productName = "PoopWhite";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IToothpaste>();

            mockCommand.Setup(x => x.Name).Returns("CreateToothpaste");
            mockCommand.Setup(x => x.Parameters).Returns(
                new List<string>() { productName, "Colbranch", "15.50", "men", "fluor,bqla,golqma" }
                );

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);

            mockCosmeticFactory.Setup(
                x => x.CreateToothpaste(productName, "Colbranch", 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla", "golqma" }))
                .Returns(mockProduct.Object);

            //Act
            testEngine.Start();

            //Assert
            Assert.IsTrue(testEngine.Products.ContainsKey(productName));
            Assert.AreEqual(testEngine.Products[productName], mockProduct.Object);
        }

        [Test]
        public void Start_ShouldExecuteAddToShoppingCart_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productName = "PoopWhite";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            mockCommand.Setup(x => x.Name).Returns("AddToShoppingCart");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { productName });

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);
            testEngine.Products.Add(productName, mockProduct.Object);

            //Act
            testEngine.Start();

            //Assert
            mockShoppingCart.Verify(x => x.AddProduct(mockProduct.Object), Times.Once());
        }

        [Test]
        public void Start_ShouldExecuteRemoveFromShoppingCart_WhenInputStringInCorrectFormat()
        {
            //Arrange
            const string categoryName = "KoalaStuff";
            const string productName = "PoopWhite";

            var mockCommand = new Mock<ICommand>();
            var mockCommmandParser = new Mock<ICommandParser>();

            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new MockedCosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object, mockCommmandParser.Object);

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            mockCommand.Setup(x => x.Name).Returns("RemoveFromShoppingCart");
            mockCommand.Setup(x => x.Parameters).Returns(new List<string>() { productName });

            mockCommmandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            //Populate data
            testEngine.Categories.Add(categoryName, mockCategory.Object);
            testEngine.Products.Add(productName, mockProduct.Object);

            //The product must be in the shopping cart
            mockShoppingCart.Setup(x => x.ContainsProduct(mockProduct.Object)).Returns(true);

            //Act
            testEngine.Start();

            //Assert
            mockShoppingCart.Verify(x => x.RemoveProduct(mockProduct.Object), Times.Once());
        }



    }
}
