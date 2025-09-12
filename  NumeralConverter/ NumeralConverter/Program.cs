using NumeralConverter;

while (true)
{
    Console.WriteLine("Enter a number between 1 and 3999 to convert to Roman numerals (or type 'q' to quit):");
    var input = Console.ReadLine();

    if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
        break;

    Console.WriteLine(int.TryParse(input, out var number)
        ? $"Roman numeral: {Converter.ConvertToRoman(number)}"
        : "Invalid input, please enter a number between 1 and 3999.");
}