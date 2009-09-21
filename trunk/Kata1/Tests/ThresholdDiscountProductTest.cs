using Kata1.Code;
using NUnit.Framework;
using TestUtilities;
using TestUtilities.Extensions;

namespace Kata1.Tests
{
    public class when_buying_a_ThresholdDiscountedProduct : InstanceContextSpecification<IItem>
    {
        private double unitPrice;
        private int quantityWithDiscount;
        private double discount;

        protected override void Arrange()
        {
            unitPrice = 10.5;
            quantityWithDiscount = 3;
            discount = 0.8;
        }

        protected override IItem CreateSystemUnderTest()
        {
            return new ThreshHoldDiscountedProduct(unitPrice, quantityWithDiscount, discount);
        }

        [Test]
        public void should_pay_first_item_full_price()
        {
            sut.PriceFor(1).ShouldBeEqualTo(unitPrice);
        }

        [Test]
        public void should_pay_second_item_full_price()
        {
            sut.PriceFor(2).ShouldBeEqualTo(unitPrice *2);
        }

        [Test]
        public void should_pay_third_item_with_discount()
        {
            sut.PriceFor(3).ShouldBeEqualTo(unitPrice * (2 + discount));
        }
    }
}