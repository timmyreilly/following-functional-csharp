using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpPoker
{
    public enum CardValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum CardSuit
    {
        Spades,
        Diamonds,
        Clubs,
        Hearts
    }

    public enum HandRank
    {
        HighCard,
        Pair, 
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
    public class Card
    {
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public override string ToString()
            => $"{Value} of {Suit}";

    }

    public class Hand
    {
        private readonly List<Card> cards = new List<Card>(); 

        public IEnumerable<Card> Cards { get { return cards; } }
        public Hand()
        {
            cards = new List<Card>();
        }

        public void Draw(Card card)
        {
            cards.Add(card);

        }

        public Card HighCard()
        {
            Card highCard = cards.First();
            foreach (var nextCard in Cards)
            {
                if (nextCard.Value > highCard.Value)
                {
                    highCard = nextCard;
                }

            }
            return highCard;

        }

        public HandRank GetHandRank()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;
            return HandRank.HighCard; 

        }

        private bool HasFlush()
        {
            return cards.All(c => cards.First().Suit == c.Suit); 
        }

        public bool HasRoyalFlush()
        {
            return HasFlush() && cards.All(c => c.Value > CardValue.Nine); 
        }
    }
}
