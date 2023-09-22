using System;
using System.Collections.Generic;
using System.Dynamic;
using Blackjack.cards;
using Blackjack.Participants;

namespace Blackjack.Game {
    public class Table {
        public Deck deck;
        public Dealer dealer;
        public Player player;
        public List<Card> discardPile;

        public Table(int numberOfDecks, string username) {
            deck = new Deck(numberOfDecks);
            discardPile = new List<Card>();
            dealer = new Dealer();
            player = new Player(username);
            //DealCards();
        }

        public void DealCards() {
            for (int i = 0; i < 2; i++) {
                if (i == 1) {
                    Card temp = deck.CardDeck.Dequeue();
                    temp.isVisible = false;
                    dealer.hand.Add(temp);
                }
                else {
                    dealer.hand.Add(deck.CardDeck.Dequeue());
                }
            }
            
            for (int i = 0; i < 2; i++) {
                player.hand.Add(deck.CardDeck.Dequeue());
            }
        }

        public void ShowPlayerHand() {
            Console.WriteLine("Players hand: ");
            foreach (Card card in player.hand) {
                card.PrintCard(card);
            }
        }

        public void ShowDealerHand() {
            Console.WriteLine("Dealers hand: ");
            foreach (Card card in dealer.hand) {
                if (!card.isVisible) {
                    card.PrintHiddenCard();
                }
                else {
                    card.PrintCard(card);    
                }
            }
        }

        public void ShowBothHands() {
            ShowDealerHand();
            Console.WriteLine("--------------");
            ShowPlayerHand();
        }
    }
}