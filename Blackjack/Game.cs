
namespace Blackjack
{
    public class Game
    {
        private Player player;
        private Dealer dealer;
        private Deck deck;

        public Game()
        {
            player = new Player("Spelare");
            dealer = new Dealer();
            deck = new Deck();

        }


        public void StartRound()
        {

        }
        // Christoffer tar StartRound
        public void DealCards()
        {

        }
        // Christoffer tar DealCards
        public void PlayerTurn(Deck deck)
        {
            bool playing = true;

            while (playing && player.GetScore() < 21)
            {
                player.PrintHand();

                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.TakeCard(deck);
                }
                else if (choice == "2")
                {
                    playing = false;


                }
            }
        }
        // Kaltuun tar PlayerTurn
        public void DealerTurn()
        {

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

