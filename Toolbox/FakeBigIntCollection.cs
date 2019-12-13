using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Toolbox
{
    /// <summary>
    /// Fake a large <see cref="IEnumerable{int}"/> quickly
    /// </summary>
    public class FakeBigIntEnumerable : IEnumerable<int>
    {
        int Max;
        /// <summary>
        /// Fake an <see cref="IEnumerable{int}"/> containing the specified ammount of elements
        /// </summary>
        /// <param name="max"></param>
        public FakeBigIntEnumerable(int max)
        {
            this.Max = max;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new FakeBigIntEnumerator(Max);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //Quick and dirty enumarator faking a enumerable containing a given set of ints
    class FakeBigIntEnumerator : IEnumerator<int>
    {
        public FakeBigIntEnumerator(int max )
        {
            this.Max = max;
        }
        private int IntErnal = 0;
        private readonly int Max;
        public int Current => IntErnal;

        object IEnumerator.Current => IntErnal;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (IntErnal < Max)
            {
                Interlocked.Increment(ref IntErnal);
                return true;
            }
            return false;
        }

    public void Reset()
    {
            IntErnal = -1;
    }
}
}
