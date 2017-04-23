using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Seedwork;

namespace Infrastructure.Data.Seedwork
{
  
    public interface IQueryableUnitOfWork
        : IUnitOfWork, ISql
    {
       
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

     
        void Attach<TEntity>(TEntity item) where TEntity : class;

        
        void SetModified<TEntity>(TEntity item) where TEntity : class;

      
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

    }
}
