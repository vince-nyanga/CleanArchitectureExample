using System;
using Data.Api;
using Data.Entities;
using Domain.Entities;
using Domain.Mappers;
using Domain.Repository;

namespace Data.Repository
{
    public class WeatherRepository: IRepository
    {
        private readonly IWeatherApi _api;
        private readonly IMapper<WeatherData, WeatherEntity> _mapper;

        public WeatherRepository(IWeatherApi api,IMapper<WeatherData, WeatherEntity> mapper)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public WeatherEntity GetWeather(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            return _mapper.MapFrom(_api.GetWeatherData(cityName));
        }
    }
}
