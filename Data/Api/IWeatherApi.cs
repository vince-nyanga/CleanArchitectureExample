using Data.Entities;

namespace Data.Api
{
    public interface IWeatherApi
    {
        WeatherData GetWeatherData(string city);
    }
}
