using System;
using System.Collections.Generic;
using Data.Api;
using Data.Mappers;
using Data.Repository;
using Domain.Repository;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DataTests
    {
        private IRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var mockApi = new Mock<IWeatherApi>();
            mockApi.Setup(api => api.GetWeatherData("Harare")).Returns(TestUtils.TestWeatherData);
            _repository = new WeatherRepository(mockApi.Object, new WeatherDataEntityMapper());

        }

        [Test]
        public void GetWeather()
        {
            var result = _repository.GetWeather("Harare");
            Assert.NotNull(result);
            Assert.AreEqual(TestUtils.TestWeatherEntity.MinTemperature, result.MinTemperature);
            Assert.AreEqual(TestUtils.TestWeatherEntity.MaxTemperature, result.MaxTemperature);
            Assert.AreEqual(TestUtils.TestWeatherEntity.Description, result.Description);
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidCityNames))]
        public void GetWeather_InvalidCityName(string cityName)
        {
            Assert.Throws<ArgumentNullException>(() => _repository.GetWeather(cityName));
        }

        public static IEnumerable<string> GetInvalidCityNames()
        {
            yield return "";
            yield return null;
        }
    }
}
