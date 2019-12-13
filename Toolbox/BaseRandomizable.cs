using System;
using System.Linq;

namespace Toolbox
{
    public abstract class BaseRandomizable<T> : Randomizable<T>
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        protected static Random _random = new Random();
        public abstract T Randomize();

        protected bool Coinflip()
        {
            return Convert.ToBoolean(_random.Next(0, 1));
        }
        protected string RandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
           .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        protected string Randomstring()
        {
            return RandomString(_random.Next(4, 10));
        }
        


    }
}
