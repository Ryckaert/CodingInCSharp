using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Toolbox
{
    /// <summary>
    /// Fake a large <see cref="IEnumerable{int}"/> quickly
    /// </summary>
    public class FakeBigEnumerable<T> : IEnumerable<T> where T : Randomizable<T>, new()
    {
        int Max;
        /// <summary>
        /// Fake an <see cref="IEnumerable{int}"/> containing the specified ammount of elements
        /// </summary>
        /// <param name="max"></param>
        public FakeBigEnumerable(int max)
        {
            this.Max = max;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new FakeBigEnumerator<T>(Max);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //Quick and dirty enumarator faking a enumerable containing a given set of ints
    class FakeBigEnumerator<T> : IEnumerator<T> where T : Randomizable<T>, new()
    {
        int currentIndex = -1;
        readonly int  Max ;
        public FakeBigEnumerator(int max)
        {
            Max = max;
        }
        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (currentIndex < Max)
            {
                Interlocked.Increment(ref currentIndex);
                Current = new T().Randomize();
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }

}
