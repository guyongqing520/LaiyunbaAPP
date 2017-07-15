using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.AddressAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.FavoriteAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.MsgAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.OrderAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;
using Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork
{
    public class MainBCUnitOfWork
        : DbContext
        , IQueryableUnitOfWork
    {

        public MainBCUnitOfWork()
            : base("name=MainBCUnitOfWork")
        {

        }

        #region IDbSet Members


        IDbSet<Account> _accounts;
        IDbSet<DriverWay> driverway;

        IDbSet<GooderProudct> _gooderProudct;
        IDbSet<Order> _order;

        IDbSet<Specway> _specway;
        IDbSet<Sms> _sms;

        IDbSet<CallLog> _callLog;
        IDbSet<LoginLog> _loginLog;

        IDbSet<Msg> _msg;
        IDbSet<Vip> _vip;

        IDbSet<Favorite> _favorite;
        IDbSet<Praise> _praise;

        IDbSet<City> _city;
        IDbSet<Area> _area;
        IDbSet<Province> _province;

        public IDbSet<Account> Accounts
        {
            get { return _accounts ?? (_accounts = base.Set<Account>()); }
        }

        public IDbSet<DriverWay> DriverWay
        {
            get { return driverway ?? (driverway = base.Set<DriverWay>()); }
        }

        public IDbSet<GooderProudct> GooderProudct
        {
            get { return _gooderProudct ?? (_gooderProudct = base.Set<GooderProudct>()); }
        }

        public IDbSet<Order> Order
        {
            get { return _order ?? (_order = base.Set<Order>()); }
        }

        public IDbSet<Specway> Specway
        {
            get { return _specway ?? (_specway = base.Set<Specway>()); }
        }

        public IDbSet<Sms> Sms
        {
            get { return _sms ?? (_sms = base.Set<Sms>()); }
        }


        public IDbSet<CallLog> CallLog
        {
            get { return _callLog ?? (_callLog = base.Set<CallLog>()); }
        }

        public IDbSet<LoginLog> LoginLog
        {
            get { return _loginLog ?? (_loginLog = base.Set<LoginLog>()); }
        }

        public IDbSet<Vip> Vip
        {
            get { return _vip ?? (_vip = base.Set<Vip>()); }
        }

        public IDbSet<Msg> Msg
        {
            get { return _msg ?? (_msg = base.Set<Msg>()); }
        }

        public IDbSet<Favorite> Favorite
        {
            get { return _favorite ?? (_favorite = base.Set<Favorite>()); }
        }

        public IDbSet<Praise> Praise
        {
            get { return _praise ?? (_praise = base.Set<Praise>()); }
        }

        IDbSet<City> City
        {
            get { return _city ?? (_city = base.Set<City>()); }
        }

        IDbSet<Area> Area
        {
            get { return _area ?? (_area = base.Set<Area>()); }
        }
        IDbSet<Province> Province
        {
            get { return _province ?? (_province = base.Set<Province>()); }
        }

        #endregion

        #region IQueryableUnitOfWork Members

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            base.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.Entity.EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Add entity configurations in a structured way using 'TypeConfiguration’classes
            modelBuilder.Configurations.Add(new AccountEntityConfiguration());
            modelBuilder.Configurations.Add(new CallLogEntityConfiguration());
            modelBuilder.Configurations.Add(new DriverWayEntityConfiguration());
            modelBuilder.Configurations.Add(new FavoriteEntityConfiguration());
            modelBuilder.Configurations.Add(new GooderProudctEntityConfiguration());
            modelBuilder.Configurations.Add(new LoginLogEntityConfiguration());
            modelBuilder.Configurations.Add(new MsgEntityConfiguration());
            modelBuilder.Configurations.Add(new OrderEntityConfiguration());
            modelBuilder.Configurations.Add(new PraiseEntityConfiguration());
            modelBuilder.Configurations.Add(new SmsEntityConfiguration());
            modelBuilder.Configurations.Add(new SpecwayEntityConfiguration());
            modelBuilder.Configurations.Add(new VipEntityConfiguration());

        }
        #endregion
    }
}
