using Domain.Seedwork;
using Domain.Seedwork.Specification;
using Infrastructure.Crosscutting.Logging;
using Infrastructure.Data.Seedwork.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seedwork
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        #region Members

        IQueryableUnitOfWork _UnitOfWork;

        #endregion

        #region Constructor

        
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {

            if (item != (TEntity)null)
                GetSet().Add(item); // add new item in this set
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotAddNullEntity, typeof(TEntity).ToString());

            }

        }
        
        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                //attach item if not exist
                _UnitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

       
        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Attach<TEntity>(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        
        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.SetModified(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotModifyNullEntity, typeof(TEntity).ToString());
            }
        }

       
        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            else
                return null;
        }
        
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }
        
        public virtual IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification)
        {
            return GetSet().Where(specification.SatisfiedBy());
        }
       
        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }
        
        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        #endregion

        #region IDisposable Members

        
        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
        #endregion
    }
}
