using System.Collections.Generic;
using Blackjack.cards;

namespace Blackjack.Participants {
    public class Dealer : Participant {
        public string name = "Dealer";
        public List<Card> hand = new List<Card>();

        public Dealer() {
            
        }

        public void ClearDealerHand() {
            hand.Clear();
        }
        
    }
}