using System;
using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NunitFrameworkTest
{
    [TestFixture]
    public class UnitTest1
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void EmptyString()
        {
            const int expected = 0;
            var actual = _calculator.Add(string.Empty);
            Assert.That(actual == expected);
        }

        [TestCase("1", 1)]
        [TestCase("15", 15)]
        [TestCase("100", 100)]
        public void OneNumber(string num, int result)
        {
            var actual = _calculator.Add(num);
            var expected = result;
            Assert.That(actual == expected);
        }

        [TestCase("1,2", 3)]
        [TestCase("15,4", 19)]
        [TestCase("100, 1000", 1100)]
        public void TwoNumber(string num, int result)
        {
            var actual = _calculator.Add(num);
            var expected = result;
            Assert.That(actual == expected);
        }
    }

    public class Calculator
    {
        public int Add(string num)
        {
            if (num == string.Empty)
                return 0;

            var intArr = ConvertStringToIntArray(num);

            return intArr.Sum();
        }

        private static IEnumerable<int> ConvertStringToIntArray(string num)
        {
            return num.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        }
    }
}
