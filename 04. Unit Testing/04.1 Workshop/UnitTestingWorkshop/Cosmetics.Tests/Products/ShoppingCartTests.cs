using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Cosmetics.Contracts;
using Cosmetics.Products;
using Moq;
using NUnit.Framework;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_ShouldAddProductToShoppingList()
        {
            //Arrange
            var cart = new MockedShoppingCart();
            var mockProduct = new Mock<IProduct>();

            //Act
            cart.AddProduct(mockProduct.Object);

            //Assert
            Assert.AreEqual(mockProduct.Object, cart.Products[0]);
        }

        [Test]
        public void RemoveProduct_ShouldRemoveProductFromShoppingList()
        {
            //Arrange
            var cart = new MockedShoppingCart();
            var mockProduct = new Mock<IProduct>();
            cart.AddProduct(mockProduct.Object);

            //Act
            cart.RemoveProduct(mockProduct.Object);

            //Assert
            Assert.IsFalse(cart.Products.Contains(mockProduct.Object));
        }

        [Test]
        public void ContainsProduct_ShouldReturnTrue_WhenProductIsInTheShoppingList()
        {
            //Arrange
            var cart = new MockedShoppingCart();
            var mockProduct = new Mock<IProduct>();

            cart.AddProduct(mockProduct.Object);

            //Act
            var containsProduct = cart.ContainsProduct(mockProduct.Object);

            //Assert
            Assert.IsTrue(containsProduct);
        }

        [Test]
        public void TotalPrice_ShouldReturnTotalSumOfProducts()
        {
            //Arrange
            var cart = new MockedShoppingCart();
            var mockProduct = new Mock<IProduct>();
            var mockProduct2 = new Mock<IProduct>();

            mockProduct.Setup(x => x.Price).Returns(20M);
            mockProduct2.Setup(p => p.Price).Returns(24M);
           
            cart.AddProduct(mockProduct.Object);
            cart.AddProduct(mockProduct2.Object);

            //Act
            var totalPrice = cart.TotalPrice();

            //Assert
            Assert.AreEqual(44, totalPrice);
        }



        internal class MockedShoppingCart : ShoppingCart
        {
            public IList<IProduct> Products => base.products;
        }
    }
}
