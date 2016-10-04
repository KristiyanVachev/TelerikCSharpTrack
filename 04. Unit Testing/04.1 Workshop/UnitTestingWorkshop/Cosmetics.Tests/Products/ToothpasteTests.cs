using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnStringWithDetails()
        {
            //Arrange
            var toothpaste = new Toothpaste("Poop","Koala",2M, GenderType.Men, new List<string>() {"Poop", "Leaves"});

            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- Koala - Poop:"));
            sb.AppendLine(string.Format("  * Price: $2"));
            sb.AppendLine(string.Format("  * For gender: Men"));
            sb.Append(string.Format("  * Ingredients: Poop, Leaves"));
            var expectedString = sb.ToString();

            //Act
            var retString = toothpaste.Print();

            //Assert
            Assert.AreEqual(expectedString, retString);
        }
    }
}
