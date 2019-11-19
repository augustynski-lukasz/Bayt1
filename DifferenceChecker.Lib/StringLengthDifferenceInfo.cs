namespace DifferenceChecker.Lib
{
    public class StringLengthDifferenceInfo : IDifferenceInfo
    {
        public string Longer { get; private set; }

        public StringLengthDifferenceInfo(string longer)
        {
            Longer = longer;
        }
    }
}