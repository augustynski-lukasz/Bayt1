using System;

namespace DifferenceChecker.Lib
{
    public class NullConsolePrinter : IDifferenceInfoPrinter
    {
        public string PrintMessage()
        {            
            return String.Empty;
        }
    }
}