using Kata1.Code;
using NUnit.Framework;
using TestUtilities;
using TestUtilities.Extensions;

namespace Kata1.Tests
{
    public class when_buying_a_simple_item : InstanceContextSpecification<IItem>
    {
        private int price;

        protected override void Arrange()
        {
            price = 23;
        }

        protected override IItem CreateSystemUnderTest()
        {
            return new SimpleItem(price);
        }

        [Test]
        public void one_item_should_have_the_price_once()
        {
            sut.PriceFor(1).ShouldBeEqualTo(price);
        }

        [Test]
        public void two_items_should_have_twice_the_price()
        {
            sut.PriceFor(2).ShouldBeEqualTo(2*price);
        }

        [Test]
        public void a_lot_of_items_should_have_the_right_price()
        {
            for (var quantity = 0; quantity < 100; quantity++)
            {
                sut.PriceFor(quantity).ShouldBeEqualTo(quantity*price);
            }
        }
    }
}