
namespace Blackjack
{
    public class Game
    {
        public void StartRound()
        {
            
        }
        // Christoffer tar StartRound
        public void DealCards()
        {

        }
        // Christoffer tar DealCards
        public void PlayerTurn()
        {

        }
        // Kaltuun tar PlayerTurn
        public void DealerTurn()
        {
            Console.WriteLine("--- Dealerns tur ---");

            while (dealer.GetScore() < 17)
            {
                Card newCard = deck.DrawCard();
                dealer.AddCard(newCard);
                Console.WriteLine($"Dealern drog ett kort och har nu {dealer.GetScore()} poäng.");
            }

            Console.WriteLine($"Dealern stannar på {dealer.GetScore()} poäng.");
        }
        // Zeynab tar DealerTurn
        public void DetermineWinner()
        {
            
        }
        // Christian tar DetermineWinner
        public void Endgame()
        {

        }
        // Christian tar Endgame
    }
}
