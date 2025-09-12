namespace NumeralConverter.Tests;

// Sample values provided in the tech task
public class ConverterTests
{
    [Theory]
    [InlineData(2022, "MMXXII")]
    [InlineData(1990, "MCMXC")]
    [InlineData(2008, "MMVIII")]
    [InlineData(1666, "MDCLXVI")]
    [InlineData(3999, "MMMCMXCIX")]
    [InlineData(1, "I")]
    [InlineData(1000, "M")]
    public void ConvertToRoman(ushort input, string expectedResult)
    {
        var result = Converter.ConvertToRoman(input);
        Assert.Equal(expectedResult, result);
    }
}