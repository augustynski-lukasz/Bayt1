namespace DifferenceChecker.Lib
{
    public class NoDifference : IDifferenceInfo
    {
        private readonly IDifferenceChecker _differenceChecker;

        public NoDifference(IDifferenceChecker differenceChecker)
        {
            _differenceChecker = differenceChecker;
        }
    }
}