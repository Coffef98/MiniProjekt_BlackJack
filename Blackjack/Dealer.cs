namespace Blackjack
{
    public class Dealer : Player
    {
        public Dealer () : base ("Dealer")
        {
            
        }
        public void PalyTurn(Deck deck)
        {
            while (GetScore() < 17)
            {
                TakeCard(deck);
            }

            
        
    }

}
}