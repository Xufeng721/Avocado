using Avocado.Entities;
using Avocado.Services;
using FluentAssertions;
using Xunit;

namespace Avocado.Tests
{
    public class SuperProcssorTests
    {
        private readonly IProcessor<Super> _processor;

        public SuperProcssorTests()
        {
            _processor = new SuperProcessor(new CsvParser());
        }

        [Fact]
        public void ShouldParseAndReturnListOfSuperData()
        {
            string path = "../../../Avocado/Data/Super.csv";
            var result = _processor.ProcessData(path);

            result.Count.Should().Be(18);
            result[9].StaffId.Should().Be(10);
            result[9].SuperName.Should().Be("SuperJJJ");
            result[9].AccountNo.Should().Be("0000000");
        }
    }
}
