using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {        

            //Arrange
            var tacoParser = new TacoParser();         
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var result = tacoParser.Parse(line);
            var actualLongitude = result.Location.Longitude;

            //Arrange

            //Act

            //Assert

            Assert.Equal(expected, actualLongitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var result = tacoParser.Parse(line);
            var actualLatitude = result.Location.Latitude;

            Assert.Equal(expected, actualLatitude);
        }


        //TODO: Create a test ShouldParseLatitude

    }
}
