using System;
using DifferenceChecker.Lib;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using DifferenceChecker.Lib.LetterCase;
using DifferenceChecker.Lib.LetterCase.Info;

namespace DifferenceChecker.Lib.Tests
{
    public class LetterCaseDifferenceCheckerTests
    {
        private IDifferenceCheckBuilder<string> _differenceCheckBuilder;

        [SetUp]
        public void Setup()
        {
            _differenceCheckBuilder = new StringDifferenceCheckBuilder();
        }

        private static object[] LetterCaseDifferenceSource = new object[]
        {
            new object[] { "AaSdaDsad", "aasdadsad", ( Number:3, Positions: new []{0,2,5}) },
            new object[] { "asdadregngfsda", "asDAdreGngF", ( Number:4, Positions: new []{2,3,7,10}) }
        };

        [Test, TestCaseSource("LetterCaseDifferenceSource")]
        public void Should_Report_LetterCase_Difference(string first, string second, (int Number, int[] Positions) results)
        {
            var differenceChecker = new LetterCaseDifference();
            _differenceCheckBuilder
                .AddDifferenceCheck(differenceChecker)
                .Check(first, second);

            var differences =  _differenceCheckBuilder.GetDifferences();

            differences.Should().HaveCount(1);
            var positions = differences
                .ElementAt(0)
                .Should().BeOfType<LetterCaseDifferenceInfo>()
                .Subject.Positions;

            positions.Should().HaveCount(results.Number);
            positions.Should().Equal(results.Positions);

        }

        private static object[] LetterCaseNoDifferenceSource = new object[]
        {
            new object[] { "AaSdaDsad", "AaSdaDsad"},
            new object[] { "asdadregngfsda", "asdadregng" }
        };

        [Test, TestCaseSource("LetterCaseNoDifferenceSource")]
        public void Should_Report_NoDifference(string first, string second)
        {
            var differenceChecker = new LetterCaseDifference();
            _differenceCheckBuilder
                .AddDifferenceCheck(differenceChecker)
                .Check(first, second);

            var differences = _differenceCheckBuilder.GetDifferences();

            differences
                .Should().HaveCount(1)
                .And
                .Subject.ElementAt(0)
                .Should().BeOfType<NoDifference.NoDifference>();                
        }

    }
}