using System;
using System.Configuration;
using Data.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Data.Api
{
    public class OpenWeatherApi: IWeatherApi
    {
        private readonly RestClient _client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
        private readonly string _apiKey;

        public OpenWeatherApi(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public WeatherData GetWeatherData(string city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            var request = new RestRequest(Method.GET);
            request.AddParameter("units", "metric");
            request.AddParameter("q", city);
            request.AddParameter("APPID", _apiKey);

            var response = _client.Execute(request);

            return JsonConvert.DeserializeObject<WeatherData>(response.Content);
        }
    }
}
