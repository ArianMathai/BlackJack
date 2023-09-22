using System;

namespace Blackjack.cards {
    public class Card {
        public CardValue cardValue;
        public CardType cardType;
        public bool isVisible;
        

        public Card(CardType type, CardValue value) {
            cardValue = value;
            cardType = type;
            isVisible = true;
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

        public void PrintHiddenCard() {
            Console.WriteLine("Hidden Card");
        }

        public void PrintCard(Card card) {
            Console.WriteLine(card);
        }

        public override string ToString() {
            return $"{cardValue} of {cardType}";
        }
    }
}