namespace Kata1.Code
{
    public class ThreshHoldDiscountedProduct : IItem
    {
        private readonly double unitPrice;
        private readonly int quantityWithDiscount;
        private readonly double discount;

        public ThreshHoldDiscountedProduct(double unitPrice, int quantityWithDiscount, double discount)
        {
            this.unitPrice = unitPrice;
            this.quantityWithDiscount = quantityWithDiscount;
            this.discount = discount;
        }

        public double PriceFor(int quantity)
        {
            double price = 0;

            for (var i = 1; i <= quantity; i++)
            {
                if (i % quantityWithDiscount == 0)
                    price += unitPrice * discount;
                else
                {
                    price += unitPrice;
                }
            }
            return price;
        }
    }
}