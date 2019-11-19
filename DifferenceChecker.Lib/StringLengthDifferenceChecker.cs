namespace DifferenceChecker.Lib
{
    public class StringLengthDifferenceChecker : IDifferenceChecker<string>
    {
        public IDifferenceInfo Check(string one, string two)
        {
            if(one.Length>two.Length)
                return new StringLengthDifferenceInfo(one);

            if (one.Length < two.Length)
                return new StringLengthDifferenceInfo(two);

            return new NoDifference(this);
        }

        public string GetName()
        {
            return typeof(StringLengthDifferenceChecker).Name;
        }
    }
}