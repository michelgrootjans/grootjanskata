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
            var numberOfDiscountedItems = quantity/quantityWithDiscount;
            var numberOfNormalItems = quantity - numberOfDiscountedItems;
            return unitPrice*(numberOfNormalItems + (numberOfDiscountedItems*discount));
        }
    }
}