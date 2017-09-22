using System;
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

    public struct HeroBaseStats
    {
        public long Attack;
        public long Recovery;
        public long Health;
        public HeroStat.Affinity.Type AffinityType;
        public bool IsWarden;

        public HeroBaseStats(Hero hero)
        {
            Attack = hero.Attack;
            Recovery = hero.Recovery;
            Health = hero.Health;
            AffinityType = hero.AffinityType;
            IsWarden = hero.EventSkills.Warden;
        }
    }

    public class Deck
    {
        private Hero[] heroes;
        private string[] liderTargets;
        private Modifiers leaderModifiers;

        public Deck(Hero[] heroes)
        {
            this.heroes = heroes;
            liderTargets = heroes[0].LeaderAbility.Target;
            leaderModifiers = heroes[0].LeaderAbility.Modifiers;
        }

        public DeckStats Calculate(HeroStat.Affinity.Type opponentAffinity)
        {
            var deckStats = new DeckStats();

            foreach (var hero in heroes)
            {
                var deckHeroBaseStats = new HeroBaseStats(hero);

                ApplyAffinityBonus(ref deckHeroBaseStats, opponentAffinity);
                ApplyLeaderAbilityBonus(hero, ref deckHeroBaseStats);
//                ApplyEventBonus(ref deckHero);

                deckStats.Attack += deckHeroBaseStats.Attack;
                deckStats.Power += HeroStat.Power.Calculate(
                    deckHeroBaseStats.Attack,
                    deckHeroBaseStats.Recovery,
                    deckHeroBaseStats.Health,
                    deckHeroBaseStats.IsWarden
                );
            }

            return deckStats;
        }

        private static void ApplyAffinityBonus(ref HeroBaseStats heroBaseStats, HeroStat.Affinity.Type opponentAffinity)
        {
            if (HeroStat.Affinity.Counters(heroBaseStats.AffinityType, opponentAffinity))
            {
                heroBaseStats.Attack <<= 1;
            }
            else if (HeroStat.Affinity.Counters(opponentAffinity, heroBaseStats.AffinityType))
            {
                heroBaseStats.Attack >>= 1;
            }
        }

        private void ApplyLeaderAbilityBonus(Hero hero, ref HeroBaseStats deckHeroBaseStats)
        {
            if (!hero.CanApplyLeaderStats(liderTargets))
            {
                return;
            }

            if (leaderModifiers.Attack != null)
            {
                deckHeroBaseStats.Attack =
                    (long) Math.Round(deckHeroBaseStats.Attack * (double) leaderModifiers.Attack);
            }

            if (leaderModifiers.Recovery != null)
            {
                deckHeroBaseStats.Recovery =
                    (long) Math.Round(deckHeroBaseStats.Recovery * (double) leaderModifiers.Recovery);
            }

            if (leaderModifiers.Health != null)
            {
                deckHeroBaseStats.Health =
                    (long) Math.Round(deckHeroBaseStats.Health * (double) leaderModifiers.Health);
            }
        }

        public override string ToString()
        {
            var heroesData = new StringBuilder();
            foreach (Hero hero in heroes)
            {
                heroesData.Append(hero);
                heroesData.Append("\n");
            }

            return heroesData.ToString();
        }
    }
}