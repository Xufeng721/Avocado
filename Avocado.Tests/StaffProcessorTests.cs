using Avocado.Entities;
using Avocado.Services;
using FluentAssertions;
using Xunit;

namespace Avocado.Tests
{
    public class StaffProcessorTests
    {
        private readonly IProcessor<Staff> _processor;

        public StaffProcessorTests()
        {
            _processor = new StaffProcessor(new CsvParser());
        }

        [Fact]
        public void ShouldParseAndReturnListOfStaffData()
        {
            string path = "../../../Avocado/Data/Staff.csv";
            var result = _processor.ProcessData(path);

            result.Count.Should().Be(18);
            result[9].Id.Should().Be(10);
            result[9].Name.Should().Be("JJJ");
        }
    }
}
