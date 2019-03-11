using System;
using System.Collections.Generic;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvWriter<T> : IDisposable
    {
        ICsvWriter<T> WriteRecord(T record);
        ICsvWriter<T> WriteRecords(IEnumerable<T> records);
    }
}
