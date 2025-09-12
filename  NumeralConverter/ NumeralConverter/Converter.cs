namespace NumeralConverter;

public static class Converter
{
    public static string ConvertToRoman(ushort number)
    {
        var conversionTable = new (ushort value, string Symbol)[]
        {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
        };
        
        var result = string.Empty;
        
        foreach (var (value, romanSymbol) in conversionTable)
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