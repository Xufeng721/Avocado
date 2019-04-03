using System.Collections.Generic;
using System.IO;

namespace Avocado.Services
{
    public interface IParser
    {
        IEnumerable<T> Parse<T>(string filePath) where T : class, new();
    }

    public class CsvParser : IParser
    {
        private const char Delimiter = ',';

        public IEnumerable<T> Parse<T>(string filePath) where T : class, new()
        {
            using (var sr = new StreamReader(filePath))
            {
                string currentLine = sr.ReadLine();
                string[] usedHeaders = currentLine.Split(Delimiter);

                while ((currentLine = sr.ReadLine()) != null)
                {
                    var fields = currentLine.Split(Delimiter);
                    var result = new T();
                    for (var i = 0; i < usedHeaders.Length; i++)
                    {
                        dynamic value;
                        var propInfo = typeof(T).GetProperty(usedHeaders[i]);
                        if (propInfo.PropertyType.Name == "Int32")
                        {
                            value = int.Parse(fields[i]);
                        }
                        else
                        {
                            value = fields[i];
                        }

                        result.GetType()
                                .GetProperty(propInfo.Name)
                                .SetValue(result, value);
                    }
                    yield return result;
                }
            }
        }
    }
}
