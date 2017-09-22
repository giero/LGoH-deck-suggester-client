using System.Text;
using LGoH_DeckSuggester.HeroJsonConverter;
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

        private string affinity;

        [JsonProperty("affinity")]
        public string Affinity
        {
            get => affinity;
            set
            {
                affinity = value;
                AffinityType = HeroStat.Affinity.Parse(value);
            }
        }

        public HeroStat.Affinity.Type AffinityType { get; set; }

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

        public long Power => HeroStat.Power.Calculate(this);


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
        public long? Commander { get; set; }

        [JsonProperty("Bounty Hunter")]
        public long? BountyHunter { get; set; }

        [JsonProperty("Slayer")]
        public long? Slayer { get; set; }

        [JsonProperty("Warden")]
        public bool Warden { get; set; }
    }

    public class LeaderAbility
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modifiers")]
        public Modifiers Modifiers { get; set; }

        [JsonProperty(PropertyName = "target")]
        [JsonConverter(typeof(LeaderAbilityTarget))]
        public string[] Target { get; set; }
    }

    public class Modifiers
    {
        [JsonProperty("attack")]
        public double? Attack { get; set; }

        [JsonProperty("recovery")]
        public double? Recovery { get; set; }

        [JsonProperty("health")]
        public double? Health { get; set; }
    }

    public class HeroConverter
    {
        public static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }

    public partial class Hero
    {
        public Hero FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Hero>(json, HeroConverter.Settings);
        }

        public bool CanApplyLeaderStats(string[] leaderTargets)
        {
            for (var i = 0; i < leaderTargets.Length; i++)
            {
                if (!MatchesWithStat(leaderTargets[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool MatchesWithStat(string stat)
        {
            return stat.Equals(affinity)
                   || stat.Equals(Type)
                   || stat.Equals(Species)
                   || stat.Equals("Bounty Hunter") && EventSkills.BountyHunter != null
                   || (Name.Equals("Vulcan Fireshaper") || Name.Equals("Vulcan Flameblood")) && Species.Contains(stat);
        }

        public override string ToString()
        {
            var heroData = new StringBuilder();

            heroData.Append(Name);
            heroData.Append(" (");
            heroData.Append(Attack);
            heroData.Append("/");
            heroData.Append(Recovery);
            heroData.Append("/");
            heroData.Append(Health);
            heroData.Append(")");

            return heroData.ToString();
        }
    }
}