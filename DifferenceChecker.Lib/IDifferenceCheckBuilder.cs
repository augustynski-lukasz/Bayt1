﻿using System.Collections.Generic;

namespace DifferenceChecker.Lib
{
    public interface IDifferenceCheckBuilder<T> where T : class
    {
        IDifferenceCheckBuilder<T> AddDifferenceCheck(IDifferenceChecker<T> checker);
        IDifferenceCheckBuilder<T> Check(T first, T second);
        IDifferenceCheckBuilder<T> WithPrinterFactory(IDifferenceInfoPrinterFactory printerFactory);

        IList<IDifferenceInfo> GetDifferences();

        string Print();
    }
}