using System.Collections.Generic;
using Newtonsoft.Json;

namespace LGoH_DeckSuggester
{
    public class Team
    {
        public List<Hero> Heroes { get; }

        public Team(string heroesCompressedData)
        {
            var heroesData = LZString.decompressFromEncodedURIComponent(heroesCompressedData);
            Heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesData);
        }
    }
}