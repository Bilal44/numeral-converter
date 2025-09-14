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
            },
            new object[]
            {
                "baTCh",
                new List<string[]>
                {
                    new[] { "Boron (B)", "Astatine (At)", "Carbon (C)", "Hydrogen (H)" },
                    new[] { "Barium (Ba)", "Technetium (Tc)", "Hydrogen (H)"}
                }
            },
            new object[]
            {
                "OPINION",
                new List<string[]>
                {
                    new[] { "Oxygen (O)", "Phosphorus (P)", "Indium (In)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Oxygen (O)", "Phosphorus (P)", "Iodine (I)", "Nitrogen (N)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Oxygen (O)", "Phosphorus (P)", "Iodine (I)", "Nickel (Ni)", "Oxygen (O)", "Nitrogen (N)" }
                }
            },
            new object[]
            {
                "consciousness",
                new List<string[]>
                {
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Nitrogen (N)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Neon (Ne)", "Sulfur (S)", "Sulfur (S)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Tin (Sn)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Nitrogen (N)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Neon (Ne)", "Sulfur (S)", "Sulfur (S)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Tin (Sn)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Nitrogen (N)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Neon (Ne)", "Sulfur (S)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Sulfur (S)", "Carbon (C)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Tin (Sn)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Nitrogen (N)", "Einsteinium (Es)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Sulfur (S)", "Neon (Ne)", "Sulfur (S)", "Sulfur (S)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Scandium (Sc)", "Iodine (I)", "Oxygen (O)", "Uranium (U)", "Tin (Sn)", "Einsteinium (Es)", "Sulfur (S)" }
                }
            },
            new object[]
            {
                "confession",
                new List<string[]>
                {
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Fluorine (F)", "Einsteinium (Es)", "Sulfur (S)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Fluorine (F)", "Einsteinium (Es)", "Silicon (Si)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Iron (Fe)", "Sulfur (S)", "Sulfur (S)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Carbon (C)", "Oxygen (O)", "Nitrogen (N)", "Iron (Fe)", "Sulfur (S)", "Silicon (Si)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Fluorine (F)", "Einsteinium (Es)", "Sulfur (S)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Fluorine (F)", "Einsteinium (Es)", "Silicon (Si)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Iron (Fe)", "Sulfur (S)", "Sulfur (S)", "Iodine (I)", "Oxygen (O)", "Nitrogen (N)" },
                    new[] { "Cobalt (Co)", "Nitrogen (N)", "Iron (Fe)", "Sulfur (S)", "Silicon (Si)", "Oxygen (O)", "Nitrogen (N)" }
                }
            },
            new object[]
            {
                "",
                new List<string[]>()
            }
        };
}