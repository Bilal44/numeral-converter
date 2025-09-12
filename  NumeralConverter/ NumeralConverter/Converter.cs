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
}