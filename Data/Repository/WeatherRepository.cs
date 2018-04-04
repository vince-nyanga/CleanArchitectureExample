using Data.Api;
using Data.Entities;
using Domain.Entities;
using Domain.Mappers;
using Domain.Repository;

namespace Data.Repository
{
    public class WeatherRepository: IRepository
    {
        private readonly IApi _api;
        private readonly IMapper<WeatherData, WeatherEntity> _mapper;

        public WeatherRepository(IApi api,IMapper<WeatherData, WeatherEntity> mapper)
        {
            _api = api ?? throw new System.ArgumentNullException(nameof(api));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }


        public WeatherEntity GetWeather(string cityName)
        {
            if (cityName == null)
            {
                throw new System.ArgumentNullException(nameof(cityName));
            }

            return _mapper.MapFrom(_api.GetWeatherData(cityName));
        }
    }
}
