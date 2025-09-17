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
        if (string.IsNullOrWhiteSpace(romanNumber))
            throw new ArgumentException("A roman number value must be provided."); 
        
        romanNumber = romanNumber.ToUpperInvariant();
        ValidateRomanNumber(romanNumber);
        
        var result = 0;
        var index = 0;

        while (index < romanNumber.Length)
        {
            foreach (var (value, symbol) in ConversionTable)
            {
                // Retrieve the matching roman symbol (largest first)
                // and add its value to the running total
                if (romanNumber.AsSpan(index).StartsWith(symbol))
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
        if (!Regex.IsMatch(romanNumber, "^[IVXLCDM]+$"))
            throw new ArgumentException("A roman number can only contain characters 'I', 'V', 'X', 'L', 'C', 'D' and 'M'.");
        
        /*
         Validation logic from Project Euler (https://projecteuler.net/about=roman_numerals)
         1. Descending order, the larger symbol must occur first
         2. Validate subtractive notations (e.g., IV, XL, CM are valid but XM is not)
         3. "Contemporary" repetition rules (a symbol must not occur more than three times; D, L and V can only appear once)
         */
        if (!Regex.IsMatch(romanNumber, "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$"))
            throw new ArgumentException("An invalid roman number was provided.");
    }
}