using System;
using System.Collections.Generic;
using System.Linq;

namespace LGoH_DeckSuggester
{
    public class HeroStat
    {
        public static class Power
        {
            public static long Calculate(Hero hero)
            {
                return CalculatePower(hero.Attack, hero.Recovery, hero.Health, hero.EventSkills.Warden);
            }

            public static long Calculate(long attack, long recovery, long health, bool isWarden)
            {
                return CalculatePower(attack, recovery, health, isWarden);
            }

            private static long CalculatePower(long attack, long recovery, long health, bool isWarden)
            {
                if (attack == 0 || recovery == 0 || health == 0)
                {
                    return 0;
                }

                if (isWarden)
                {
                    return (long) Math.Round((double) attack / 2 + (double) recovery * 1.5 + (double) health * .3);
                }

                return (long) Math.Round((double) attack / 3 + (double) recovery + (double) health / 5);
            }
        }

        public static class Affinity
        {
            public enum Type
            {
                Fire,
                Water,
                Earth,
                Light,
                Dark
            }

            public static readonly string[] Names = Enum.GetNames(typeof(Type));
            public static readonly Type[] Types = Enum.GetValues(typeof(Type)).Cast<Type>().ToArray();

            public static Type Parse(string affinity)
            {
                Type affinityType;
                Enum.TryParse(affinity, out affinityType);
                return affinityType;
            }

            private static Type[] counters = {Type.Earth, Type.Water, Type.Fire, Type.Dark, Type.Light};

            public static bool Counters(Type current, Type opponent)
            {
                return counters[(int) current] == opponent;
            }
        }
    }
}