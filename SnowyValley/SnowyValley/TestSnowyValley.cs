using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    [TestClass]
    public class TestSnowyValley
    {

        [TestMethod]
        public void IntToRomanNumeral()
        {
            Assert.AreEqual("I", SnowyValley.ToRomanNumeral(1));
            Assert.AreEqual("II", SnowyValley.ToRomanNumeral(2));
            Assert.AreEqual("IV", SnowyValley.ToRomanNumeral(4));
            Assert.AreEqual("XXXIX", SnowyValley.ToRomanNumeral(39));
            Assert.AreEqual("CCXLVI", SnowyValley.ToRomanNumeral(246));
            Assert.AreEqual("DCCLXXXIX", SnowyValley.ToRomanNumeral(789));
            Assert.AreEqual("MMCDXXIII", SnowyValley.ToRomanNumeral(2423));
        }

        [TestMethod]
        public void RomanNumeralToInt()
        {
            Assert.AreEqual(1, SnowyValley.ToInt("I"));
            Assert.AreEqual(2, SnowyValley.ToInt("II"));
            Assert.AreEqual(4, SnowyValley.ToInt("IV"));
            Assert.AreEqual(39, SnowyValley.ToInt("XXXIX"));
            Assert.AreEqual(246, SnowyValley.ToInt("CCXLVI"));
            Assert.AreEqual(789, SnowyValley.ToInt("DCCLXXXIX"));
            Assert.AreEqual(2423, SnowyValley.ToInt("MMCDXXIII"));
        }

        [TestMethod]
        public void TwoWayConversion()
        {
            for (int i = 1; i <= 3999; i++)
            {
                var romanNumeral = SnowyValley.ToRomanNumeral(i);

                Assert.AreEqual(i, SnowyValley.ToInt(romanNumeral));
            }
        }
    }
}
