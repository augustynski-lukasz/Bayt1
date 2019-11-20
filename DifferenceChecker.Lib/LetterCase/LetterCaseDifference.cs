using System;
using System.Linq;
using DifferenceChecker.Lib.LetterCase.Info;

namespace DifferenceChecker.Lib.LetterCase
{
    public class LetterCaseDifference : IDifferenceChecker<string>
    {
        public IDifferenceInfo Check(string first, string second)
        {
            var differenceInfo = new LetterCaseDifferenceInfo(this);
            var maxLength = Math.Min(first.Length, second.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (char.ToLower(first[i]) == char.ToLower(second[i]) 
                    && first[i] != second[i])
                {
                    differenceInfo.AddPosition(i);
                }
            }

            return differenceInfo.Positions.Any()
                ? (IDifferenceInfo) differenceInfo
                : (IDifferenceInfo) new NoDifference.NoDifference(this);
        }

        public string GetName()
        {
            return typeof(LetterCaseDifference).Name;
        }
    }
}
