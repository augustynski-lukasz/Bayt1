using System;
using System.Collections.Generic;
using System.Text;

namespace DifferenceChecker.Lib.Checkers
{
    public class LetterCaseDifference : IDifferenceChecker<string>
    {
        public IDifferenceInfo Check(string first, string second)
        {
            var differenceInfo = new LetterCaseDifferenceInfo();
            var maxLength = Math.Min(first.Length, second.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (char.ToLower(first[i]) == char.ToLower(second[i]) 
                    && first[i] != second[i])
                {
                    differenceInfo.AddPosition(i);
                }
            }

            return differenceInfo;
        }

        public string GetName()
        {
            return typeof(LetterCaseDifference).Name;
        }
    }
}
