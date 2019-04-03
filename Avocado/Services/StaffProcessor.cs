using Avocado.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Avocado.Services
{
    public class StaffProcessor : IProcessor<Staff>
    {
        private readonly IParser _parser;

        public StaffProcessor(IParser parser)
        {
            _parser = parser;
        }

        public IList<Staff> ProcessData(string filePath)
        {
            var result = _parser.Parse<Staff>(filePath);
            return result.ToList();
        }
    }
}
