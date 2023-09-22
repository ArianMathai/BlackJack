using System.Collections.Generic;
using Blackjack.cards;

namespace Blackjack.Participants {
    public class Player : Participant {
        private string name;
        public List<Card> hand = new List<Card>();

        public Player(string name) {
            this.name = name;
        }
    }
}