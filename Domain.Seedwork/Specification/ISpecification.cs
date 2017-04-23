

using System;
using System.Linq.Expressions;
namespace Domain.Seedwork.Specification
{
  
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
