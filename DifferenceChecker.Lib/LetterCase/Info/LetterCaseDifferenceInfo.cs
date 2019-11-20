using System.Collections.Generic;

namespace DifferenceChecker.Lib.LetterCase.Info
{
    public class LetterCaseDifferenceInfo : IDifferenceInfo
    {
        private readonly LetterCaseDifference _differenceChecker;

        public LetterCaseDifferenceInfo(LetterCaseDifference differenceChecker)
        {
            _differenceChecker = differenceChecker;
        }
        public List<int> Positions { get; } = new List<int>();
        internal void AddPosition(int i)
        {
            Positions.Add(i);
        }

        public string GetDifferenceName()
        {
            return _differenceChecker.GetName();
        }
    }
}