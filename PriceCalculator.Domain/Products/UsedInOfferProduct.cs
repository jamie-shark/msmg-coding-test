namespace PriceCalculator.Domain.Products
{
    internal class UsedInOfferProduct : Product
    {
        public UsedInOfferProduct(Product product)
            : base(product) { }

        internal override bool CanBeUsedInOffers() => false;
    }
}