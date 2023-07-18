using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get; }

        public List<Expression<Func<T, object>>> Includes {get; } = 
        new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        public List<ChainedQueryEntity<T>> ChainedQueries {get; } = 
        new List<ChainedQueryEntity<T>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        
        protected void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression,
        List<QueryExpressionContainer> thenIncludesExpressions)
        {
            ChainedQueries.Add(new ChainedQueryEntity<T>
            {
                Includes = includeExpression,
                ThenIncludes = thenIncludesExpressions
            });
        }
    }
}