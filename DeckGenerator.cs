using System;
using System.Collections.Generic;

namespace LGoH_DeckSuggester
{
    public class DeckGenerator
    {
        private readonly List<Hero> _heroes;
        private Deck bestDeck;

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

        public DeckGenerator(Team team)
        {
            _heroes = team.Heroes;
        }

        public void Generate()
        {
            for (var i = 0; i < _heroes.Count; i++)
            {
                var heroes = new List<Hero>(_heroes);
                var leaderHero = heroes[i];

                heroes.RemoveAt(i);
                Combinations(leaderHero, heroes, 4, 0, new Hero[4]);
            }
        }

        private void Combinations(Hero leader, IList<Hero> heroes, int len, int offset, IList<Hero> result)
        {
            if (len == 0)
            {
                var deckHeroes = new List<Hero> {leader};
                deckHeroes.AddRange(result);

                var deck = new Deck(deckHeroes);
                
                return;
            }

            for (int i = offset, rl = result.Count, hl = heroes.Count; i <= hl - len; i++)
            {
                result[rl - len] = heroes[i];
                Combinations(leader, heroes, len - 1, i + 1, result);
            }
        }
    }
}
/*

function combinations(leaderHero, heroes, len, offset, result) {
        if (len === 0) {
            if (!(++counter % onePercentOfPossibilities)) {
                this.postMessage(Math.round(counter / possibilities * 100));
            }

            var deck = new Deck(
                [leaderHero, result[0], result[1], result[2], result[3]], //way faster way than .concat
                options
            );
            for (var affinity in bestDecks) {
                var deckStats = deck.calculate(affinity);

                if (deckStats.power > bestDecks[affinity].power.value) {
                    bestDecks[affinity].power = {
                        value: deckStats.power,
                        heroes: deck.heroes,
                        stats: deck.getStats()
                    };
                }
                if (deckStats.attack > bestDecks[affinity].attack.value) {
                    bestDecks[affinity].attack = {
                        value: deckStats.attack,
                        heroes: deck.heroes,
                        stats: deck.getStats()
                    };
                }
                if (deckStats.attack_and_health > bestDecks[affinity].attack_and_health.value) {
                    bestDecks[affinity].attack_and_health = {
                        value: deckStats.attack_and_health,
                        heroes: deck.heroes,
                        stats: deck.getStats()
                    };
                }
            }

            return;
        }

        for (var i = offset, rl = result.length, hl = heroes.length; i <= hl - len; i++) {
            result[rl - len] = heroes[i];
            combinations(leaderHero, heroes, len - 1, i + 1, result);
        }
    }


*/