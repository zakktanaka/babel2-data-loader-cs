using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Csv
{
    public interface ICsvFactory : ICsvReaderFactory, ICsvWriterFactory
    {
    }
}
