using System.Linq.Expressions;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => {
                return current.Include(include);
            });
            query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
            // query = spec.ChainedQueries.Aggregate(query, (current, include) => {
            //     var expression = current.Include(include.Includes);
            //     foreach(var item in include.ThenIncludes)
            //     {
            //         Type itemType = (item.ExpressionType);
            //         var thenIncludeMethod = typeof(EntityFrameworkQueryableExtensions)
            //             .GetMethod("ThenInclude")
            //             .MakeGenericMethod(itemType);
                    
            //         expression = (IIncludableQueryable<TEntity, itemType>)thenIncludeMethod
            //             .Invoke(null, new object[] { expression, item.QueryExpression });
            //     }
            //     return expression;
            // }); 
            return query;
        }   
    }
}