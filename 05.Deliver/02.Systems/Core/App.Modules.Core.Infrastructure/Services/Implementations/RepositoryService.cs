﻿//using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;

//namespace App.Modules.Core.Infrastructure.Services.Implementations
//{
//    using System;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using App.Modules.Core.Infrastructure.Constants.Db;
//    using App.Modules.Core.Shared.Models;
//    using Microsoft.EntityFrameworkCore;

//    /// <summary>
//    ///     Implementation of the
//    ///     <see cref="IRepositoryService" />
//    ///     Infrastructure Service Contract
//    /// </summary>
//    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IRepositoryService" />
//    public class RepositoryService : AppCoreServiceBase, IRepositoryService
//    {

//        public RepositoryService()
//        {
//        }


//        public bool HasChanges(string contextKey)
//        {
//            return HasChanges(GetDbContext(contextKey));
//        }

//        protected bool HasChanges(DbContext context)
//        {
//            return context.ChangeTracker.HasChanges();
//        }

//        public bool Any<TModel>(string contextKey, Expression<Func<TModel, bool>> filter = null) where TModel : class
//        {
//            return filter != null ? GetDbSet<TModel>(contextKey).Any(filter) : GetDbSet<TModel>(contextKey).Any();
//        }

//        public int Count<TModel>(string contextKey, Expression<Func<TModel, bool>> filter = null) where TModel : class
//        {
//            return filter != null ? GetDbSet<TModel>(contextKey).Count(filter) : GetDbSet<TModel>(contextKey).Count();
//        }

//        public TModel GetSingle<TModel>(string contextKey, Expression<Func<TModel, bool>> filter,
//            MergeOption mergeOptions) where TModel : class
//        {
//            return GetDbSet<TModel>(contextKey).SingleOrDefault(filter);
//        }

//        public IQueryable<TModel> GetQueryableSet<TModel>(string contextKey) where TModel : class
//        {
//            return GetDbSet<TModel>(contextKey);
//        }

//        public IQueryable<TModel> GetQueryableSingle<TModel>(string contextKey, Expression<Func<TModel, bool>> filter,
//            MergeOption mergeOptions) where TModel : class
//        {
//            return GetByFilter(contextKey, filter, mergeOptions).Take(1);
//        }

//        public IQueryable<TModel> GetByFilter<TModel>(string contextKey, Expression<Func<TModel, bool>> filter,
//            MergeOption mergeOptions) where TModel : class
//        {
//            return GetDbSet<TModel>(contextKey).Where(filter);
//        }


//        public void AddOrUpdate<TModel>(string contextKey, Expression<Func<TModel, object>> identifierExpression,
//            params TModel[] models) where TModel : class
//        {
//            GetDbSet<TModel>(contextKey).AddOrUpdateBasedOnId(identifierExpression, models);
//        }

//        public void PersistOnCommit<TModel, TId>(string contextKey, TModel model) where TModel : class, IHasTimestamp
//        {
//            if (IsNew(model))
//            {
//                AddOnCommit(contextKey, model);
//            }
//            else
//            {
//                UpdateOnCommit(contextKey, model);
//            }
//        }

//        public void AddOnCommit<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            var debset = GetDbSet<TModel>(contextKey);
//            debset.Add(model);
//        }

//        public void UpdateOnCommit<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            var dbEntityEntry = GetDbContext(contextKey).Entry(model);
//            if (((int) dbEntityEntry.State).BitIsSet((int) EntityState.Detached))
//            {
//                GetDbSet<TModel>(contextKey).Attach(model);
//            }
//            //Is this really needed?
//            if (((int) dbEntityEntry.State).BitIsNotSet((int) EntityState.Modified))
//            {
//                dbEntityEntry.State |= EntityState.Modified;
//            }
//        }



//        public void DeleteOnCommit<TModel, TId>(string contextKey, TId id) where TModel : class, IHasId<TId>, new()
//        {
//            var model = Activator.CreateInstance<TModel>();
//            model.Id = id;
//            var entityEntry = GetDbContext(contextKey).Entry(model);
//            entityEntry.State = EntityState.Deleted;
//        }

//        public void DeleteOnCommit<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            try
//            {
//                //We reset original values so that Auditing (see AuditableChangesStrategy) records Info *before* changes...
//                var entityEntry = GetDbContext(contextKey).Entry(model);
//                entityEntry.CurrentValues.SetValues(entityEntry.OriginalValues);
//            }
//            catch
//            {
//            }
//            GetDbSet<TModel>(contextKey).Remove(model);
//        }

//        public void DeleteOnCommit<TModel>(string contextKey, Expression<Func<TModel, bool>> predicate)
//            where TModel : class
//        {
//            var models = GetByFilter(contextKey, predicate, MergeOption.Undefined);

//            foreach (var entity in models)
//            {
//                DeleteOnCommit(contextKey, entity);
//            }
//        }

//        public bool IsAttached<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            var dbEntityEntry = GetDbContext(contextKey).Entry(model);
//            {
//                return !((int) dbEntityEntry.State).BitIsSet((int) EntityState.Detached);
//            }
//        }

//        public void AttachOnCommit<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            if (GetDbContext(contextKey).Entry(model).State != EntityState.Added) // since it's added dont' updated
//            {
//                GetDbSet<TModel>(contextKey).Attach(model);
//                GetDbContext(contextKey).Entry(model).State = EntityState.Modified;
//            }
//        }


//        public void Detach<TModel>(string contextKey, TModel model) where TModel : class
//        {
//            GetDbContext(contextKey).Entry(model).State = EntityState.Detached;
//        }


//        public bool IsNew<T>(T model) where T : IHasTimestamp
//        {
//            IHasTimestamp timestampped = model;
//            return timestampped != null && (timestampped.Timestamp == null ? true : false);
//        }

//        public void SaveChanges(string contextKey)
//        {
//            GetDbContext(contextKey).SaveChanges();
//        }

//        protected virtual DbContext GetDbContext(string contextKey)
//        {
//            if (string.IsNullOrWhiteSpace(contextKey))
//            {
//                contextKey = CoreModuleDbContextNames.Core;
//            }
//            return DependencyLocator.Current.GetInstance<DbContext>(contextKey);
//        }

//        protected DbSet<T> GetDbSet<T>(string contextKey) where T : class
//        {
//            return GetDbContext(contextKey).Set<T>();
//        }
//    }
//}