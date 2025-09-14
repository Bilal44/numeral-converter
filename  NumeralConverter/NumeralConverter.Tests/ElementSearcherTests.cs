namespace NumeralConverter.Tests;

public class ElementSearcherTests
{
    [Theory]
    [MemberData(nameof(ElementSearcherTestData))]
    public void GetElements_ReturnsValidCombinationsOfElements(string word, List<string[]> expectedCombinations)
    {
        var result = ElementSearcher.GetElements(word);
        Assert.Equivalent(expectedCombinations, result);
    }

    public static IEnumerable<object[]> ElementSearcherTestData =>
        new List<object[]>
        {
            new object[]
            {
                "snack",
                new List<string[]>
                {
                    new[] { "Sulfur (S)", "Nitrogen (N)", "Actinium (Ac)", "Potassium (K)" },
                    new[] { "Sulfur (S)", "Sodium (Na)", "Carbon (C)", "Potassium (K)" },
                    new[] { "Tin (Sn)", "Actinium (Ac)", "Potassium (K)" }
                }
            },
            new object[]
            {
                "lass",
                new List<string[]>
                {
                    new[] { "Lanthanum (La)", "Sulfur (S)", "Sulfur (S)" }
                }
            },
            new object[]
            {
                "glass",
                new List<string[]>()
            }
        };
}