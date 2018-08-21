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

        public IEnumerable<Card> Cards => cards;

        public void Draw(Card card) => cards.Add(card); 

        public Card HighCardOld()
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

        public Card HighCardOldy()
        {
            return cards.Aggregate((highCard, nextCard) => nextCard.Value > highCard.Value ? nextCard : highCard); 
        }

        public Card HighCard() => cards.Aggregate((highCard, nextCard) => nextCard.Value > highCard.Value ? nextCard : highCard);

        // Ternary operators instead of return early. 
        public HandRank GetHandRank() =>
            HasRoyalFlush() ? HandRank.RoyalFlush :
            HasFlush() ? HandRank.Flush :
            HandRank.HighCard;

        public HandRank GetHandRankOldest()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;
            return HandRank.HighCard; 

        }


        private bool HasFlush() => cards.All(c => cards.First().Suit == c.Suit); 


        public bool HasRoyalFlush() => HasFlush() && cards.All(c => c.Value > CardValue.Nine);




        public bool HasRoyalFlushOldest()
        {
            return HasFlush() && cards.All(c => c.Value > CardValue.Nine); 
        }
        private bool HasFlushOldest()
        {
            return cards.All(c => cards.First().Suit == c.Suit); 
        }
    }
}
