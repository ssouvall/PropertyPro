using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }
        List<Expression<Func<T, object>>> Includes {get; }
        List<string> IncludeStrings {get ; }
        List<ChainedQueryEntity<T>> ChainedQueries {get ;}
    }
}