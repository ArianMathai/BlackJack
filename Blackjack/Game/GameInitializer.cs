using System;
using System.IO;

namespace Blackjack.Game {
    public class GameInitializer {
        public GameInitializer() {
            
        }

        public void InitializeGame() {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            Console.WriteLine("Enter username: ");
            string username = reader.ReadLine();
            Console.WriteLine($"Hello {username}!");
            Console.WriteLine("How many decks would you like to play with?");
            string numberOfDecks = reader.ReadLine();
            reader.Close();
            GameManager gameManager = new GameManager(int.Parse(numberOfDecks), username);
            gameManager.RunGame();
        }
    }
}