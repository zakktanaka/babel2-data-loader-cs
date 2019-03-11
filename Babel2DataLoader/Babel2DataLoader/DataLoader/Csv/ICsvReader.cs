using System;
using System.Collections.Generic;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvReader<T> : IDisposable
    {
        IEnumerable<T> Records { get; }
    }
}
