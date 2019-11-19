using System.Collections;
using System.Collections.Generic;

namespace DifferenceChecker.Lib
{
    public interface IDifferenceCheckBuilder<T> where T : class
    {
        IDifferenceCheckBuilder<T> AddDifferenceCheck(IDifferenceChecker<T> checker);
        IDifferenceCheckBuilder<T> Check(T first, T second);

        IList<IDifferenceInfo> GetDifferences();
    }
}