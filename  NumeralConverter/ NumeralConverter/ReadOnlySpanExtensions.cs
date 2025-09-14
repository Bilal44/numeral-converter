namespace NumeralConverter;

public static class ReadOnlySpanExtensions
{
    /// <summary>
    /// Capitalises the first character of a ReadOnlySpan and lowercases the rest.
    /// </summary>
    /// <param name="input">The input `ReadOnlySpan`.</param>
    /// <returns>A title-cased string.</returns>
    /// <example>`thIS`(ReadOnlySpan) to `This`(string).</example>
    public static string ToTitleCase(this ReadOnlySpan<char> input)
    {
        if (input.IsEmpty)
            return string.Empty;
        
        if (input.Length == 1) 
            return char.ToUpperInvariant(input[0]).ToString();
        
        Span<char> span = stackalloc char[input.Length];
        span[0] = char.ToUpperInvariant(input[0]);

        for (var i = 1; i < input.Length; i++)
            span[i] = char.ToLowerInvariant(input[i]);
        
        return new string(span);
    }
}