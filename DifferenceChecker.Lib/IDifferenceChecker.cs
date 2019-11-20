namespace DifferenceChecker.Lib
{
    public interface IDifferenceChecker
    {
        string GetName();
    }

    public interface IDifferenceChecker<in T>  : IDifferenceChecker where T: class
    {
        IDifferenceInfo Check(T first, T second);
    }
}
