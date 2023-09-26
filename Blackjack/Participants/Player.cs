using System.Collections.Generic;
using System.Dynamic;
using Blackjack.cards;

namespace Blackjack.Participants {
    public class Player : Participant {
        private string name;
        public int score;
        
        public List<Card> hand = new List<Card>();

        public Player(string name) {
            this.name = name;
        }

        public void ClearPlayerHand() {
            hand.Clear();
        }
        
    }
}