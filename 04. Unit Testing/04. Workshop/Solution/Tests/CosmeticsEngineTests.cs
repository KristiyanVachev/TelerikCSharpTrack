using System;
using System.IO;
using Cosmetics.Contracts;
using NUnit.Framework;
using Cosmetics.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_ShouldThrow_WhenInputStringNotInCorrectFormat()
        {
            //Arrange
            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            CosmeticsEngine testEngine = new CosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object);

            //Act
            Console.SetIn(new StringReader("Invalid  "));

            //Assert
            Assert.Throws<ArgumentNullException>(() => testEngine.Start());
        }

        [Test]
        public void Start_ShouldExecuteCreateCategory_WhenCommandIsValid()
        {
            //Assert
            var mockCosmeticFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var testEngine = new CosmeticsEngine(mockCosmeticFactory.Object, mockShoppingCart.Object);

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Name).Returns("CreateCategory");
            mockCommand.Setup(x => x.Parameters[0]).Returns("CategoryName");

            //Act
            PrivateObject obj = new PrivateObject(testEngine);
            var retVal = obj.Invoke("ProcessSingleCommand", mockCommand.Object);
            
            //Assert
            Assert.AreEqual("Category with name CategoryName was created!", retVal);
        }

        //private class fakeCosmeticEngine : CosmeticsEngine
        //{
        //    public fakeCosmeticEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart) : base(factory, shoppingCart)
        //    {

        //    }

        //    public int CategoriesCount()
        //    {
        //        return this.categories.Count;
        //    }
        //}
    }
}
