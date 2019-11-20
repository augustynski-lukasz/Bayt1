using System;

namespace DifferenceChecker.Lib.StringLength.Info
{
    public class StringLengthInfo : IDifferenceInfo
    {
        private readonly IDifferenceChecker _differenceChecker;
        public string Longer { get; private set; }
        public int Number { get; private set; }

        public StringLengthInfo(IDifferenceChecker differenceChecker, 
            string longer,
            int number)
        {
            _differenceChecker = differenceChecker;
            Longer = longer;
            Number = Math.Abs(number);
        }

        public string GetDifferenceName()
        {
            return _differenceChecker.GetName();
        }
    }

   
}