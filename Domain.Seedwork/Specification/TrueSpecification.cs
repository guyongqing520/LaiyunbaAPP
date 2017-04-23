

using System;
using System.Linq.Expressions;
namespace Domain.Seedwork.Specification
{
 

    public sealed class TrueSpecification<TEntity>
        :Specification<TEntity>
        where TEntity:class
    {
        #region Specification overrides

      
        public override System.Linq.Expressions.Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            bool result = true;
            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
