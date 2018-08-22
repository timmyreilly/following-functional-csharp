using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Put this in the interactive window: 
// #r "C:\Users\tireilly\GitHub\functional-csharp-code\CsharpPoker\obj\Debug\netcoreapp2.0\CsharpPoker.dll"
// using CsharpPoker;

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


        public Card HighCard() => cards.Aggregate((highCard, nextCard) => nextCard.Value > highCard.Value ? nextCard : highCard);

        // Ternary operators instead of return early. 
        public HandRank GetHandRank() =>
            HasRoyalFlush() ? HandRank.RoyalFlush :
            HasStraightFlush() ? HandRank.StraightFlush : 
            HasFlush() ? HandRank.Flush :
            HasFullHouse() ? HandRank.FullHouse :
            HasFourOfAKind() ? HandRank.FourOfAKind : 
            HasThreeOfAKind() ? HandRank.ThreeOfAKind : 
            HasPair() ? HandRank.Pair : 
            HasStraight() ? HandRank.Straight : 
            HandRank.HighCard;



        private bool HasFlush() => cards.All(c => cards.First().Suit == c.Suit); 


        public bool HasRoyalFlush() => HasFlush() && cards.All(c => c.Value > CardValue.Nine);

        private bool HasOfAKind(int num) => cards.ToKindAndQuantities().Any(c => c.Value == num);

        private bool HasPair() => HasOfAKind(2);
        private bool HasThreeOfAKind() => HasOfAKind(3);
        private bool HasFourOfAKind() => HasOfAKind(4);
        private bool HasFullHouse() => HasPair() && HasThreeOfAKind();

        private bool HasStraight() =>
            cards.OrderBy(card => card.Value).SelectConsecutive((n, next) => n.Value + 1 == next.Value).All(value => value);

        private bool HasStraightFlush() => HasStraight() && HasFlush(); 

        private bool HasStraightOld()
        {
            // sort the cards
            // now check if they are sequential. 
            return cards
                .OrderBy(card => card.Value)
                .Zip(cards.OrderBy(card => card.Value).Skip(1), (n, next) => n.Value + 1 == next.Value)
                .All(value => value); 

        }
        public HandRank GetHandRankOldest()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;
            return HandRank.HighCard; 

        }
        public bool HasRoyalFlushOldest()
        {
            return HasFlush() && cards.All(c => c.Value > CardValue.Nine); 
        }
        private bool HasFlushOldest()
        {
            return cards.All(c => cards.First().Suit == c.Suit); 
        }
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

    }
}
