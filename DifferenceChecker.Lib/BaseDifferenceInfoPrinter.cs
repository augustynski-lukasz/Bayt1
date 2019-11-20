namespace DifferenceChecker.Lib
{
    public abstract class BaseDifferenceInfoPrinter<T> : IDifferenceInfoPrinter
        where T:IDifferenceInfo
    {
        protected T DifferenceInfo;

        protected BaseDifferenceInfoPrinter(T differenceInfo)
        {
            DifferenceInfo = differenceInfo;
        }

        public abstract string PrintMessage();
    }
}