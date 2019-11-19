using System;

namespace DifferenceChecker.Lib
{

    public interface IDifferenceInfo
    {

    }

    public class NoDifference : IDifferenceInfo
    {
        private readonly IDifferenceChecker _differenceChecker;

        public NoDifference(IDifferenceChecker differenceChecker)
        {
            _differenceChecker = differenceChecker;
        }
    }
}
