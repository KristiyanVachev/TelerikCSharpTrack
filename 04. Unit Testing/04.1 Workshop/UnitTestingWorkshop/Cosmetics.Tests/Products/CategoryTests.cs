using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Contracts;
using Cosmetics.Products;
using Moq;
using NUnit.Framework;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Print_ShouldReturnStringWithDetails()
        {
            //Arrange
            var category = new Category("Koala");

            var expectedString = string.Format("Koala category - 0 products in total");

            //Act
            var retString = category.Print();

            //Assert
            Assert.AreEqual(expectedString, retString);
        }

        [Test]
        public void AddProducts_ShouldAddCosmeticToProductsList()
        {
            var category = new MockedCategory("Koala");
            var mockProduct = new Mock<IProduct>();

            //Act
            category.AddProduct(mockProduct.Object);

            //Assert
            Assert.AreSame(mockProduct.Object, category.Products[0]);
        }

        [Test]
        public void RemoveProduct_ShouldRemovePassedProduct_WhenProductParamsAreValid()
        {
            var category = new MockedCategory("Koala");
            var mockProduct = new Mock<IProduct>();

            category.AddProduct(mockProduct.Object);
            //Act
            category.RemoveProduct(mockProduct.Object);

            //Assert
            Assert.IsFalse(category.Products.Contains(mockProduct.Object));
        }

        internal class MockedCategory : Category
        {
            public IList<IProduct> Products => base.products;

            public MockedCategory(string name) : base(name)
            {
            }
        }
    }
}
