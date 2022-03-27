using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.Domain
{
    public class Basket
    {
        private IEnumerable<Product> _products;
        private readonly Offer _offer;

        public Basket() { }

        public Basket(Offer offer)
        {
            _offer = offer;
        }

        public void Add(params Product[] products) => _products = products;

        public decimal Total()
        {
            _offer?.ApplyDiscount(_products);

            return _products.Aggregate(0m, (runningTotal, product) => runningTotal + product.GetCost());
        }
    }
}