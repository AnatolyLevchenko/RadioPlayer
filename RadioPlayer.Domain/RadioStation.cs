using Newtonsoft.Json;

namespace RadioPlayer.Domain;

public class RadioStation
{
    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }

    [JsonProperty("favicon")]
    public required string Favicon { get; set; }
}