using System.Collections.Generic;

namespace Toolbox.RandomizablesModels
{
    public class Customer : BaseRandomizable<Customer>
    {
        public IEnumerable<Order> Orders { get; private set; }
        public override Customer Randomize()
        {
            Orders = new FakeBigEnumerable<Order>(_random.Next(100, 500));
            return this;
        }
    }
}
