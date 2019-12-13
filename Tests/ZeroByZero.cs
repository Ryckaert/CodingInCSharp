using System;
using System.Collections.Generic;
using System.Text;

namespace VCE_test
{
    
    public static class ZeroByZero
    {
        static double Zero = 0;
        public static void Test()
        {
            double result = Zero / Zero;
            Console.WriteLine($"Result is {result}");
        }
    }
}
