namespace Kata1.Code
{
    public class DiscountItem : IItem
    {
        private readonly double unitPrice;
        private readonly double discount;

        public DiscountItem(double unitPrice, double discount)
        {
            this.unitPrice = unitPrice;
            this.discount = discount;
        }

        public double PriceFor(int quantity)
        {
            return quantity*unitPrice*discount;
        }
    }
}