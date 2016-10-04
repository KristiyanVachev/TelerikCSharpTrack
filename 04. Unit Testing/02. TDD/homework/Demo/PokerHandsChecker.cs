using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        if (hand.Cards[i].Suit == hand.Cards[j].Suit)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
                //Let's asume the first card is the one with the right face
                CardFace faceKind = hand.Cards[0].Face;

                //If the first card isn't of the same kind as the next two, then if there is
                //a four of a kind it can't be the faceKind
                if (faceKind != hand.Cards[1].Face && faceKind != hand.Cards[2].Face)
                {
                    faceKind = hand.Cards[1].Face;
                }

                //Knowing the face kind, if we get 4 of it, we have a Four Of A Kind
                int sameFaceCount = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (faceKind == hand.Cards[i].Face)
                    {
                        sameFaceCount++;
                    }
                }

                return sameFaceCount == 4;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            //We'll check if the hand is valid first. 
            //That way it wouldn't be nessesary do check everytime in the logic
            if (IsValidHand(hand))
            {
                return hand.Cards.All(cards => hand.Cards[0].Suit == cards.Suit);
            }
            else
            {
                return false;
            }
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
