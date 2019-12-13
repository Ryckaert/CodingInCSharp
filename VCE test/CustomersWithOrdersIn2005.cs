using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox;
using Toolbox.RandomizablesModels;

namespace VCE_test
{
    public static class CustomersWithOrdersIn2005
    {
        private static IEnumerable<Customer> customers = new FakeBigEnumerable<Customer>(40);
        public static void Test()
        {

            var customers = GetCustomersWithOrdersIn2005();
            Check(customers);

        }


        //This is the so-called good solution according to the vce
        //this solution is so wrong it doesn't even compile
        //public static void GetCustomersWithOrdersIn2005_VCE()
        //{
        //    List<Customer> CustomersWithOrdersIn2005 =
        //    customers.Where(c => c.Orders.Join(
        //    o => o.Year == 2005)).ToList();
        //}

        //this is my solution, but the VCE consider it wrong
        public static List<Customer> GetCustomersWithOrdersIn2005()
        {
            List<Customer> CustomersWithOrdersIn2005 =
            customers.Where(c => c.Orders.Any(
            o => o.Year == 2005)).ToList();

            return CustomersWithOrdersIn2005;
        }

        private static void Check(List<Customer> customers)
        {

            //Yes this is inneficient, but I want this to be as simple as possible to understand
            bool AllCustomersHaveOrderIn2005 = true;
            foreach (var customer in customers)
            {
                bool AtLeastOneOrderIn2005 = false;
                foreach (var order in customer.Orders)
                {
                    if (order.Year == 2005)
                        AtLeastOneOrderIn2005 = true;
                }
                AllCustomersHaveOrderIn2005 &= AtLeastOneOrderIn2005;
            }

            Console.WriteLine($"All customers have at least one order in 2005:{AllCustomersHaveOrderIn2005}");
        }
    }
}
