using System.IO;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvWriterFactory
    {
        ICsvWriter<T> GetWriter<T>(TextWriter tw);
    }
}
