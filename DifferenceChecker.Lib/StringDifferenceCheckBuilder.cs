using System.Collections.Generic;
using System.Linq;

namespace DifferenceChecker.Lib
{
    public class StringDifferenceCheckBuilder : IDifferenceCheckBuilder<string>
    {
        private List<IDifferenceChecker<string>> _differenceCheckers = new List<IDifferenceChecker<string>>();
        private List<IDifferenceInfo> _differenceInfos = new List<IDifferenceInfo>();
        public IDifferenceCheckBuilder<string> AddDifferenceCheck(IDifferenceChecker<string> checker)
        {
            _differenceCheckers.Add(checker);
            return this;
        }

        public IDifferenceCheckBuilder<string> Check(string first, string second)
        {
            _differenceCheckers
                .ForEach(x =>_differenceInfos.Add(x.Check(first, second)));
            return this;
        }

        public IList<IDifferenceInfo> GetDifferences()
        {
            return _differenceInfos;
        }
    }
}