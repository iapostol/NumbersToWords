//745.00  => seven hundred and forty five

using Xunit;
using static NumberToWords.Converter;

namespace NumberToWords
{
    public class ConverterShould
    {
        private readonly Converter c;

        public ConverterShould()
        {
            c = new Converter();
        }
        [Theory]
        [InlineData("zero", 0)]
        [InlineData("one", 1)]
        [InlineData("two", 2)]
        [InlineData("eleven", 11)]
        [InlineData("nineteen", 19)]
        [InlineData("twenty", 20)]
        [InlineData("twenty-one", 21)]
        [InlineData("thirty-five", 35)]
        [InlineData("ninety-nine", 99)]
        [InlineData("one hundred", 100)]
        [InlineData("two hundred", 200)]
        [InlineData("nine hundred", 900)]
        [InlineData("one hundred one", 101)]
        [InlineData("nine hundred nine", 909)]
        [InlineData("one hundred thirty-four", 134)]
        [InlineData("nine hundred eighty-four", 984)]
        [InlineData("three thousand four hundred twenty-two", 3422)]
        [InlineData("twenty-three thousand one hundred twelve", 23112)]
        [InlineData("two million three hundred eleven thousand two hundred eleven", 2311211)]
        [InlineData("one billion two hundred thirty-four million six hundred seventy-two thousand three hundred forty-six", 1234672346)]
        [InlineData("one trillion two hundred thirty-four billion six hundred seventy-two million three hundred forty-six thousand two hundred thirty-four", 1234672346234)]
        [InlineData("one quadrillion two hundred thirty-four trillion six hundred seventy-two billion three hundred forty-six million two hundred thirty-four thousand two hundred thirty-four", 1234672346234234)]
        [InlineData("one quintillion two hundred thirty-four quadrillion six hundred seventy-two trillion three hundred forty-six billion two hundred thirty-four million two hundred thirty-four thousand nine hundred eighty-five", 1234672346234234985)]
        public void Convert(string word, long number)
        {
            Assert.Equal(word, WordFor(number));
        }
    }
}