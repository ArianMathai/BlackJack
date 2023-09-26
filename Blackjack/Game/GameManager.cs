using System;
using System.Collections.Generic;
using System.Dynamic;
using Blackjack.cards;
using Blackjack.Participants;

namespace Blackjack.Game {
    public class GameManager {
        private Table table { get; set; }
        

        private bool isActiveRound = true;
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

        public bool CheckForBust(int roundScore) {
            if (roundScore > 21) {
                Console.WriteLine("BUST!");
                isActiveRound = false;
                return true;
            }

            if (roundScore == 21) {
                Console.WriteLine("BLACKJACK!!!");
                table.player.score += 1;
                isActiveRound = false;
                return true;
            }

            return false;
        }

        public void Stand(int playerScore) {
            int dealerScore = Calculate(table.dealer.hand);
            
            if (dealerScore < playerScore) {
                Console.WriteLine("you win");
                table.player.score += 1;
            }
            else {
                Console.WriteLine("You lose");
            }
            isActiveRound = false;
        }

        public void Turn() {
            int roundScore = 0;
            roundScore = Calculate(table.player.hand);
            bool bust = CheckForBust(roundScore);

            if (!bust) {
                Console.WriteLine("Hit or stand! (h/s)");
                bool x = true;
                
                while (x) {
                    char i = Console.ReadKey().KeyChar;
                    char input = char.ToLower(i);
                    Console.WriteLine("\n");

                    if (input == 'h') {
                        Hit();
                        x = false;
                    }else if (input == 's') {
                        Stand(roundScore);
                        x = false;
                        return;
                    }
                }
            }
        }

        public void ContinuePlaying() {
            Console.WriteLine("Do you want to continue playing? (y/n)");

            bool c = true;
            while (c) {
                char i = Console.ReadKey().KeyChar;
                char input = char.ToLower(i);
                Console.WriteLine("\n");

                if (input == 'y') {
                    table.ClearHands();
                    c = false;
                    isActiveRound = true;
                }

                if (input == 'n') {
                    isActiveGame = false;
                    return;
                }
                
                
            }
            
        }
        
        

        public void RunGame() {

            while (isActiveGame) {
                table.DealCards();
            
                while (isActiveRound) {
                    table.ShowBothHands();
                    
                    Console.WriteLine("--------------");
                    Turn();
                }
                ContinuePlaying();
                Console.WriteLine("*****************");
                Console.WriteLine("Your score: " + table.player.score);
                Console.WriteLine("*****************");
            }
            
        }
        
    }
}