using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    /*
 Write a function that, given a string representing a roman numeral, converts it to an integer.

Symbol:
I -> 1
V -> 5
X -> 10
L -> 50
C -> 100
D -> 500
M -> 1000


Roman numerals leverage a subtractive notation for certain values
4, 9: IV, IX
40, 90: XL, XC
400, 900: CD, CM
     */
    public class RomanNumeral
    {
        public static string ToRomanNumeral(int n)
        {
            var result = new StringBuilder();

            while (n > 0)
            {
                if (n >= 1000)
                {
                    result.Append("M");
                    n -= 1000;
                }
                else if (n >= 900)
                {
                    result.Append("CM");
                    n -= 900;
                }
                else if (n >= 500)
                {
                    result.Append("D");
                    n -= 500;
                }
                else if (n >= 400)
                {
                    result.Append("CD");
                    n -= 400;
                }
                else if (n >= 100)
                {
                    result.Append("C");
                    n -= 100;
                }
                else if (n >= 90)
                {
                    result.Append("XC");
                    n -= 90;
                }
                else if (n >= 50)
                {
                    result.Append("L");
                    n -= 50;
                }
                else if (n >= 40)
                {
                    result.Append("XL");
                    n -= 40;
                }
                else if (n >= 10)
                {
                    result.Append("X");
                    n -= 10;
                }
                else if (n >= 9)
                {
                    result.Append("IX");
                    n -= 9;
                }
                else if (n >= 5)
                {
                    result.Append("V");
                    n -= 5;
                }
                else if (n >= 4)
                {
                    result.Append("IV");
                    n -= 4;
                }
                else if (n >= 1)
                {
                    result.Append("I");
                    n -= 1;
                }
            }

            return result.ToString();
        }

        public static List<Tuple<string, int>> RNValues = new()
        {
            new Tuple<string, int>("M", 1000),
            new Tuple<string, int>("CM", 900),
            new Tuple<string, int>("D", 500),
            new Tuple<string, int>("CD", 400),
            new Tuple<string, int>("C", 100),
            new Tuple<string, int>("XC", 90),
            new Tuple<string, int>("L", 50),
            new Tuple<string, int>("XL", 40),
            new Tuple<string, int>("X", 10),
            new Tuple<string, int>("IX", 9),
            new Tuple<string, int>("V", 5),
            new Tuple<string, int>("IV", 4),
            new Tuple<string, int>("I", 1),
        };

        public static int ToInt(string rn)
        {
            ArgumentNullException.ThrowIfNull(rn);
            var result = 0;

            while (rn.Length > 0)
            {
                foreach (var rnValue in RNValues)
                {
                    if (rn.StartsWith(rnValue.Item1))
                    {
                        result += rnValue.Item2;
                        rn = rn.Substring(rnValue.Item1.Length);
                    }
                }
            }

            return result;
        }
    }
}
