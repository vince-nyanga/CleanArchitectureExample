using System.Configuration;
using Data.Api;
using Data.Entities;
using Data.Mappers;
using Data.Repository;
using Domain.Entities;
using Domain.Mappers;
using Domain.Repository;
using Domain.UseCases;
using Ninject.Modules;

namespace CleanArchitecture.Modules
{
    public class WeatherModule: NinjectModule
    {
        public override void Load()
        {
            var apiKey = ConfigurationManager.AppSettings["API_KEY"];
            Bind<IMapper<WeatherData, WeatherEntity>>().To<WeatherDataEntityMapper>();
            Bind<IWeatherApi>().To<OpenWeatherApi>().WithConstructorArgument("apiKey",apiKey);
            Bind<IRepository>().To<WeatherRepository>();
            Bind<GetWeatherInteractor>().ToSelf().InSingletonScope();
        }
    }
}
