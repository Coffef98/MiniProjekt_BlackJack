
using System.Data;
using System.Runtime.CompilerServices;

namespace Blackjack
{
    public class Game
    
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

            while (playing && GetScore() < 21)
            {
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
        // Kaltuun tar PlayerTurn
        public void DealerTurn()
        {
            while(dealer.Getscore()<17)
            {
                dealer.AddCard(deck.DrawCard());
            }

        }
        // Zeynab tar DealerTurn
        public void DetermineWinner()
        {
<<<<<<< HEAD
            int playerScore = Player.GetScore();              // poängen är tillfälligt för test (23), spelar poängen ska senare hämtas!!!
            int dealerScore = dealer.GetScore();              // poängen är tillfälligt för test (19),dealer poäng ska senare hämtas!!!
            if(playerScore > 21)
            {
                Console.WriteLine($"Över 21 du förlorade!  -{} kr , saldo kvar: {} kr");
                return;
            }
            if(dealerScore  > 21)
            {
                Console.WriteLine($"Du vann! Dealern gick över 21. +{} kr , saldo {} kr");
                return;
            }
            if(playerScore > dealerScore)       // kontrollrar att spelare har mer poäng än dealern
            {
                int winning = (int)(bet.Amount * 1.5);
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

=======
>>>>>>> f5e3495021cfc31ccfc0cb0179501f90c37bb7d2

        }
        // Christian tar DetermineWinner
        public void Endgame()
        {   
            int totalProfit = player.Balance - startingBalance;
            Console.WriteLine($"Omgång klar! Antal rundor {totalProfit:+0;-0;0}st! Aktuellt saldo: {player.Balance}kr");

        }
        // Christian tar Endgame
    }
}
}
