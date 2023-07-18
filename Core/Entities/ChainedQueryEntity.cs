using System.Linq.Expressions;

namespace Core.Entities
{
    
    public class QueryExpressionContainer
    {
        public Type ExpressionType { get; set; }
        public LambdaExpression QueryExpression { get; set; }
    }

    public class ChainedQueryEntity<T>
    {
        public Expression<Func<T, object>> Includes { get; set; }
        public List<QueryExpressionContainer> ThenIncludes { get; set; }
    }
}