namespace Blackjack
{
    public class Card
    {
        public string Suit { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Symbol
        {
            get
            {
                return Suit switch
                {
                    "Hjärter" => "\u2665",
                    "Ruter" => "\u2666",
                    "Klöver" => "\u2663",
                    "Spader" => "\u2660",
                    _ => "?"
                };
            }
        }

        public Card(string suit, string name)
        {
            Suit = suit;
            Name = name;
            if (name == "Ess")
            {
                Value = 11;
            }
            else if (name == "Kung" || name == "Dam" || name == "Knekt")
            {
                Value = 10;
            }
            else
            {
                Value = int.Parse(name);
            }
        }
    }
}
