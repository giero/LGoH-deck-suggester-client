﻿using System;

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
            public static readonly string[] List = {"Fire", "Water", "Earth", "Light", "Dark"};

            public static bool Counters(string current, string opponent)
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
        }
    }
}