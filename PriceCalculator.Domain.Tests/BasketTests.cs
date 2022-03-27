using PriceCalculator.Domain;
using NUnit.Framework;

namespace PriceCalculator.Domain.Tests
{
    [TestFixture]
    public class BasketTests
    {
        private Product _butter;
        private Product _milk;
        private Product _bread;

        [SetUp]
        public void Setup()
        {
            _butter = new("butter", 0.80m);
            _milk = new("milk", 1.15m);
            _bread = new("bread", 1.00m);
        }

        // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        [Test]
        public void totals_contents()
        {
            var basket = new Basket();
            basket.Add(_butter.Copy(), _milk.Copy(), _bread.Copy());

            var total = basket.Total();

            Assert.That(total, Is.EqualTo(2.95m));
        }

        // Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
        [Test]
        public void Applies_buy_two_butter_get_a_bread_at_fifty_percent_off_offer()
        {
            var offer = new Offer(2, _butter, 0.5m, _bread);
            var basket = new Basket(offer);
            basket.Add(_butter.Copy(), _butter.Copy(), _bread.Copy(), _bread.Copy());

            var total = basket.Total();

            Assert.That(total, Is.EqualTo(3.10m));
        }

        // Given the basket has 4 milk when I total the basket then the total should be £3.45
        [Test]
        public void Applies_buy_three_milk_get_one_free_offer()
        {
            var offer = new Offer(4, _milk, 0m, _milk);
            var basket = new Basket(offer);
            basket.Add(_milk.Copy(), _milk.Copy(), _milk.Copy(), _milk.Copy());

            var total = basket.Total();

            Assert.That(total, Is.EqualTo(3.45m));
        }
    }

/*
    Available products
    • Butter - £0.80
    • Milk - £1.15
    • Bread - £1.00

    Offers
    • Buy 2 Butter and get a Bread at 50% off
    • Buy 3 Milk and get the 4th milk for free

    Scenarios
    • Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00

    - There is no scenario given that prevents a product from being reduced twice.
*/
}