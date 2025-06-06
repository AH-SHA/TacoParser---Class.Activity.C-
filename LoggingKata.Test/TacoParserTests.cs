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

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData(34.035985, -84.683302, Taco Bell Acworth..., -84.683302)]
        [InlineData(34.087508,-84.575512,Taco Bell Acworth..., -84.575512)]
        [InlineData(34.376395,-84.913185,Taco Bell Adairsvill..., -84.913185)]
        [InlineData(33.22997,-86.805275,Taco Bell Alabaste..., -86.805275)]
        
        //Add additional inline data. Refer to your CSV file.

        [Fact]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser2 = new TacoParser();
                    // a constructor is a special member method
            //Act   

            var actual = tacoParser2.Parse(line);

            //Above you add the name of the method contained within the tacoParser constructor after the . (period)  and in parenthesis place the data to be tested.

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData(34.035985, -84.683302, Taco Bell Acworth..., -84.683302)]
        [InlineData(34.087508, -84.575512, Taco Bell Acworth..., -84.575512)]






        //TODO: Create a test called ShouldParseLatitude

        [Fact]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser3 = new TacoParser();

            //Act
            var actual = tacoParser3.Parse(line); 


            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData(34.035985, -84.683302, Taco Bell Acworth..., 34.035985)]
        [InlineData(34.087508, -84.575512, Taco Bell Acworth..., 34.087508)]






    }
}
