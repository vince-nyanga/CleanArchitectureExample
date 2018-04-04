using System;
using CleanArchitecture.Modules;
using Domain.UseCases;
using Ninject;

namespace CleanArchitecture
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           
            IKernel kernel = new StandardKernel(new WeatherModule());
            var useCase = kernel.Get<GetWeatherInteractor>();
            const string city = "Harare";
            var weather = useCase.Handle(city);
            Console.WriteLine($"Weather for {city}:");
            Console.WriteLine($"Description: {weather.Description}");
            Console.WriteLine($"Min Temp: {weather.MinTemperature}°C");
            Console.WriteLine($"Max Temp: {weather.MaxTemperature}°C");
            Console.ReadLine();

        }
    }
}
