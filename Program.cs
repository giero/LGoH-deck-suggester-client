using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LGoH_DeckSuggester
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Team team = new Team();
            team.LoadFromCompressedJson(File.ReadAllText(@"cards.txt"));

            DeckGenerator deckGenerator = new DeckGenerator(team.Heroes);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<DeckGenerator.BestDeck> bestDecks = deckGenerator.Generate();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

            for (int i = 0; i < bestDecks.Count; i++)
            {
                Console.WriteLine(HeroStat.Affinity.Names[i] + "(" + bestDecks[i].Power + ")");
                Console.WriteLine(bestDecks[i].Deck);
            }

            Console.WriteLine("All calulation done in: " + elapsedTime);
        }
    }
}