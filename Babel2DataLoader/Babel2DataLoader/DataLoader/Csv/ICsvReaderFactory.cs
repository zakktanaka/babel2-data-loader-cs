using System.IO;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvReaderFactory
    {
        ICsvReader<T> GetReader<T>(TextReader tr);
    }
}
