using NumeralConverter;

Console.WriteLine("Enter a number between 1 and 3999 to convert to Roman numerals (or type 'q' to quit):");
while (true)
{
    var input = Console.ReadLine();

    if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
        break;
    
    const string errorMessage =
        "Error: Invalid input. Please try again with a number between 1 and 3999 or type 'q' to quit";
    
    if (int.TryParse(input, out var number))
    {
        var result = Converter.ConvertToRoman(number);
        Console.WriteLine(
            result.StartsWith("P")
            ? errorMessage
            : $"Roman numeral: {result}");
    }
    else
    {
        Console.WriteLine(errorMessage);
    }
}