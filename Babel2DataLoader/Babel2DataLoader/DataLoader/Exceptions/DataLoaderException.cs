using System;

namespace Babel2.DataLoader.Exceptions
{
    public class DataLoaderException : Exception
    {
        public DataLoaderException()
        {
        }

        public DataLoaderException(string message) :base(message)
        {
        }

        public DataLoaderException(string message, params object[] args) :
            this(string.Format(message, args))
        {
        }
    }
}
