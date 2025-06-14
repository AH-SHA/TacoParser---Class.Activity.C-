using Newtonsoft.Json.Linq;
using System;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using Xunit;
using static System.Formats.Asn1.AsnWriter;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            var actual2 = tacoParser.Parse("32.571331, -85.499655, Taco Bell Auburn...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", -84.683302)]
        [InlineData("34.795116, -86.97191, Taco Bell Athens...", -86.97191)]
        [InlineData("34.018008, -86.079099,Taco Bell Attall...", -86.079099)]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", -85.499655)]

        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParserInstance = new TacoParser();
                    // a constructor is a special member method
            //Act   

            var actual = tacoParserInstance.Parse(line);

            //Above you add the name of the method contained within the tacoParser constructor after the . (period)  and in parenthesis place the data to be tested.

            //Assert
            Assert.Equal(expected,actual.Location.Longitude);
        }

      

        //TODO: Create a test called ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", 34.035985)]
        [InlineData("34.795116, -86.97191, Taco Bell Athens..." , 34.795116)]
        [InlineData("34.018008, -86.079099,Taco Bell Attall...", 34.018008)]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", 32.571331)]
       
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line); 


            //Assert
            Assert.Equal(expected,actual.Location.Latitude);
        }

        






    }
}
