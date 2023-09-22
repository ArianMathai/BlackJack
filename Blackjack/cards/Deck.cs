using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.cards {
    public class Deck {
        public Queue<Card> CardDeck;
        
        public List<Card> cardList;

        private int _numberOfDecks;

        public Deck(int numberOfDecks) {
            _numberOfDecks = numberOfDecks;
            InitializeDeck();
            Shuffle(cardList);
            addListToQueue();
        }

        
        public void InitializeDeck() {
            cardList = new List<Card>();

            for (int x = 0; x < _numberOfDecks; x++) {
                
                for (int i = 0; i < 4; i++) {

                    for (int j = 1; j < 14; j++) {
                        Card card = new Card((CardType)i, (CardValue)j);
                        cardList.Add(card);
                        //Console.WriteLine("---" + card.cardValue + "  " + card.getCardValue(card));
                    }
                }
            }
        }

        private void addListToQueue() {
            CardDeck = new Queue<Card>();

            foreach (Card card in cardList) {
                CardDeck.Enqueue(card);
            }
        }
        
        private static Random random = new Random();
        public static void Shuffle<Card>( List<Card> list) {
            
            int n = list.Count;
            
            for (int i = n - 1; i > 0; i--) {
                int j = random.Next(0, i + 1);
                Card temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        

        public void PrintAllCards() {
            Console.WriteLine("Number of Cards: " + cardList.Count);
            foreach (Card card in cardList) {
                Console.WriteLine(card);
            }
        }

        public void PrintShuffledDeck() {
            Console.WriteLine("Number of Cards in deck: " + cardList.Count);
            foreach (Card card in CardDeck) {
                PrintAllCards();
            }
        }
        
        
    }
}