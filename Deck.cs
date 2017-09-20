using System;
using System.Collections.Generic;
using System.Text;

namespace LGoH_DeckSuggester
{
    public class Deck
    {
        public Deck(List<Hero> heroes)
        {
            var names = new StringBuilder();
            heroes.ForEach(delegate(Hero hero) { names.Append(hero.Name + ", "); });
            
            Console.WriteLine(names.ToString().TrimEnd(',', ' '));
        }
    }
}