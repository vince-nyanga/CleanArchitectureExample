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
            var data = TestUtils.TestWeatherData;

            var mapper = new WeatherDataEntityMapper();
            var entity = mapper.MapFrom(data);


            Assert.AreEqual(25, entity.MaxTemperature);
            Assert.AreEqual(12, entity.MinTemperature);
            Assert.AreEqual("Cloudy", entity.Description);
        }
    }
}
