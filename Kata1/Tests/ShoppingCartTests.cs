using Kata1.Code;
using NUnit.Framework;
using TestUtilities;
using TestUtilities.Extensions;

namespace Kata1.Tests
{
    public class ShoppingCartTest : InstanceContextSpecification<IShoppingCart>
    {
        protected override IShoppingCart CreateSystemUnderTest()
        {
            return new ShoppingCart();
        }
    }

    public class when_shopping_cart_is_new : ShoppingCartTest
    {
        [Test]
        public void should_have_no_items()
        {
            sut.Items.ShouldBeEmpty();
        }

        [Test]
        public void should_have_0_price()
        {
            sut.Price.ShouldBeEqualTo(0);
        }
    }

    public class when_ShoppingCart_is_told_to_add_an_item : ShoppingCartTest
    {
        private IItem canOfBeans;
        private int beanPrice;

        protected override void Arrange()
        {
            beanPrice = 45;
            canOfBeans = Dependency<IItem>();
            When(canOfBeans).IsToldTo(i => i.PriceFor(1)).Return(beanPrice);
        }

        protected override void Act()
        {
            sut.Add(canOfBeans);
        }

        [Test]
        public void should_contain_one_item()
        {
            sut.Items.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_contain_the_new_item()
        {
            sut.Items.ShouldContain(i => i.Item.Equals(canOfBeans) && i.Quantity.Equals(1));
        }

        [Test]
        public void should_have_the_price_of_the_item()
        {
            sut.Price.ShouldBeEqualTo(beanPrice);
        }
    }

    public class when_ShoppingCart_is_told_to_add_an_item_twice : ShoppingCartTest
    {
        private IItem canOfBeans;
        private int itemPrice;

        protected override void Arrange()
        {
            itemPrice = 45;
            canOfBeans = Dependency<IItem>();
            When(canOfBeans).IsToldTo(i => i.PriceFor(2)).Return(itemPrice);
        }

        protected override void Act()
        {
            sut.Add(canOfBeans);
            sut.Add(canOfBeans);
        }

        [Test]
        public void should_contain_one_item()
        {
            sut.Items.Count.ShouldBeEqualTo(1);
        }

        [Test]
        public void should_contain_the_new_item_twice()
        {
            sut.Items.ShouldContain(i => i.Item.Equals(canOfBeans) && i.Quantity.Equals(2));
        }

        [Test]
        public void should_have_double_the_price()
        {
            sut.Price.ShouldBeEqualTo(itemPrice * 2);
        }
    }

    public class when_ShoppingCart_is_told_to_add_two_items : ShoppingCartTest
    {
        private IItem canOfBeans;
        private IItem cokeLight;
        private int beanPrice;
        private int cokePrice;

        protected override void Arrange()
        {
            beanPrice = 12;
            cokePrice = 54;
            canOfBeans = Dependency<IItem>();
            cokeLight = Dependency<IItem>();

            When(canOfBeans).IsToldTo(i => i.PriceFor(1)).Return(beanPrice);
            When(cokeLight).IsToldTo(i => i.PriceFor(1)).Return(cokePrice);
        }

        protected override void Act()
        {
            sut.Add(canOfBeans);
            sut.Add(cokeLight);
        }

        [Test]
        public void should_contain_two_items()
        {
            sut.Items.Count.ShouldBeEqualTo(2);
        }

        [Test]
        public void should_contain_item_1()
        {
            sut.Items.ShouldContain(i => i.Item.Equals(canOfBeans) && i.Quantity.Equals(1));
        }

        [Test]
        public void should_contain_item_2()
        {
            sut.Items.ShouldContain(i => i.Item.Equals(cokeLight) && i.Quantity.Equals(1));
        }

        [Test]
        public void should_contain_total_price()
        {
            sut.Price.ShouldBeEqualTo(beanPrice + cokePrice);
        }
    }
}