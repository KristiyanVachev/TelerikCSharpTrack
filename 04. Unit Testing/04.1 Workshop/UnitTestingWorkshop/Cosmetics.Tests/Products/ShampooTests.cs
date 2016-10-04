using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnStringWithDetails()
        {
            //Arrange
            var shampoo = new Shampoo("Poop", "Koala", 2M, GenderType.Men, 250, UsageType.EveryDay);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- Koala - Poop:"));
            sb.AppendLine(string.Format("  * Price: $500"));
            sb.AppendLine(string.Format("  * For gender: Men"));
            sb.AppendLine(string.Format("  * Quantity: 250 ml"));
            sb.Append(string.Format("  * Usage: EveryDay"));
            var expectedString = sb.ToString();

            //Act
            var retString = shampoo.Print();

            //Assert
            Assert.AreEqual(expectedString, retString);
        }
    }
}
