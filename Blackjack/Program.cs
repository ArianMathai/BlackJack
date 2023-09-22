using System;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Blackjack.cards;
using Blackjack.Game;

namespace Blackjack {
    internal class Program {
        public static void Main(string[] args) {
            GameInitializer gi = new GameInitializer();
            gi.InitializeGame();

        }
    }
}