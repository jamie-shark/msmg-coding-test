using PriceCalculator.Domain;
using NUnit.Framework;

namespace PriceCalculator.Domain.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void totals_contents()
        {
            var basket = new Basket();
            basket.Add(0.8m, 1.15m, 1.00m);

            var total = basket.Total();

            Assert.That(total, Is.EqualTo(2.95m));
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
    • Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
    • Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
    • Given the basket has 4 milk when I total the basket then the total should be £3.45
    • Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00
*/
}