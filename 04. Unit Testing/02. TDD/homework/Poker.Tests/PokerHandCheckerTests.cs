using System.Collections.Generic;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerHandCheckerTests
    {
        //TODO Use testcase for valid and invalid last card
        [Test]
        public void IsValidHand_ShouldReturnTrue_WhenConsistsOfFiveDifferentCards()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Spades )
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var result = checker.IsValidHand(hand);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidHand_ShouldReturnFalse_WhenFinalCardIsNotUnique()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Hearts)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var result = checker.IsValidHand(hand);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidHand_ShouldReturnFalse_WhenCardsCountNotValid()
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
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var result = checker.IsValidHand(hand);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsFlush_ShouldReturnTrue_WhenAllCardsAreOfTheSameSuit()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Six, CardSuit.Spades)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var isFlush = checker.IsFlush(hand);

            //Assert
            Assert.IsTrue(isFlush);
        }

        [Test]
        public void IsFlush_ShouldReturnFalse_WhenNotAllCardsAreOfTheSameSuit()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Six, CardSuit.Hearts)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var isFlush = checker.IsFlush(hand);

            //Assert
            Assert.IsFalse(isFlush);
        }

        [Test]
        public void IsFlush_ShouldReturnFalse_WhenHandIsNotValid()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var isFlush = checker.IsFlush(hand);

            //Assert
            Assert.IsFalse(isFlush);
        }

        [Test]
        public void IsFourOfAKind_WhenFourCardsWithSameFace_ShouldReturnTrue()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Clubs)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            //Assert
            Assert.IsTrue(isFourOfAKind);
        }

        [Test]
        public void IsFourOfAKind_WhenNoFourCardsWithSameFace_ShouldReturnFalse()
        {
            //Arrange
            IList<ICard> cards = new List<ICard>(new Card[]
                {
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                    new Card(CardFace.Seven, CardSuit.Diamonds),
                    new Card(CardFace.Eight, CardSuit.Clubs)
                }
            );
            IHand hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            //Act
            var isFourOfAKind = checker.IsFourOfAKind(hand);

            //Assert
            Assert.IsFalse(isFourOfAKind);
        }


    }
}
