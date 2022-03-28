namespace PriceCalculator.Domain.Products
{
    internal class DiscountedProduct : Product
    {
        private readonly decimal _discount;

        public DiscountedProduct(Product product, decimal discount)
            : base(product)
        {
            _discount = discount;
        }

        internal override decimal GetCost() => _cost * _discount;

        internal override bool CanBeUsedInOffers() => false;
    }
}