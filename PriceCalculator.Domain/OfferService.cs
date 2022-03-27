using System.Collections.Generic;

namespace PriceCalculator.Domain
{
    public class OfferService
    {
        private readonly IEnumerable<Offer> _offers;

        public OfferService(IEnumerable<Offer> offers)
        {
            _offers = offers;
        }

        internal void ApplyOffers(Basket basket)
        {
            foreach (var offer in _offers)
                basket.Apply(offer);
        }
    }
}