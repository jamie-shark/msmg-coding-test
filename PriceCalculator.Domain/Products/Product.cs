namespace PriceCalculator.Domain.Products
{
    public class Product
    {
        private readonly string _id;
        protected readonly decimal _cost;

        public Product(Product product)
            : this(product._id, product._cost) { }

        public Product(string id, decimal cost)
        {
            _id = id;
            _cost = cost;
        }

        internal virtual decimal GetCost() => _cost;

        internal virtual bool CanBeUsedInOffers() => true;

        internal bool Matches(Product other) => _id == other._id;
    }
}