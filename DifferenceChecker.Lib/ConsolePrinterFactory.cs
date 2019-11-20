using DifferenceChecker.Lib.LetterCase.Info;
using DifferenceChecker.Lib.NoDifference.Printers;
using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib
{
    public class ConsolePrinterFactory : IDifferenceInfoPrinterFactory
    {
        public IDifferenceInfoPrinter GetPrinter(IDifferenceInfo differenceInfo)
        {
            switch (differenceInfo)
            {
                case StringLengthInfo p:
                    return new StringLength.Printers.ConsolePrinter(p);
                case LetterCaseDifferenceInfo p:
                    return new LetterCase.Printers.ConsolePrinter(p);
                case NoDifference.NoDifference p:
                    return new NoDifference.Printers.ConsolePrinter(p);
            }

            return new NullConsolePrinter();
        }
    }
}