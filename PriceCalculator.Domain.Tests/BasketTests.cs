using System.Collections.Generic;
using NUnit.Framework;
using PriceCalculator.Domain.Products;

namespace PriceCalculator.Domain.Tests
{
    [TestFixture]
    public class BasketTests
    {
        private Product _butter;
        private Product _milk;
        private Product _bread;

        private Basket _basket;
        private List<Offer> _offers;

        [SetUp]
        public void Setup()
        {
            _butter = new("butter", 0.80m);
            _milk = new("milk", 1.15m);
            _bread = new("bread", 1.00m);

            _offers = new List<Offer>();

            _basket = new Basket(new OfferService(_offers));
        }

        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [Test]
        public void totals_contents()
        {
            _basket.Add(_butter, _milk, _bread);

            var total = _basket.Total();

            Assert.That(total, Is.EqualTo(2.95m));
        }

        // Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
        [Test]
        public void Applies_buy_two_butter_get_a_bread_at_fifty_percent_off_offer()
        {
            _offers.Add(new Offer(2, _butter, 0.5m, _bread));
            _basket.Add(_butter, _butter, _bread, _bread);

            var total = _basket.Total();

            Assert.That(total, Is.EqualTo(3.10m));
        }

        // Given the basket has 4 milk when I total the basket then the total should be £3.45
        [Test]
        public void Applies_buy_three_milk_get_one_free_offer()
        {
            _offers.Add(new Offer(3, _milk, 0m, _milk));
            _basket.Add(_milk, 4);

            var total = _basket.Total();

            Assert.That(total, Is.EqualTo(3.45m));
        }

        // Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00
        [Test]
        public void Applies_multiple_offers_at_once()
        {
            _offers.Add(new Offer(2, _butter, 0.5m, _bread));
            _offers.Add(new Offer(3, _milk, 0m, _milk));
            _basket.Add(_butter, 2);
            _basket.Add(_bread, 1);
            _basket.Add(_milk, 8);

            var total = _basket.Total();

            Assert.That(total, Is.EqualTo(9.00m));
        }
    }

/*
    - There is no scenario given that prevents a product from being reduced twice.
*/
}