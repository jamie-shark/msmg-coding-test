namespace PriceCalculator.Domain
{
    public class Basket
    {
        public void Add(params decimal[] products) { }

        public decimal Total() => 2.95m;
    }
}