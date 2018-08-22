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

    
}
