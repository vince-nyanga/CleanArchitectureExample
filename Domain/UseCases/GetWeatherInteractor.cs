using System;
using Domain.Entities;
using Domain.Repository;

namespace Domain.UseCases
{
    public class GetWeatherInteractor: IRequestHandler<string,WeatherEntity>
    {
        private readonly IRepository _repository;

        public GetWeatherInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public WeatherEntity Handle(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            return _repository.GetWeather((string) data);
        }
    }
}
