namespace DifferenceChecker.Lib
{
    public interface IDifferenceInfoPrinterFactory
    {
        IDifferenceInfoPrinter GetIntroPrinter(string first, string second);
        IDifferenceInfoPrinter GetPrinter(IDifferenceInfo differenceInfo);
    }
}