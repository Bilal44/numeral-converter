using System.Text.RegularExpressions;

namespace NumeralConverter;

public static class Converter
{
    private static readonly (int value, string Symbol)[] ConversionTable =
    {
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    };
    
    public static string ConvertToRoman(int number)
    {
        if (number is < 1 or > 3999)
            return "Please enter a valid number between 1 and 3999.";
        
        var result = string.Empty;
        
        foreach (var (value, romanSymbol) in ConversionTable)
        {
            // Reduce the number by the largest available roman symbol
            while (number >= value)
            {
                number -= value;
                result += romanSymbol;
            }
        }
        
        return result;
    }
    
    public static int ConvertToBase10(string romanNumber)
    {
        ValidateRomanNumber(romanNumber);
        
        var result = 0;
        var index = 0;

        while (index < romanNumber.Length)
        {
            foreach (var (value, symbol) in ConversionTable)
            {
                // Retrieve the matching roman symbol (largest first)
                // and add its value to the running total
                if (romanNumber.ToUpper().AsSpan(index).StartsWith(symbol))
                {
                    result += value;
                    index += symbol.Length;
                }
            }
        }
        
        return result;
    }
    
    private static void ValidateRomanNumber(string romanNumber)
    {
        if (string.IsNullOrWhiteSpace(romanNumber))
            throw new ArgumentException("Please provide a valid roman number.");
        
        var containsValidSymbols  = Regex.IsMatch(romanNumber, "^[IVXLCDM]+$", RegexOptions.IgnoreCase);
        if (!containsValidSymbols)
            throw new ArgumentException("Please provide a valid roman number.");
        
        var invalidRepetition  = Regex.Match(romanNumber, @"(.)\1{3}");
        if (invalidRepetition.Success)
            throw new ArgumentException($"Not a valid roman number since '{invalidRepetition.Groups[1].Value}' " +
                                        "is repeated more than three times.");
        
    }
}