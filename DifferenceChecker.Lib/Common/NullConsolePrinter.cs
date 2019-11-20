using System;

namespace DifferenceChecker.Lib.Common
{
    public class NullConsolePrinter : IDifferenceInfoPrinter
    {
        public string PrintMessage()
        {            
            return String.Empty;
        }
    }
}