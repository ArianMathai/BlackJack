using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.cards {
    public class Deck {
        public HashSet<Card> deck;

        public Deck() {
            deck = initializeDeck();
        }

        // Test test
        public HashSet<Card> initializeDeck() {
            HashSet<Card> newDeck = new HashSet<Card>();

            for (int i = 0; i < 4; i++) {

                for (int j = 1; j < 14; j++) {
                    Card card = new Card((CardType)i, (CardValue)j);
                    newDeck.Add(card);
                }
                
            }

            return newDeck;
        }

        public void PrintAllCards() {
            foreach (Card card in deck) {
                Console.WriteLine(card);
            }
        }
        
        
    }
}