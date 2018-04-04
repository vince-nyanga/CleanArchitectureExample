using Data.Entities;

namespace Data.Api
{
    public interface IApi
    {
        WeatherData GetWeatherData(string city);
    }
}
