namespace DifferenceChecker.Lib
{
    public interface IDifferenceInfoPrinterFactory
    {
        IDifferenceInfoPrinter GetPrinter(IDifferenceInfo differenceInfo);
    }
}