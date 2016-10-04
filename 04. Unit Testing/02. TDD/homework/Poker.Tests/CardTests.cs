using System;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void CardToString_ShouldReturnCorrectly()
        {
            //Arrange
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            var expectedOutput = "Ace of Spades";
            //Act
            string output = card.ToString();
            //Assert
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
