using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Domain.Products;

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

        private bool IsApplicable(IEnumerable<Product> products) =>
            products.Count(x => x.CanBeUsedInOffers() && x.Matches(_criteria)) >= _count &&
            products.Any(x => x.CanBeUsedInOffers() && x.Matches(_discountedProduct));

        internal IEnumerable<Product> ApplyTo(IEnumerable<Product> products)
        {
            if (!IsApplicable(products)) return products;

            var hasDiscountBeenApplied = false;
            var numberOfCriteriaProductsUsed = 0;
            var result = new List<Product>();

            foreach (var product in products)
            {
                if (!hasDiscountBeenApplied && product.CanBeUsedInOffers() && _discountedProduct.Matches(product))
                {
                    hasDiscountBeenApplied = true;
                    result.Add(new DiscountedProduct(product, _discount));
                }
                else if (numberOfCriteriaProductsUsed < _count && product.CanBeUsedInOffers() && _criteria.Matches(product))
                {
                    numberOfCriteriaProductsUsed++;
                    result.Add(new UsedInOfferProduct(product));
                }
                else
                {
                    result.Add(product);
                }
            }

            return IsApplicable(result)
                ? ApplyTo(result)
                : result;
        }
    }
}