using System.Text.RegularExpressions;

namespace NumeralConverter;

public static class Converter
{
    private static readonly (short value, string Symbol)[] ConversionTable =
    {
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    };
    public static string ConvertToRoman(short number)
    {
        if (number is < 1 or > 3999)
            return "Please enter a valid number between 1 and 3999";
        
        var result = string.Empty;
        
        foreach (var (value, romanSymbol) in ConversionTable)
        {
            // Reduce the number by the biggest available roman symbol
            while (number >= value)
            {
                number -= value;
                result += romanSymbol;
            }
        }
        
        return result;
    }
    
    public static short ConvertToBase10(string romanNumber)
    {
        ValidateRomanNumber(romanNumber);
        
        short result = 0;
        var index = 0;

        while (index < romanNumber.Length)
        {
            foreach (var (value, symbol) in ConversionTable)
            {
                if (romanNumber.AsSpan(index).StartsWith(symbol))
                {
                    result += value;
                    index += symbol.Length;
                    break;
                }
            }
        }

        return result;
    }
    
    private static void ValidateRomanNumber(string romanNumber)
    {
        if (string.IsNullOrWhiteSpace(romanNumber))
            throw new ArgumentException("Input cannot be null or empty.");
        
        var invalidRepetition  = Regex.Match(romanNumber, @"(.)\1{3}");
        if (invalidRepetition.Success)
            throw new ArgumentException($"Input is not a valid roman number '{invalidRepetition.Groups[1].Value}' " +
                                        "is repeated four or more times consecutively."); ;
        
        var containsValidSymbols  = Regex.IsMatch(romanNumber, @"^[IVXLCDM]+$", RegexOptions.IgnoreCase);
        if (!containsValidSymbols)
            throw new ArgumentException($"Input is not a valid roman number");
    }
}