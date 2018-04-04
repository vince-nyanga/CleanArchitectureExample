using System;
using Domain.Entities;
using Domain.Repository;
using Domain.UseCases;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UseCaseTests
    {
       
        private readonly WeatherEntity _weather = new WeatherEntity
        {
            Description = "Cloudy",
            MaxTemperature = 25,
            MinTemperature = 12
        };

        private GetWeatherUseCase _useCase;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetWeather("Harare")).Returns(_weather);
            _useCase = new GetWeatherUseCase(mock.Object);
        }

        [Test]
        public void TestGetWeather_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _useCase.Execute(null));
        }

        [Test]
        public void TestGetWeather_InvalidParam()
        {
            Assert.Throws<ArgumentException>(() => _useCase.Execute(1));
        }

        [Test]
        public void TestGetWeather()
        {
            var result = _useCase.Execute("Harare");
            Assert.NotNull(result);
            Assert.AreEqual(result.MaxTemperature, _weather.MaxTemperature);
            Assert.AreEqual(result.MinTemperature, _weather.MinTemperature);
            Assert.AreEqual(result.Description, _weather.Description);
        }
    }
}
