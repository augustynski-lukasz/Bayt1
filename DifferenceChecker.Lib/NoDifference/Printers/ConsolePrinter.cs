using DifferenceChecker.Lib.Common;

namespace DifferenceChecker.Lib.NoDifference.Printers
{
    public class ConsolePrinter : BaseDifferenceInfoPrinter<NoDifference>
    {
        public ConsolePrinter(NoDifference differenceInfo) : base(differenceInfo)
        {
        }

        public override string PrintMessage()
        {
            return $"{DifferenceInfo.GetDifferenceName()}: there is no difference";
        }
    }
}