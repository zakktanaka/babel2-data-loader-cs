using System.IO;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvReaderFctory
    {
        ICsvReader<T> GetReader<T>(TextReader tr);
    }
}
