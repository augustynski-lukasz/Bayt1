using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib.StringLength
{
    public class StringLengthDifference : IDifferenceChecker<string>
    {
        public IDifferenceInfo Check(string one, string two)
        {
            var lengthDifference = one.Length - two.Length;

            if (lengthDifference > 0)
                return new StringLengthInfo(this, one, lengthDifference);

            if (lengthDifference < 0)
                return new StringLengthInfo(this, two, lengthDifference);

            return new NoDifference.NoDifference(this);
        }

        public string GetName()
        {
            return typeof(StringLengthDifference).Name;
        }
    }
}