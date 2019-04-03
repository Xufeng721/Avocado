using System.Collections.Generic;

namespace Avocado.Services
{
    public interface IProcessor<T>
    {
        IList<T> ProcessData(string filePath);
    }
}
