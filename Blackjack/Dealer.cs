namespace Blackjack
{
    public class Dealer : Player
    {
        public Dealer () : base ("Dealer")
        {
            
        }
        public void PlayTurn(Deck deck)
        {
            while (GetScore() < 17)
            {
                TakeCard(deck);
            }

            
        
    }

}
}