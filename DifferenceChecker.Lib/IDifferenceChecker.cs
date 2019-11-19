namespace DifferenceChecker.Lib
{
    public interface IDifferenceChecker
    {
        string GetName();
    }

    public interface IDifferenceChecker<T>  : IDifferenceChecker where T: class
    {
        IDifferenceInfo Check(T first, T second);
    }
}
