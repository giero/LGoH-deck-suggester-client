using System;
using System.Collections.Generic;

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

        private List<Hero> _heroes;
        private string[] _affinities = {"Fire", "Water", "Earth", "Light", "Dark"};
        private Dictionary<string, BestDeck> _bestDecks;

        public DeckGenerator(Team team)
        {
            _heroes = team.Heroes;
            _heroes.Sort(delegate(Hero h1, Hero h2)
            {
                if (h1.CoreId == h2.CoreId)
                {
                    return (int) (h1.Attack - h2.Attack);
                }

                return h1.Name.CompareTo(h2.Name);
            });

            _bestDecks = new Dictionary<string, BestDeck>();
            foreach (var affinity in _affinities)
            {
                _bestDecks[affinity] = new BestDeck();
            }
        }

        public Dictionary<string, BestDeck> Generate()
        {
            var heroesLimit = _heroes.Count - 1;
            for (var h = heroesLimit; h >= 0; h--)
            {
                if (h < heroesLimit && _heroes[h].CoreId == _heroes[h + 1].CoreId)
                {
                    continue;
                }

                var heroes = new List<Hero>(_heroes);
                var leaderHero = heroes[h];

                heroes.RemoveAt(h);
                Console.WriteLine("Generetion for: " + leaderHero);
                Combinations(leaderHero, heroes, 4, 0, new Hero[4]);
            }

            return _bestDecks;
        }

        private void Combinations(Hero leader, IList<Hero> heroes, int len, int offset, IList<Hero> result)
        {
            if (len == 0)
            {
                var deckHeroes = new List<Hero> {leader};
                deckHeroes.AddRange(result);

                var deck = new Deck(deckHeroes);
                foreach (var affinity in _affinities)
                {
                    var deckStats = deck.Calculate(affinity);

                    if (deckStats.Power > _bestDecks[affinity].Power)
                    {
                        _bestDecks[affinity] = new BestDeck(deckStats.Power, deck);
                    }
                }

                return;
            }

            for (int i = offset, rl = result.Count, hl = heroes.Count; i <= hl - len; i++)
            {
                result[rl - len] = heroes[i];
                Combinations(leader, heroes, len - 1, i + 1, result);
            }
        }

        public long Possibilities
        {
            get
            {
                long combinations = 1;
                long heroesCount = _heroes.Count;

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