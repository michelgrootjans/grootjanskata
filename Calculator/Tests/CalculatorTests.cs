using System;
using Calc.Code;
using NUnit.Framework;
using TestUtilities.Extensions;

namespace Calc.Tests
{
    [TestFixture]
    public class CalculatorAddTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullString_Throws()
        {
            Calculator.Add(null);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void EmptyString_Throws()
        {
            Calculator.Add("");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidString_Throws()
        {
            Calculator.Add("s");
        }

        [Test]
        public void SingleNumber_ReturnsIt()
        {
            Calculator.Add("1").ShouldBeEqualTo(1);
        }

        [Test]
        public void TwoCommaSeparatedNumbers_ReturnsTheSum()
        {
            Calculator.Add("1,2").ShouldBeEqualTo(3);
        }

        [Test]
        public void TwoNumbers_ReturnsTheSumOfValidNumbers()
        {
            Calculator.Add("1,2").ShouldBeEqualTo(3);
        }

        [Test]
        public void ThreeNumbers_ReturnsTheSum()
        {
            Calculator.Add("1, 2, 3").ShouldBeEqualTo(6);
        }

        [Test]
        public void ThreeSeparateNumbers_ReturnsTheSum()
        {
            Calculator.Add("1", "2", "3").ShouldBeEqualTo(6);
        }

    }

    [TestFixture]
    public class CalculatorMultiplyTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Throws()
        {
            Calculator.Multiply(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Empty_Throws()
        {
            Calculator.Multiply("");
        }

        [Test]
        public void OneNumber_ReturnsIt()
        {
            Calculator.Multiply("3").ShouldBeEqualTo(3);
        }

        [Test]
        public void TwoNumbers_ReturnsTheProduct()
        {
            Calculator.Multiply("3, 4").ShouldBeEqualTo(12);
        }

        [Test]
        public void TwoSeparateNumbers_ReturnsTheTheProduct()
        {
            Calculator.Multiply("3","4").ShouldBeEqualTo(12);
        }

    }
}