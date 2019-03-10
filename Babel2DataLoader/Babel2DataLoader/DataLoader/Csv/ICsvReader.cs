using System.Collections.Generic;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvReader<T>
    {
        IEnumerable<T> GetRecords();
    }
}
