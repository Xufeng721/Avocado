using System.Collections.Generic;
using System.Linq;
using Avocado.Entities;

namespace Avocado.Services
{
    public class SuperProcessor : IProcessor<Super>
    {
        private readonly IParser _parser;

        public SuperProcessor(IParser parser)
        {
            _parser = parser;
        }

        public IList<Super> ProcessData(string filePath)
        {
            var result = _parser.Parse<Super>(filePath);
            return result.ToList();
        }
    }
}
