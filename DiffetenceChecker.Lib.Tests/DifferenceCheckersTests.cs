using DifferenceChecker.Lib;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace DiffetenceChecker.Lib.Tests
{
    public class DifferenceCheckersTests
    {
        private IDifferenceCheckBuilder<string> _differenceCheckBuilder;

        [SetUp]
        public void Setup()
        {
            _differenceCheckBuilder = new StringDifferenceCheckBuilder();
        }

        private static object[] LengthDifferenceSource = new object[]
        {
            new object[] { "Aasdadsad", "dsadadsadadsa" },
            new object[] { "Aasd ads ad", "dsad adsada dsa" },
            new object[] { "Aasda dsa d", "ds adad sad adsa" }
        };

        [Test, TestCaseSource("LengthDifferenceSource")]
        public void Should_Report_Length_Difference(string first, string second)
        {
            var lengthDifferenceChecker = new StringLengthDifferenceChecker();
            _differenceCheckBuilder
                .AddDifferenceCheck(lengthDifferenceChecker)
                .Check(first, second);

            var differences =  _differenceCheckBuilder.GetDifferences();

            differences.Should().HaveCount(1);
            differences
                .ElementAt(0)
                .Should().BeOfType<StringLengthDifferenceInfo>()
                .Subject.Longer
                .Should().Be(second);
        }

        private static object[] LengthEqualitySource = new object[]
        {
            new object[] { "Aasdadsad", "dsadadsad" },
            new object[] { "Aa ads ad", "dsad adsa" },
            new object[] { "Asda dsa d", "ds adad sa" }
        };

        [Test, TestCaseSource("LengthEqualitySource")]
        public void Should_Report_Length_Equality(string first, string second)
        {
            var lengthDifferenceChecker = new StringLengthDifferenceChecker();
            _differenceCheckBuilder
                .AddDifferenceCheck(lengthDifferenceChecker)
                .Check(first, second);

            var differences = _differenceCheckBuilder.GetDifferences();

            differences.Should().HaveCount(1);
            differences
                .ElementAt(0)
                .Should().BeOfType<NoDifference>();
        }
    }
}