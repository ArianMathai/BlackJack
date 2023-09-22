using System;
using System.Collections.Generic;
using System.Dynamic;
using Blackjack.cards;
using Blackjack.Participants;

namespace Blackjack.Game {
    public class GameManager {
        private Table table { get; set; }

        private bool isActiveGame = true;

        public GameManager(int numberOfDecks, string username) {
            table = new Table(numberOfDecks, username);
        }

        public void Hit() {
            table.player.hand.Add(table.deck.CardDeck.Dequeue());
        }

        public int Calculate(List<Card> hand) {
            int score = 0;

            foreach (Card card in hand) {
                score += card.getCardValue(card);
            }
            return score;
        }

        public void RunGame() {
            while (isActiveGame) {
                table.DealCards();
                
                table.ShowBothHands();
                
                int playerScore = Calculate(table.player.hand);
                int dealerScore = Calculate(table.dealer.hand);
                Console.WriteLine("--------------");
                Console.WriteLine("Dealerscore = " + dealerScore);
                Console.WriteLine("Playersore = " + playerScore);

                Console.WriteLine("Hit or stand! (h/s)");
                char input = Console.ReadKey().KeyChar;

            }
            
        }
        
    }
}