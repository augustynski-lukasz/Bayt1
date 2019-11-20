using DifferenceChecker.Lib.LetterCase.Info;
using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib.Common
{
    public class ConsolePrinterFactory : IDifferenceInfoPrinterFactory
    {
        public IDifferenceInfoPrinter GetIntroPrinter(string first, string second)
        {
            return new IntroConsolePrinter(first, second);
        }

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