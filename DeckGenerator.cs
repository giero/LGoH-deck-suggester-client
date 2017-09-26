using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LGoH_DeckSuggester
{
    public class DeckGenerator
    {
        public struct BestDeck
        {
            public long Power;
            public Deck Deck;

            public BestDeck(long power = 0, Deck deck = null)
            {
                Power = power;
                Deck = deck;
            }
        }

        private List<Hero> heroes;
        private List<BestDeck> bestDecks;

        public DeckGenerator(List<Hero> heroes)
        {
            this.heroes = heroes;
            bestDecks = new List<BestDeck>(new BestDeck[5]);
        }

        public List<BestDeck> Generate()
        {
            Parallel.For(0, heroes.Count, h =>
            {
                List<Hero> heroesPool = new List<Hero>(heroes);
                Hero leaderHero = heroesPool[h];

                heroesPool.RemoveAt(h);

                Console.WriteLine("Generetion for: " + leaderHero);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                Combinations(leaderHero, heroesPool, 4, 0, new Hero[4]);

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

                Console.WriteLine("Generated for '" + leaderHero + "' in " + elapsedTime);
            });

            return bestDecks;
        }

        private void Combinations(Hero leader, IList<Hero> heroesPool, int len, int offset, IList<Hero> result)
        {
            if (len == 0)
            {
                Deck deck = new Deck(new[] {leader, result[0], result[1], result[2], result[3]});
                for (int i = 0; i < HeroStat.Affinity.Names.Length; i++)
                {
                    DeckStats deckStats = deck.Calculate(HeroStat.Affinity.Types[i]);
                    if (deckStats.Power > bestDecks[i].Power)
                    {
                        bestDecks[i] = new BestDeck(deckStats.Power, deck);
                    }
                }

                return;
            }

            for (int i = offset, rl = result.Count, hl = heroesPool.Count; i <= hl - len; i++)
            {
                result[rl - len] = heroesPool[i];
                Combinations(leader, heroesPool, len - 1, i + 1, result);
            }
        }

        public long Possibilities
        {
            get
            {
                long combinations = 1;
                long heroesCount = heroes.Count;

                // (n-1) * (n-2) * (n-3) * (n-4) / 4!
                for (long i = 1; i <= 4; ++i)
                {
                    combinations = combinations * (heroesCount - i) / i;
                }

                return heroesCount * combinations;
            }
        }
    }
}