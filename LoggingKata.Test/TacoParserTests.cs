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
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", -84.683302)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            TacoParser instance = new TacoParser();
            //Act
            ITrackable actual = instance.Parse(line);            
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            TacoParser instance = new TacoParser();
            //Act
            ITrackable actual = instance.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }


        //TODO: Create a test ShouldParseLatitude

    }
}
