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

       

        private GetWeatherInteractor _interactor;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetWeather("Harare")).Returns(TestUtils.TestWeatherEntity);
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
            Assert.AreEqual(TestUtils.TestWeatherEntity.MaxTemperature, result.MaxTemperature);
            Assert.AreEqual(TestUtils.TestWeatherEntity.MinTemperature, result.MinTemperature);
            Assert.AreEqual(TestUtils.TestWeatherEntity.Description, result.Description);
        }
    }
}
