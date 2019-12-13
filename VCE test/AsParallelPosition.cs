using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Toolbox;

namespace VCE_test
{
    static class AsParallelPosition
    {
        private static IEnumerable<int> customers = new FakeBigIntEnumerable(Int16.MaxValue);

        private static ConcurrentDictionary<int, int> HitPerThread = new ConcurrentDictionary<int, int>();

        private static void AsParallel_After()
        {
            var validcustomers =
             (from c in customers
              where ValidateCustomer(c)
              select c).AsParallel().ToList();
        }

        private static void AsParallel_Before()
        {
            var validcustomers =
             (from c in customers.AsParallel() 
              where ValidateCustomer(c)
              select c).ToList();
        }
        public static void Test()
        {
            Console.WriteLine("Testing with \"AsParallel()\" just before the \"ToList()\"");

            AsParallel_After();
            ShowStats();

            HitPerThread.Clear();

            Console.WriteLine("Testing with \"AsParallel()\" called on the list of customers");

            AsParallel_Before();
            ShowStats();
        }





        static bool ValidateCustomer(int customerid)
        {
            //register the Thread id, and increase a hit counter associated to the id
            var threadid = Thread.CurrentThread.ManagedThreadId;

            if (HitPerThread.ContainsKey(threadid))
                HitPerThread[Thread.CurrentThread.ManagedThreadId]++;
            else
                HitPerThread.TryAdd(threadid, 1);

            return true;
        }

        static void ShowStats()
        {
            int totalHits = 0;
            foreach (var threadID in HitPerThread.Keys)
            {
                int Hits = HitPerThread[threadID];
                totalHits += Hits;
                Console.WriteLine($"Thread {threadID}: {Hits} hits");
            }
            Console.WriteLine($"For a total of {totalHits} hits");
        }

    }
}
