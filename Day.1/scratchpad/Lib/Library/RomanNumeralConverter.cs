using System.Text;

namespace scratchpad;
public class RomanNumeralConverter {

    static RomanNumeralConverter() {
        GlobalMap = new List<(int Arabic, string Roman)>() {
        ( 1, "I"    ),
        ( 4, "IV"   ),
        ( 5, "V"    ),
        ( 9, "IX"   ),
        ( 10, "X"   ),
        ( 40, "XL"  ),
        ( 50, "L"   ),
        ( 90, "XC"  ),
        ( 100, "C"  ),
        ( 400, "CD" ),
        ( 500, "D"  ),
        ( 900, "CM" ),
        ( 1000, "M" )
    }.AsReadOnly();
    }
    public RomanNumeralConverter() {
    }

    private static IReadOnlyList<(int Arabic, string Roman)> GlobalMap;

    public virtual string Convert(int input) {
        if (input < 1 || input > 3999)
            throw new ArgumentOutOfRangeException(nameof(input), "Unexpected input");

        StringBuilder sb = new StringBuilder();
        var total = input;
        var i = GlobalMap.Count - 1;
        while (total > 0) {
            (int Arabic, string Roman) = GlobalMap[i];
            if (total >= Arabic) {
                sb.Append(Roman);
                total -= Arabic;
                continue;
            }
            --i;
        }

        return sb.ToString();
    }
}