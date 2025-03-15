using Newtonsoft.Json;

namespace RadioPlayer.Domain;

public class Country
{
    [JsonProperty("name")]
    public required string Name { get; set; }
}