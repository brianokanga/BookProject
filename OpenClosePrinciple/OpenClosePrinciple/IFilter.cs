using System.Collections;
using System.Collections.Generic;

namespace OpenClosePrinciple
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filters(IEnumerable<T> items, ISpecification<T> spec);
    }
}