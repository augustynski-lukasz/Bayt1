using System.Text;

namespace DifferenceChecker.Lib.Common
{
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