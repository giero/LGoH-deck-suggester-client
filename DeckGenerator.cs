using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            var heroesLimit = heroes.Count - 1;
            for (var h = heroesLimit; h >= 0; h--)
            {
                if (h < heroesLimit && heroes[h].CoreId == heroes[h + 1].CoreId)
                {
                    continue;
                }

                var heroesPool = new List<Hero>(heroes);
                var leaderHero = heroesPool[h];

                heroesPool.RemoveAt(h);

                Console.WriteLine("Generetion for: " + leaderHero);

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                Combinations(leaderHero, heroesPool, 4, 0, new Hero[4]);

                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";

                Console.WriteLine("Generated for '" + leaderHero + "' in " + elapsedTime);
            }

            return bestDecks;
        }

        private void Combinations(Hero leader, IList<Hero> heroesPool, int len, int offset, IList<Hero> result)
        {
            if (len == 0)
            {
                var deck = new Deck(new[] {leader, result[0], result[1], result[2], result[3]});
                for (var i = 0; i < HeroStat.Affinity.List.Length; i++)
                {
                    var deckStats = deck.Calculate(HeroStat.Affinity.List[i]);
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