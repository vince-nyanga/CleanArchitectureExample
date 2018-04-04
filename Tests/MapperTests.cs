using System.Collections.Generic;
using Data.Entities;
using Data.Mappers;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void TestWeatherDataEntityMapper()
        {
            var data = new WeatherData
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

            var mapper = new WeatherDataEntityMapper();
            var entity = mapper.MapFrom(data);


            Assert.AreEqual(25, entity.MaxTemperature);
            Assert.AreEqual(12, entity.MinTemperature);
            Assert.AreEqual("Cloudy", entity.Description);
        }
    }
}
