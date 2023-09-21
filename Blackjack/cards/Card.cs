using System;

namespace Blackjack.cards {
    public class Card {
        public CardValue cardValue;
        public CardType cardType;
        

        public Card(CardType type, CardValue value) {
            this.cardValue = value;
            this.cardType = type;
        }

        public int getCardValue(Card card) {
            if (card.cardValue == CardValue.King) {
                return 10;
            }
            if (card.cardValue == CardValue.Queen) {
                return 10;
            }
            if (card.cardValue == CardValue.Jack) {
                return 10;
            }
            return (int)card.cardValue;
        }

        public override string ToString() {
            return $"{cardValue} of {cardType}";
        }
    }
}