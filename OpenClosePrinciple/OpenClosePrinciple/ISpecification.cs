namespace OpenClosePrinciple
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}