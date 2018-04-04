using Newtonsoft.Json;

namespace Data.Entities
{
    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
