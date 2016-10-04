﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var card in Cards)
            {
                output.AppendLine(card.ToString());
            }
            return output.ToString();
        }
    }
}
