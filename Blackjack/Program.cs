﻿using System;
using Blackjack.cards;

namespace Blackjack {
    internal class Program {
        public static void Main(string[] args) {
            Deck deck = new Deck();
            deck.PrintAllCards();
        }
    }
}