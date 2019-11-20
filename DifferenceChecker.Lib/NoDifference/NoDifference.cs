namespace DifferenceChecker.Lib.NoDifference
{
    public class NoDifference : IDifferenceInfo
    {
        private readonly IDifferenceChecker _differenceChecker;

        public NoDifference(IDifferenceChecker differenceChecker)
        {
            _differenceChecker = differenceChecker;
        }

        public string GetDifferenceName()
        {
            return _differenceChecker.GetName();
        }
    }
}