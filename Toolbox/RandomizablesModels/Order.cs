namespace Toolbox.RandomizablesModels
{
    public class Order : BaseRandomizable<Order>
    {
        public int Year { get; private set; }
        public override Order Randomize()
        {
            if (Coinflip())
                Year = 2005;
            else
                Year = _random.Next(2000, 2019);
            return this;
        }
    }
}
