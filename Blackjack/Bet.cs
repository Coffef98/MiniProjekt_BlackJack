using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Bet
    {
        public int Amount {  get; private set; }
        public bool IsValidBet(int amount, int balance)
        {
            return amount >= 1 && amount <= 100 && amount <= balance;
        }
        public bool PlaceBet(int amount, int balance)
        {
            if(IsValidBet(amount, balance))
            {
                Amount = amount;
                return true;
            }
            return false;
        }

    }
}



// du ska alltid kunna satsa så mycket pengar som du har 
// börjar med 100 kr då kan du satsa 1-100 kr 
// har du vunnit tex 1054 kr så ska du alltid kunna satsa så mycket som du har vi det tillfället så nu 1054 högsta insats.