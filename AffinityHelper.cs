using System;

namespace LGoH_DeckSuggester
{
    public class AffinityHelper
    {
        public enum Affinity
        {
            Fire,
            Water,
            Earth,
            Light,
            Dark
        }

        public static bool Counters(Affinity current, Affinity opponent)
        {
            switch (current)
            {
                case Affinity.Fire:
                    return opponent == Affinity.Earth;
                case Affinity.Earth:
                    return opponent == Affinity.Water;
                case Affinity.Water:
                    return opponent == Affinity.Fire;
                case Affinity.Light:
                    return opponent == Affinity.Dark;
                case Affinity.Dark:
                    return opponent == Affinity.Light;
                default:
                    return false;
            }
        }

        public static Array GetAffinities()
        {
            return Enum.GetValues(typeof(Affinity));
        }
    }
}