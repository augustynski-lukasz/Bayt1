using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferenceChecker.Lib
{
    public class StringDifferenceCheckBuilder : IDifferenceCheckBuilder<string>
    {
        private List<IDifferenceChecker<string>> _differenceCheckers = new List<IDifferenceChecker<string>>();
        private List<IDifferenceInfo> _differenceInfos = new List<IDifferenceInfo>();
        private IDifferenceInfoPrinterFactory _printerFactory;
        private string _first;
        private string _second;

        public IDifferenceCheckBuilder<string> AddDifferenceCheck(IDifferenceChecker<string> checker)
        {
            _differenceCheckers.Add(checker);
            return this;
        }

        public IDifferenceCheckBuilder<string> Check(string first, string second)
        {
            _first = first;
            _second = second;

            _differenceCheckers
                .ForEach(x =>_differenceInfos.Add(x.Check(first, second)));
            return this;
        }

        public IDifferenceCheckBuilder<string> WithPrinterFactory(IDifferenceInfoPrinterFactory printerFactory)
        {
            _printerFactory = printerFactory;
            return this;
        }

        public IList<IDifferenceInfo> GetDifferences()
        {
            return _differenceInfos;
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Checking differences between strings:");
            sb.AppendLine($"    1: '{_first}'");
            sb.AppendLine($"    2: '{_second}'");

            foreach (var differenceInfo in _differenceInfos)
            {
                sb.AppendLine(_printerFactory.GetPrinter(differenceInfo).PrintMessage());
            }

            return sb.ToString();
        }
    }
}