using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class LeaderboardEntry
    {
        public string Name { get; set; } = "";
        public int Score { get; set; }
        public int Rounds { get; set; }
        public int RoundsWon { get; set; }


    }
}
