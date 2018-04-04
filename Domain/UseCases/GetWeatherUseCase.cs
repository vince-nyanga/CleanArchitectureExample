using System;
using Domain.Entities;
using Domain.Repository;

namespace Domain.UseCases
{
    public class GetWeatherUseCase: IUseCase<WeatherEntity>
    {
        private readonly IRepository _repository;

        public GetWeatherUseCase(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public WeatherEntity Execute(object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (!(data is string))
            {
                throw new ArgumentException("Data must be a string");
            }

            return _repository.GetWeather((string) data);
        }
    }
}
