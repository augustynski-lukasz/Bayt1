using System.Text;
using DifferenceChecker.Lib.LetterCase.Info;
using DifferenceChecker.Lib.NoDifference.Printers;
using DifferenceChecker.Lib.StringLength.Info;

namespace DifferenceChecker.Lib
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

    public class IntroConsolePrinter : IDifferenceInfoPrinter
    {
        private readonly string _first;
        private readonly string _second;

        public IntroConsolePrinter(string first, string second)
        {
            _first = first;
            _second = second;            
        }

        public string PrintMessage()
        {
            var sb = new StringBuilder("Checking differences between strings:\n");
            sb.AppendLine($"    1: '{_first}'");
            sb.AppendLine($"    2: '{_second}'");
            return sb.ToString();
        }
    }
}