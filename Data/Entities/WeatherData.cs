using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Data.Entities
{
    public class WeatherData
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public IList<Weather> WeatherList { get; set; }
    }
}
