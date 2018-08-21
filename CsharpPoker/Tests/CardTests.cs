using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CsharpPoker.Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCardWithValue()
        {
            var card = new Card(CardValue.Ace, CardSuit.Clubs);
            Assert.Equal(CardSuit.Clubs, card.Suit);
            Assert.Equal(CardValue.Ace, card.Value);
        }

        [Fact]
        public void CanDescribeCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);

            Assert.Equal("Ace of Spades", card.ToString()); 
        }

        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();
            Assert.False(hand.Cards.Any());
        }

        [Fact]
        public void CanHandDrawCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            // var hand 
            var hand = new Hand();
            

        }
    }
}
