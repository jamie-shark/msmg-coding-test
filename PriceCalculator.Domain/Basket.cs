using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Domain.Products;

namespace PriceCalculator.Domain
{
    public class Basket
    {
        private readonly OfferService _offerService;

        private IEnumerable<Product> _contents = new Product[]{ };

        public Basket(OfferService offerService)
        {
            _offerService = offerService;
        }

        public void Add(params Product[] newProducts) =>
            _contents = _contents.Concat(newProducts);

        public void Add(Product product, int count) =>
            Add(Enumerable.Repeat(product, count).ToArray());

        public decimal Total()
        {
            _offerService.ApplyOffers(this);

            return _contents.Aggregate(0m, (runningTotal, product) => runningTotal + product.GetCost());
        }

        internal void Apply(Offer offer) => _contents = offer.ApplyTo(_contents);
    }
}