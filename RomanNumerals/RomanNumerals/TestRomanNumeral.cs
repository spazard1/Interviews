using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    [TestClass]
    public class TestRomanNumeral
    {

        [TestMethod]
        public void IntToRomanNumeral()
        {
            Assert.AreEqual("I", RomanNumeral.ToRomanNumeral(1));
            Assert.AreEqual("II", RomanNumeral.ToRomanNumeral(2));
            Assert.AreEqual("IV", RomanNumeral.ToRomanNumeral(4));
            Assert.AreEqual("XXXIX", RomanNumeral.ToRomanNumeral(39));
            Assert.AreEqual("CCXLVI", RomanNumeral.ToRomanNumeral(246));
            Assert.AreEqual("DCCLXXXIX", RomanNumeral.ToRomanNumeral(789));
            Assert.AreEqual("MMCDXXIII", RomanNumeral.ToRomanNumeral(2423));
        }

        [TestMethod]
        public void RomanNumeralToInt()
        {
            Assert.AreEqual(1, RomanNumeral.ToInt("I"));
            Assert.AreEqual(2, RomanNumeral.ToInt("II"));
            Assert.AreEqual(4, RomanNumeral.ToInt("IV"));
            Assert.AreEqual(39, RomanNumeral.ToInt("XXXIX"));
            Assert.AreEqual(246, RomanNumeral.ToInt("CCXLVI"));
            Assert.AreEqual(789, RomanNumeral.ToInt("DCCLXXXIX"));
            Assert.AreEqual(2423, RomanNumeral.ToInt("MMCDXXIII"));
        }

        [TestMethod]
        public void TwoWayConversion()
        {
            for (int i = 1; i <= 3999; i++)
            {
                var romanNumeral = RomanNumeral.ToRomanNumeral(i);

                Assert.AreEqual(i, RomanNumeral.ToInt(romanNumeral));
            }
        }
    }
}
