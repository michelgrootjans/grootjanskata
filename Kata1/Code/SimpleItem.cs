namespace Kata1.Code
{
    public class SimpleItem : IItem
    {
        private readonly double price;

        public SimpleItem(double price)
        {
            this.price = price;
        }

        public double PriceFor(int quantity)
        {
            return price * quantity;
        }
    }
}