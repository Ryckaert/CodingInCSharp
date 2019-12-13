using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Toolbox
{
    public class FakeBigIntEnumerable : IEnumerable<int>
    {
        int Max;
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
            IntErnal = 0;
    }
}
}
