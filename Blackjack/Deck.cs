
namespace Blackjack
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();

        public int CardsRemaining
        {
            get { return _cards.Count; }
        }
        public Deck()
        {
            CreateDeck();
            Shuffle();
        }
        private void CreateDeck()
        {
            string[] suits = { "Hjärter", "Ruter", "Klöver", "Spader" };
            string[] ranks = { "Ess", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Knekt", "Dam", "Kung" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card card = new Card(suit, rank);
                    _cards.Add(card);
                }
            }
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }
        public Card DrawCard()
        {
            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public bool NeedsNewDeck()
        {
            return CardsRemaining < 15;
        }
    }
}
