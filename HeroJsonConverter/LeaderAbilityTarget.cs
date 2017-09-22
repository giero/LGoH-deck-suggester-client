using System;
using Newtonsoft.Json;

namespace LGoH_DeckSuggester.HeroJsonConverter
{
    public class LeaderAbilityTarget : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // won't be used
            throw new NotImplementedException();
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    return new[] {serializer.Deserialize<string>(reader)};
                case JsonToken.StartArray:
                    return serializer.Deserialize<string[]>(reader);
                default:
                    throw new Exception("Cannot convert Target");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // won't be used
            throw new NotImplementedException();
        }
    }
}