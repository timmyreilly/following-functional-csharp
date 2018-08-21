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
            // Assert.Equal("0", "1"); 

        }

        [Fact]
        public void CanFail()
        {
            Assert.Equal("1", "1");
        }
    }
}
