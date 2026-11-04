using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blackjack
{
    public class Player
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public List<Card> Cards { get; set; }


        public Player(string name, int startingBalance = 100)
        {
            Name = name;
            Balance = startingBalance;
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void ClearHand()
        {
            Cards.Clear();
        }

        public int GetScore()
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in Cards)
            {
                score += card.Value;
                if (card.Name == "Ess")
                {
                    aceCount++;
                }
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;

        }

        public void PrintHand()
        {
            Console.Write($"{Name}:");
            foreach (var card in Cards)
            {
                Console.Write($"{card} ");
            }
            Console.WriteLine($" = {GetScore()}p");
        }
    }
}
                
            
        
   
