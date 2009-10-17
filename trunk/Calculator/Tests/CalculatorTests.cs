using Calc.Code;
using NUnit.Framework;
using TestUtilities.Extensions;

namespace Calc.Tests
{
    [TestFixture]
    public class CalculatorAddTests
    {
        [Test]
        public void NullString_ReturnsZero()
        {
            string empty = null;
            Calculator.Add(empty).ShouldBeEqualTo(0);
        }

        [Test]
        public void EmptyString_ReturnsZero()
        {
            Calculator.Add("").ShouldBeEqualTo(0);
        }

        [Test]
        public void InvalidString_ReturnsZero()
        {
            Calculator.Add("s").ShouldBeEqualTo(0);
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
            Calculator.Add("1,s").ShouldBeEqualTo(1);
        }

        [Test]
        public void ThreeNumbers_ReturnsTheSum()
        {
            Calculator.Add("1, 2, s, 3").ShouldBeEqualTo(6);
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
        public void Null_Returns0()
        {
            string nullString = null;
            Calculator.Multiply(nullString).ShouldBeEqualTo(1);
        }

        [Test]
        public void Empty_Returns0()
        {
            Calculator.Multiply("").ShouldBeEqualTo(1);
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
        public void TwoNumbers_ReturnsTheTheProductOfTheValidNumbers()
        {
            Calculator.Multiply("3, s, 4").ShouldBeEqualTo(12);
        }

    }
}