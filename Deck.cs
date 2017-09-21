using System;
using System.Collections.Generic;
using System.Text;

namespace LGoH_DeckSuggester
{
    public struct DeckStats
    {
        public long Attack;
        public long Power;

        public DeckStats(long attack = 0, long power = 0)
        {
            Attack = attack;
            Power = power;
        }
    }

    public class Deck
    {
        private List<Hero> _heroes;
        private string[] _liderTargets;
        private Modifiers _leaderModifiers;

        public Deck(List<Hero> heroes)
        {
            _heroes = heroes;
            _liderTargets = heroes[0].LeaderAbility.Target;
            _leaderModifiers = heroes[0].LeaderAbility.Modifiers;
        }

        public DeckStats Calculate(string opponentAffinity)
        {
            var deckStats = new DeckStats();

            _heroes.ForEach(delegate(Hero hero)
            {
                ApplyAffinityBonus(ref hero, opponentAffinity);
                ApplyLeaderAbilityBonus(ref hero);
//                ApplyEventBonus(ref deckHero);

                deckStats.Attack += hero.Attack;
                deckStats.Power += hero.Power;
            });

            return deckStats;
        }

        private void ApplyAffinityBonus(ref Hero hero, string opponentAffinity)
        {
            if (Counters(hero.Affinity, opponentAffinity))
            {
                hero.Attack <<= 1;
            }
            else if (Counters(opponentAffinity, hero.Affinity))
            {
                hero.Attack >>= 1;
            }
        }

        private static bool Counters(string current, string opponent)
        {
            switch (current)
            {
                case "Fire":
                    return opponent == "Earth";
                case "Earth":
                    return opponent == "Water";
                case "Water":
                    return opponent == "Fire";
                case "Light":
                    return opponent == "Dark";
                case "Dark":
                    return opponent == "Light";
                default:
                    return false;
            }
        }

        private void ApplyLeaderAbilityBonus(ref Hero hero)
        {
            if (!hero.CanApplyLeaderStats(_liderTargets))
            {
                return;
            }

            if (_leaderModifiers.Attack != null)
            {
                hero.Attack = (long) Math.Round(hero.Attack * (double) _leaderModifiers.Attack);
            }

            if (_leaderModifiers.Recovery != null)
            {
                hero.Recovery = (long) Math.Round(hero.Recovery * (double) _leaderModifiers.Recovery);
            }

            if (_leaderModifiers.Health != null)
            {
                hero.Health = (long) Math.Round(hero.Health * (double) _leaderModifiers.Health);
            }
        }

        public override string ToString()
        {
            var heroesData = new StringBuilder();
            for (var i = 0; i < _heroes.Count; i++)
            {
                heroesData.Append(_heroes[i]);
                heroesData.Append("\n");
            }

            return heroesData.ToString();
        }
    }
}