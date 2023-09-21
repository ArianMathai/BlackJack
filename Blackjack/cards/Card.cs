namespace Blackjack.cards {
    public class Card {
        public CardValue cardValue { get; set; }
        public CardType cardType { get; set; }
        

        public Card(CardType type, CardValue value) {
            this.cardValue = value;
            this.cardType = type;
        }

        public override string ToString() {
            return $"{cardValue} of {cardType}";
        }
    }
}