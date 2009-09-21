namespace Kata1.Code
{
    public interface IShoppingCartItem
    {
        IItem Item { get; }
        int Quantity { get; }
        double Price { get; }
        void IncrementQuantity();
    }

    public class ShoppingCartItem : IShoppingCartItem
    {
        public ShoppingCartItem(IItem item)
        {
            Item = item;
            Quantity = 1;
        }

        public IItem Item { get; private set; }
        public int Quantity { get; private set; }

        public double Price
        {
            get { return Item.PriceFor(Quantity); }
        }

        public void IncrementQuantity()
        {
            Quantity++;
        }
    }
}