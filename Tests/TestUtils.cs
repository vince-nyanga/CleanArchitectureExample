using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Domain.Entities;

namespace Tests
{
    public static class TestUtils
    {
        public static WeatherData TestWeatherData => new WeatherData
        {
            Main = new Main
            {
                MaxTemperature = 25,
                MinTemperature = 12
            },
            WeatherList = new List<Weather>()
            {
                new Weather
                {
                    Description = "Cloudy"
                }
            }
        };

        public static WeatherEntity TestWeatherEntity => new WeatherEntity
        {
            Description = "Cloudy",
            MaxTemperature = 25,
            MinTemperature = 12
        };
    }
}
