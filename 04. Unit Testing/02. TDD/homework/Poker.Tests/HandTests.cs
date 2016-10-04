using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void HandToString_ShouldReturnCorrectly()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            }
         );

            var hand = new Hand(cards);

            StringBuilder expectedOutput = new StringBuilder();
            
            foreach (var card in cards)
            {
                expectedOutput.AppendLine(string.Format($"{card.Face} of {card.Suit}"));
            }

            //Act
            var output = hand.ToString();

            //Assert
            Assert.AreEqual(expectedOutput.ToString(), output);
        }
    }
}
