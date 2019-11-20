using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using DifferenceChecker.Lib.StringLength;
using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib.Tests
{
    public class StringDifferenceCheckerTests
    {
        private IDifferenceCheckBuilder<string> _differenceCheckBuilder;

        [SetUp]
        public void Setup()
        {
            _differenceCheckBuilder = new StringDifferenceCheckBuilder();
        }

        private static readonly object[] LengthDifferenceSource = new object[]
        {
            new object[] { "Aasdadsad", "dsadadsadadsa" },
            new object[] { "Aasd ads ad", "dsad adsada dsa" },
            new object[] { "Aasda dsa d", "ds adad sad adsa" }
        };

        [Test, TestCaseSource(nameof(LengthDifferenceSource))]
        public void Should_Report_Length_Difference(string first, string second)
        {
            var lengthDifferenceChecker = new StringLengthDifference();
            _differenceCheckBuilder
                .AddDifferenceCheck(lengthDifferenceChecker)
                .Check(first, second);

            var differences =  _differenceCheckBuilder.GetDifferences();

            differences.Should().HaveCount(1);
            differences
                .ElementAt(0)
                .Should().BeOfType<StringLengthInfo>()
                .Subject.Longer
                .Should().Be(second);
        }

        private static readonly object[] LengthEqualitySource = new object[]
        {
            new object[] { "Aasdadsad", "dsadadsad" },
            new object[] { "Aa ads ad", "dsad adsa" },
            new object[] { "Asda dsa d", "ds adad sa" }
        };

        [Test, TestCaseSource(nameof(LengthEqualitySource))]
        public void Should_Report_Length_Equality(string first, string second)
        {
            var lengthDifferenceChecker = new StringLengthDifference();
            _differenceCheckBuilder
                .AddDifferenceCheck(lengthDifferenceChecker)
                .Check(first, second);

            var differences = _differenceCheckBuilder.GetDifferences();

            differences.Should().HaveCount(1);
            differences
                .ElementAt(0)
                .Should().BeOfType<NoDifference.NoDifference>();
        }
    }
}