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
