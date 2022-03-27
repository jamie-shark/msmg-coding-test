namespace PriceCalculator.Domain
{
    public class Product
    {
        private readonly string _id;
        private readonly decimal _cost;

        private decimal _discount = 1m;

        public Product(string id, decimal cost)
        {
            _id = id;
            _cost = cost;
        }

        internal decimal GetCost() => _discount * _cost;

        internal void Discount(decimal percentage) => _discount = percentage;

        internal bool Matches(Product other) => _id == other._id;

        public Product Copy() => new(_id, _cost);
    }
}