
using System.Data;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Blackjack
{
    public class Game
    {

        private Player player = new Player("Spelare");
        private Dealer dealer = new Dealer();
        private Deck deck = new Deck();
        private Bet bet = new Bet();

        public void StartRound()
        {
            player.ClearHand();
            dealer.ClearHand();

            Console.WriteLine("Ny omgång Blackjack!");
            Console.WriteLine("Hur mycket vill du satsa? (1-100kr): ");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Ogiltig inmatning, ange ett heltal!");
                return;
            }

            if (bet.PlaceBet(amount, player.Balance))
            {
                player.Balance -= amount;
                Console.WriteLine($"Du satsade {amount} kr!");
            }
            else
            {
                Console.WriteLine("Ogiltig satsning!");
                return;
            }
            DealCards();
            player.PrintHand();
            Console.WriteLine($"Dealerns synliga kort: {dealer.Cards[0]}");
            Console.WriteLine("Dealerns andra kort är dolt.");

            PlayerTurn(deck);

            if (player.GetScore() <= 21)
            {
                DealerTurn();
            }

            DetermineWinner();
            Endgame();
        }
        // Christoffer tar StartRound
        public void DealCards()
        {
            player.TakeCard(deck);
            dealer.TakeCard(deck);

            player.TakeCard(deck);
            dealer.TakeCard(deck);
        }
        // Christoffer tar DealCards
        public void PlayerTurn(Deck deck)
            {
            bool playing = true;

            while (playing && GetScore() < 21)
            
                PrintHand();

                Console.WriteLine("1. Hit");
                Console.WriteLine("2. Stand");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    TakeCard(deck);
                }
                else if (choice == "2")
                {
                    playing = false;


                }
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
            int playerScore = player.GetScore();              // poängen är tillfälligt för test (23), spelar poängen ska senare hämtas!!!
            int dealerScore = dealer.GetScore();              // poängen är tillfälligt för test (19),dealer poäng ska senare hämtas!!!
            int winning = (int)(bet.Amount * 1.5);
            if(playerScore > 21)
            {
                Console.WriteLine($"Över 21 du förlorade!  -{winning} kr , saldo kvar: {player.Balance} kr");
                return;
            }
            if(dealerScore  > 21)
            {
                Console.WriteLine($"Du vann! Dealern gick över 21. +{winning} kr , saldo {player.Balance} kr");
                return;
            }
            if(playerScore > dealerScore)       // kontrollrar att spelare har mer poäng än dealern
            {
                
                player.Balance += bet.Amount + winning;
                Console.WriteLine($"Du vann! +{winning} kr , saldo {player.Balance} kr");
                return;
            }
            if (playerScore < dealerScore)
            {
                Console.WriteLine($"Du förlorade! -{bet.Amount} kr , saldo kvar {player.Balance} kr");
                return;
            }
            if (playerScore == dealerScore)
            {
                player.Balance += bet.Amount;
                Console.WriteLine($"Oavgjort! + - 0 kr , Saldo: {player.Balance} kr");
                return; 
            }
        }
        // Christian tar DetermineWinner
        public void Endgame()
        {   
            int totalProfit = player.Balance - startingBalance;
            Console.WriteLine($"Omgång klar! Antal rundor {totalProfit:+0;-0;0}st! Aktuellt saldo: {player.Balance}kr");
            Console.Write("Spela igen ja/nej?");
            string playAgain = Console.ReadLine() ?? "";
            if(playAgain == "ja")
            {
                StartRound();
                return;
            }
            else if(playAgain == "nej")
            {
                return;
            }

        }
        // Christian tar Endgame
    }
}

