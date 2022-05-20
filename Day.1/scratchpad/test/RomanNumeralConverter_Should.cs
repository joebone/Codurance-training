using System.Diagnostics;
using Xunit.Abstractions;

namespace scratchpad;

public class RomanNumeralConverter_Should {
    private RomanNumeralConverter converter;
    private readonly ITestOutputHelper output;

    public RomanNumeralConverter_Should(ITestOutputHelper output) {
        converter = new RomanNumeralConverter();
        // warmpu of the static method
        converter.Convert(50);
        this.output = output;
    }

    [Theory, InlineData(-1), InlineData(0), InlineData(4000)]
    public void only_accepts_positive_numbers(int input) {
        Assert.Throws<ArgumentOutOfRangeException>(nameof(input), () => converter.Convert(input));
    }

    [Theory]
    [MemberData("TestCases")]
    public void can_convert_arabic_to_roman_numerals(int number, string expectedResult) =>
        Assert.Equal(expectedResult, (string?)converter.Convert(number));


    [Theory]
    [MemberData("TestCases")]
    public void can_convert_arabic_to_roman_numerals_quickly(int number, string expectedResult) {

        var sw = Stopwatch.StartNew();
        var actualResult = (string?)converter.Convert(number);
        var elapsed = sw.Elapsed;
        Assert.Equal(expectedResult, actualResult);

        var elapsedMs = elapsed.TotalMilliseconds;
        output.WriteLine($"Converted in {elapsedMs}ms");

        //method shouldn't take more than 20 microseconds
        Assert.True(elapsedMs < 0.02, $"Is Slow! : {elapsedMs}ms is more than 20 microseconds.");

    }

    public static IEnumerable<object[]> TestCases =>
       new List<object[]>
       {
            new object[] { 1, "I" },
            new object[] { 2, "II" },
            new object[] { 3, "III" },
            new object[] { 6, "VI" },
            new object[] { 8, "VIII" },
            new object[] { 10, "X" },
            new object[] { 20, "XX" },
            new object[] { 40, "XL" },
            new object[] { 50, "L" },
            new object[] { 76, "LXXVI" },
            new object[] { 90, "XC" },
            new object[] { 100, "C" },
            new object[] { 250, "CCL" },
            new object[] { 500, "D" },
            new object[] { 900, "CM" },
            new object[] { 1000, "M" },
            new object[] { 2499, "MMCDXCIX" },
            new object[] { 3949, "MMMCMXLIX" },

       };
}