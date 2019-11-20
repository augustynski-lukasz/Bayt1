using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib.StringLength.Printers
{
    public class ConsolePrinter : BaseDifferenceInfoPrinter<StringLengthInfo>
    {
        public ConsolePrinter(StringLengthInfo differenceInfo) : base(differenceInfo)
        {
        }

        public override string PrintMessage()
        {
            return $"{DifferenceInfo.GetDifferenceName()}: the longer string is '{DifferenceInfo.Longer}' by {DifferenceInfo.Number} characters";
        }
    }

}