using Iesi.Collections.Generic;
using Utilities.Extendions;

namespace Kata1.Code
{
    public interface IShoppingCart
    {
        ISet<IShoppingCartItem> Items { get; }
        double Price { get; }
        void Add(IItem item);
    }

    public class ShoppingCart : IShoppingCart
    {
        public ISet<IShoppingCartItem> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new HashedSet<IShoppingCartItem>();
        }

        public double Price
        {
            get
            {
                var price = 0.0;
                Items.ForEach(item => price += item.Price * item.Quantity);
                return price;
            }
        }

        public void Add(IItem item)
        {
            var shoppingCartItem = Items.Find(i => i.Item.Equals(item));
            if (shoppingCartItem == null)
                Items.Add(new ShoppingCartItem(item));
            else
                shoppingCartItem.IncrementQuantity();
        }
    }
}