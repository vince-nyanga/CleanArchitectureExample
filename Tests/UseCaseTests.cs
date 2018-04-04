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

        private GetWeatherInteractor _interactor;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetWeather("Harare")).Returns(_weather);
            _interactor = new GetWeatherInteractor(mock.Object);
        }

        [Test]
        public void TestGetWeather_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.Handle(null));
        }

        [Test]
        public void TestGetWeather_InvalidParam()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.Handle(""));
        }

        [Test]
        public void TestGetWeather()
        {
            var result = _interactor.Handle("Harare");
            Assert.NotNull(result);
            Assert.AreEqual(result.MaxTemperature, _weather.MaxTemperature);
            Assert.AreEqual(result.MinTemperature, _weather.MinTemperature);
            Assert.AreEqual(result.Description, _weather.Description);
        }
    }
}
