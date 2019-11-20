using DifferenceChecker.Lib.Common;
using DifferenceChecker.Lib.LetterCase.Info;

namespace DifferenceChecker.Lib.LetterCase.Printers
{
    public class ConsolePrinter : BaseDifferenceInfoPrinter<LetterCaseDifferenceInfo>
    {
        public ConsolePrinter(LetterCaseDifferenceInfo differenceInfo) : base(differenceInfo)
        {
        }

        public override string PrintMessage()
        {
            return $"{DifferenceInfo.GetDifferenceName()}: there are differences at positions: {string.Join(',',DifferenceInfo.Positions.ToArray())}";
        }
    }
}