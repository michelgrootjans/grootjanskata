using Kata1.Code;
using NUnit.Framework;
using TestUtilities;
using TestUtilities.Extensions;

namespace Kata1.Tests
{
    public class when_buying_a_discounted_item : InstanceContextSpecification<IItem>
    {
        private double unitPrice;
        private double discount;

        protected override void Arrange()
        {
            unitPrice = 10.2;
            discount = 0.8;
        }

        protected override IItem CreateSystemUnderTest()
        {
            return new DiscountItem(unitPrice, discount);
        }

        [Test]
        public void should_get_a_discount_price_for_one_item()
        {
            sut.PriceFor(1).ShouldBeEqualTo(unitPrice * discount);
        }

        [Test]
        public void should_get_a_discount_price_for_a_lot_of_items()
        {
            for (int i = 0; i < 100; i++)
            {
                sut.PriceFor(i).ShouldBeEqualTo(i * unitPrice * discount);
            }
        }

    }
}