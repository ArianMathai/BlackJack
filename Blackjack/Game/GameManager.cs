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

        public void DealerHit() {
            int dealerHand = Calculate(table.dealer.hand);
            if (dealerHand < 18) {
                table.dealer.hand.Add(table.deck.CardDeck.Dequeue());
            }
        }

        public int Calculate(List<Card> hand) {
            int score = 0;

            foreach (Card card in hand) {
                score += card.getCardValue(card);
            }
            return score;
        }

        public void CheckForDealerBust(int score) {
            if (score > 21) {
                Console.WriteLine("Dealer is bust");
                isActiveRound = false;
                table.player.score += 1;
            }
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
            //DealerTurn();
            isActiveRound = false;
        }

        public void DealerTurn() {
            int score = Calculate(table.dealer.hand);
            CheckForDealerBust(score);
            DealerHit();
            score = Calculate(table.dealer.hand); // Find better solution for 
            CheckForDealerBust(score);           // these two lines
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
                    DealerTurn();
                    Console.WriteLine("dealer: " + Calculate(table.dealer.hand));
                    Console.WriteLine("player: " + Calculate(table.dealer.hand));
                }
                ContinuePlaying();
                Console.WriteLine("*****************");
                Console.WriteLine("Your score: " + table.player.score);
                Console.WriteLine("*****************");
            }
        }
    }
}