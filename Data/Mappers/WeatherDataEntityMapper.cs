using Data.Entities;
using Domain.Entities;
using Domain.Mappers;

namespace Data.Mappers
{
    public class WeatherDataEntityMapper: IMapper<WeatherData, WeatherEntity>
    {
        public WeatherEntity MapFrom(WeatherData input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException(nameof(input));
            }

            return new WeatherEntity
            {
                MinTemperature = input.Main.MinTemperature,
                MaxTemperature = input.Main.MaxTemperature,
                Description = input.WeatherList[0].Description
            };
        }
    }
}
