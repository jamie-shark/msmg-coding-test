using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.Domain
{
    public class Offer
    {
        private readonly int _count;
        private readonly Product _criteria;
        private readonly decimal _discount;
        private readonly Product _discountedProduct;

        public Offer(int count, Product criteria, decimal discount, Product discountedProduct)
        {
            _count = count;
            _criteria = criteria;
            _discount = discount;
            _discountedProduct = discountedProduct;
        }

        internal void ApplyDiscount(IEnumerable<Product> productsToDiscount)
        {
            if (productsToDiscount.Count(x => x.Matches(_criteria)) == _count)
                productsToDiscount
                    .FirstOrDefault(x => x.Matches(_discountedProduct))
                    ?.Discount(_discount);
        }
    }
}