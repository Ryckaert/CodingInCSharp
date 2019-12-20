using System;

namespace VCE_test
{
    public static class CatchClause
    {
        public static void Test()
        {
            try
            {
                string orderRefNumber = null;
                ProcessOrders(orderRefNumber);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} An exception caught.",e);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} An exception caught.", e);
            }
        }

        static void ProcessOrders(string orderRefNumber)
        {
            if (orderRefNumber == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
