using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LGoH_DeckSuggester
{
    public class Team
    {
        public List<Hero> Heroes { get; set; }

        public Team()
        {
            Heroes = new List<Hero>();
        }

        public void LoadFromCompressedJson(string compressedJson)
        {
            var heroesData = LZString.decompressFromEncodedURIComponent(compressedJson);
            Heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesData);

            SortHeroes();
        }

        private void SortHeroes()
        {
            Heroes.Sort(delegate(Hero h1, Hero h2)
            {
                if (h1.CoreId == h2.CoreId)
                {
                    return (int) (h1.Attack - h2.Attack);
                }

                return string.CompareOrdinal(h1.Name, h2.Name);
            });
        }
    }
}