
using System.Data;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Blackjack
{
    public class Game
    {

        private Player player;
        private Dealer dealer;
        private Deck deck;
        private Bet bet;
        private int startingBalance;
        private int roundsPlayed = 0;
        private int roundsWon = 0;
        private string playerId;
        private bool isSavedPlayer;

        public Game(string playerName)
        {
            player = new Player(playerName);
            dealer = new Dealer();
            deck = new Deck();
            bet = new Bet();

            startingBalance = player.Balance;
            playerId = Guid.NewGuid().ToString();
            isSavedPlayer = false;
        }
        public Game(LeaderboardEntry savedPlayer)
        {
            player = new Player(savedPlayer.Name);
            player.Balance = savedPlayer.Score;

            dealer = new Dealer();
            deck = new Deck();
            bet = new Bet();

            roundsPlayed = savedPlayer.Rounds;
            roundsWon = savedPlayer.RoundsWon;

            startingBalance = player.Balance;
            playerId = savedPlayer.Id;
            isSavedPlayer = true;
        }

        public void StartRound()
        {
            if (player.Balance <= 0)
            {
                Console.WriteLine("Du har inga pengar kvar!");
                return;
            }
            bet.ResetBet();
            player.ClearHand();
            dealer.ClearHand();
            deck = new Deck();

            Console.WriteLine();
            Console.WriteLine("Ny omgång Blackjack!");
            while (true)
            {
                Console.Write($"Hur mycket vill du satsa? (1-{player.Balance}kr): ");
                if (!int.TryParse(Console.ReadLine(), out int amount))
                {
                    Console.WriteLine("Ogiltig inmatning, ange ett heltal!");
                    continue;
                }

                if (bet.PlaceBet(amount, player.Balance))
                {
                    player.Balance -= amount;
                    Console.WriteLine($"Du satsade {amount} kr!");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltig satsning!");
                    continue;
                }
            }
        
            DealCards();
            player.PrintHand();
            bool playerBlackjack = player.GetScore() == 21 && player.Cards.Count == 2;
            bool dealerBlackjack = dealer.GetScore() == 21 && dealer.Cards.Count == 2;
            Console.WriteLine($"Dealerns synliga kort: kort {dealer.Cards[0].Value}");
            Console.WriteLine("Dealerns andra kort är dolt.");

            if (!playerBlackjack && !dealerBlackjack)
            {
                PlayerTurn(deck);
            }

            if (!playerBlackjack && !dealerBlackjack && player.GetScore() <= 21)
            {
                DealerTurn();
            }
            DetermineWinner();
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

            while (playing && player.GetScore() < 21)
            {
                

                Console.Write("1. Hit! 2. Stand! Val: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    player.TakeCard(deck);
                    player.PrintHand();
                }
                else if (choice == "2")
                {
                    playing = false;


                }
            }
        }
//      Kaltuun tar PlayerTurn
        public void DealerTurn()
        {
            Console.WriteLine("--- Dealerns tur ---");

            while (dealer.GetScore() < 17)
            {
                Card newCard = deck.DrawCard();
                dealer.AddCard(newCard);
            }
            dealer.PrintHand();
            Console.WriteLine($"Dealern stannar på {dealer.GetScore()} poäng.");
        }
        // Zeynab tar DealerTurn
        public void DetermineWinner()
        {
            roundsPlayed++;
            int playerScore = player.GetScore();              
            int dealerScore = dealer.GetScore();
            bool playerBlackjack = playerScore == 21 && player.Cards.Count == 2;
            bool dealerBlackjack = dealerScore == 21 && dealer.Cards.Count == 2;
            int winning = (int)(bet.Amount * 1);
            if (playerBlackjack && dealerBlackjack)
            {
                player.Balance += bet.Amount;
                Console.WriteLine($"Oavgjort! Insatsen {bet.Amount} kr tillbaka! Saldo: {player.Balance} kr");
                return;
            }
            if (playerScore > 21)
            {
                Console.WriteLine($"Över 21 du förlorade!  -{bet.Amount} kr , saldo kvar: {player.Balance} kr");
                return;
            }

            if (playerBlackjack == true)
            {
                roundsWon++;
                int blackjackWinning = (int)(bet.Amount * 1.5);
                player.Balance += bet.Amount + blackjackWinning;
                Console.WriteLine($"Blackjack! +{blackjackWinning} kr, saldo: {player.Balance} kr");
                return;
            }

            if (dealerBlackjack == true)
            {
                Console.WriteLine($"Dealer Blackjack, du förlorade! -{bet.Amount} kr, saldo kvar: {player.Balance} kr");
                return;
            }
             
            if (dealerScore > 21)
            {
                roundsWon++;
                player.Balance += bet.Amount + winning;
                Console.WriteLine($"Du vann! Dealern gick över 21. +{winning} kr , saldo: {player.Balance} kr");
                return;
            }
            if (playerScore > dealerScore)       // kontrollrar att spelare har mer poäng än dealern
            {
                roundsWon++;
                player.Balance += bet.Amount + winning;
                Console.WriteLine($"Du vann! +{winning} kr , saldo: {player.Balance} kr");
                return;
            }
            if (playerScore < dealerScore)
            {
                Console.WriteLine($"Du förlorade! -{bet.Amount} kr , saldo kvar: {player.Balance} kr");
                return;
            }
            if (playerScore == dealerScore)
            {
                player.Balance += bet.Amount;
                Console.WriteLine($"Oavgjort! Insatsen {bet.Amount} kr tillbaka! Saldo: {player.Balance} kr");
                return;
            }
        }
        // Christian tar DetermineWinner
        public bool Endgame()
        {
            int totalProfit = player.Balance - startingBalance;
            Console.WriteLine($"Omgång klar! Antal rundor [{roundsPlayed}]. {totalProfit:+0;-0;0} kr! Aktuellt saldo: {player.Balance}kr");
            if (player.Balance <= 0)
            {
                Console.WriteLine("Du har slut på pengar! Spelet avslutas.");
                return false;
            }
            Console.Write("Spela igen ja/nej?");
            while (true)
            {
                string playAgain = Console.ReadLine()?.Trim().ToLower() ?? "";
                if (playAgain == "ja")
                {

                    return true;
                }
                else if (playAgain == "nej")
                {
                    return false;
                }
                Console.WriteLine("Fel inmatning!");
            }
        }
        public void SaveResult()
        {
            LeaderboardEntry entry = new LeaderboardEntry
            {
                Id = playerId,
                Name = player.Name,
                Score = player.Balance,
                Rounds = roundsPlayed,
                RoundsWon = roundsWon
            };
            Leaderboard leaderboard = new Leaderboard();

            if (isSavedPlayer)
            {
                leaderboard.UpdateEntry(entry);
            }
            else
            {
                leaderboard.AddEntry(entry);
            }
        }
        // Christian tar Endgame
    }
}


