using System;
using Newtonsoft.Json;

namespace LGoH_DeckSuggester
{
    public partial class Hero
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("coreId")]
        public string CoreId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("awakening")]
        public long Awakening { get; set; }


        [JsonProperty("affinity")]
        public string Affinity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }


        [JsonProperty("attack")]
        public long Attack { get; set; }

        [JsonProperty("recovery")]
        public long Recovery { get; set; }

        [JsonProperty("health")]
        public long Health { get; set; }

        public long Power
        {
            get
            {
                if (Attack == 0 || Recovery == 0 || Health == 0)
                {
                    return 0;
                }

                if (EventSkills.Warden != null)
                {
                    return (long) Math.Round((double) Attack / 2 + (double) Recovery * 1.5 + (double) Health * .3);
                }

                return (long) Math.Round((double) Attack / 3 + (double) Recovery + (double) Health / 5);
            }
        }


        [JsonProperty("eventSkills")]
        public EventSkills EventSkills { get; set; }

        [JsonProperty("defenderSkill")]
        public string DefenderSkill { get; set; }

        [JsonProperty("counterSkill")]
        public string CounterSkill { get; set; }

        [JsonProperty("leaderAbility")]
        public LeaderAbility LeaderAbility { get; set; }


        [JsonProperty("evolveFrom")]
        public string EvolveFrom { get; set; }

        [JsonProperty("evolveInto")]
        public string EvolveInto { get; set; }
    }

    public class EventSkills
    {
        [JsonProperty("Commander")]
        public long Commander { get; set; }

        [JsonProperty("Bounty Hunter")]
        public long BountyHunter { get; set; }

        [JsonProperty("Slayer")]
        public long Slayer { get; set; }

        [JsonProperty("Warden")]
        public string Warden { get; set; }
    }

    public class LeaderAbility
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modifiers")]
        public Modifiers Modifiers { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    public class Modifiers
    {
        [JsonProperty("attack")]
        public double Attack { get; set; }

        [JsonProperty("recovery")]
        public double Recovery { get; set; }

        [JsonProperty("health")]
        public double Health { get; set; }
    }


    public partial class Hero
    {
        public static Hero FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Hero>(json, HeroConverter.Settings);
        }
    }

//    public static class Serialize
//    {
//        public static string ToJson(this Hero self)
//        {
//            return JsonConvert.SerializeObject(self, HeroConverter.Settings);
//        }
//    }

    public class HeroConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}