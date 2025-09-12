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
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void ConvertToRoman_WithValidInput_ReturnsCorrectRomanValue(
        short input,
        string expectedResult)
    {
        // Act
        var result = Converter.ConvertToRoman(input);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(4000)]
    [InlineData(null)]
    public void ConvertToRoman_WithInvalidInput_ReturnsError(short input)
    {
        // Act
        var result = Converter.ConvertToRoman(input);
        
        // Assert
        Assert.Equal("Please enter a valid number between 1 and 3999", result);
    }
}