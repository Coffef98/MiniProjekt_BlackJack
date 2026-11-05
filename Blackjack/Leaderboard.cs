using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Leaderboard
    {
        private List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
        private string filePath = "highscores.json";
        private bool loadFailed = false;
        public Leaderboard()
        {
            Load();
        }

        public void Load()

        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);

                    entries = JsonSerializer.Deserialize<List<LeaderboardEntry>>(json)
                              ?? new List<LeaderboardEntry>();

                    bool idsChanged = false;

                    foreach (var entry in entries)
                    {
                        if (string.IsNullOrWhiteSpace(entry.Id))
                        {
                            entry.Id = Guid.NewGuid().ToString();
                            idsChanged = true;
                        }
                    }
                    if (idsChanged)
                    {
                        Save();
                    }
                }
                catch (JsonException)
                {
                    loadFailed = true;
                    Console.WriteLine("Fel! Kunde inte läsa topplistan.");
                    return;
                }
            } // Avslutar if (File.Exists(filePath))
            else
            {
                Console.WriteLine("Hittar inte highscores.json!");
                Console.WriteLine(Path.GetFullPath(filePath));

                loadFailed = true;
            }
        }
        public void Save()
        {
            if (loadFailed)
            {
                return;
            }

            string json = JsonSerializer.Serialize(entries);

            File.WriteAllText(filePath, json);
        }
        public void AddEntry(LeaderboardEntry entry)
        {
            if (loadFailed)
            {
                Console.WriteLine("Topplistan kunde inte läsas. Resultatet sparas inte.");
                return;
            }
            entries.Add(entry);
            Save();
        }
        public void UpdateEntry(LeaderboardEntry updatedEntry)
        {
            if (loadFailed)
            {
                Console.WriteLine("Topplistan kunde inte läsas.");
                return;
            }
            if (string.IsNullOrWhiteSpace(updatedEntry.Id))
            {
                Console.WriteLine("Spelaren saknar ID!");
                return;
            }
            var existing = entries.FirstOrDefault(e => e.Id == updatedEntry.Id);

            if (existing != null)
            {
                existing.Score = updatedEntry.Score;
                existing.Rounds = updatedEntry.Rounds;
                existing.RoundsWon = updatedEntry.RoundsWon;

                Save();
            }
            else
            {
                Console.WriteLine("Spelaren hittades inte i topplistan.");
            }
        }
        public void ShowLeaderboard()
        {
            var sortedEntries = entries.OrderByDescending(e => e.Score).ToList();

            int position = 1;

            foreach (var entry in sortedEntries)
            {
                double winRate = entry.Rounds > 0
                    ? (double)entry.RoundsWon / entry.Rounds * 100
                    : 0;
                Console.WriteLine($"{position,-3} {entry.Name,-20} {entry.Score,8} kr | {entry.Rounds,5} rundor | {winRate,6:F1} %");
                position++;
            }
        }
        public LeaderboardEntry? GetPlayer(int position)
        {
            var sortedEntries = entries.OrderByDescending(e => e.Score).ToList();
            if (position >= 1 && position <= sortedEntries.Count)
            {
                return sortedEntries[position - 1];
            }
            return null;
        }
    }
}
