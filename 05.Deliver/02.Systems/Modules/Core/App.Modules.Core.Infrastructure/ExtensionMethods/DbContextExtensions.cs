// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.ExtensionMethods
{
    /// Specifies how objects being loaded into the context are merged with objects already in the context.
    public enum MergeOption
    {
        Undefined = -1,

        /// Objects already in the context are not loaded from the data source (default behavior).
        AppendOnly = 0,

        /// Objects are always loaded from the data source. Any property changes made
        /// to objects in the object context are overwritten by the data source values.
        OverwriteChanges = 1,

        /// unmodified properties of objects in the object context are overwritten with server values.
        PreserveChanges = 2,

        /// Objects are maintained in a Detached state and are not tracked.
        NoTracking = 3
    }


    // Class to allow for use of EF's Include statement
    // from other assemblies, without needing to take 
    // a direct reference to EF.
    // Ie. App.Modules.Core.Domain Services and any specific Repositories 
    // can use 'Include'. 
    public static class QueryableEFExtgensions
    {
        public static IQueryable Include(this IQueryable source, string path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }

        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source,
            Expression<Func<T, TProperty>> path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }











        public static bool HasChanges(this DbContext context)
        {
            return context.ChangeTracker.HasChanges();
        }

        public static bool Any<TModel>(this DbContext context, Expression<Func<TModel, bool>> filter = null) where TModel : class
        {
            return filter != null ? context.Set<TModel>().Any(filter) : context.Set<TModel>().Any();
        }

        public static int Count<TModel>(this DbContext context, Expression<Func<TModel, bool>> filter = null) where TModel : class
        {
            return filter != null ? context.Set<TModel>().Count(filter) : context.Set<TModel>().Count();
        }

        public static TModel GetSingle<TModel>(this DbContext context, Expression<Func<TModel, bool>> filter,
            MergeOption mergeOptions = MergeOption.Undefined ) where TModel : class
        {
            return context.Set<TModel>().SingleOrDefault(filter);
        }

        public static IQueryable<TModel> GetQueryableSet<TModel>(this DbContext context) where TModel : class
        {
            return context.Set<TModel>();
        }

        public static IQueryable<TModel> GetQueryableSingle<TModel>(this DbContext context, Expression<Func<TModel, bool>> filter,
            MergeOption mergeOptions = MergeOption.Undefined) where TModel : class
        {
            return context.GetByFilter(filter, mergeOptions).Take(1);
        }

        public static IQueryable<TModel> GetByFilter<TModel>(this DbContext context, Expression<Func<TModel, bool>> filter,
            MergeOption mergeOptions) where TModel : class
        {
            return context.Set<TModel>().Where(filter);
        }


        public static void AddOrUpdate<TModel>(this DbContext context, Expression<Func<TModel, object>> identifierExpression,
            params TModel[] models) where TModel : class
        {
            context.Set<TModel>().AddOrUpdateBasedOnId(identifierExpression, models);
        }

        public static void PersistOnCommit<TModel, TId>(this DbContext context, TModel model) where TModel : class, IHasTimestamp
        {
            if (IsNew(model))
            {
                context.AddOnCommit(model);
            }
            else
            {
                context.UpdateOnCommit(model);
            }
        }

        public static void AddOnCommit<TModel>(this DbContext context, TModel model) where TModel : class
        {
            var debset = context.Set<TModel>();
            debset.Add(model);
        }

        public static void UpdateOnCommit<TModel>(this DbContext context, TModel model) where TModel : class
        {
            var dbEntityEntry = context.Entry(model);
            if (((int)dbEntityEntry.State).BitIsSet((int)EntityState.Detached))
            {
                context.Set<TModel>().Attach(model);
            }
            //Is this really needed?
            if (((int)dbEntityEntry.State).BitIsNotSet((int)EntityState.Modified))
            {
                dbEntityEntry.State |= EntityState.Modified;
            }
        }



        public static void DeleteOnCommit<TModel, TId>(this DbContext context, TId id) where TModel : class, IHasId<TId>, new()
        {
            var model = Activator.CreateInstance<TModel>();
            model.Id = id;
            var entityEntry = context.Entry(model);
            entityEntry.State = EntityState.Deleted;
        }

        public static void DeleteOnCommit<TModel>(this DbContext context, TModel model) where TModel : class
        {
            try
            {
                //We reset original values so that Auditing (see AuditableChangesStrategy) records Info *before* changes...
                var entityEntry = context.Entry(model);
                entityEntry.CurrentValues.SetValues(entityEntry.OriginalValues);
            }
            catch
            {
            }
            context.Set<TModel>().Remove(model);
        }

        public static void DeleteOnCommit<TModel>(this DbContext context, Expression<Func<TModel, bool>> predicate)
            where TModel : class
        {
            var models = context.GetByFilter(predicate, MergeOption.Undefined);

            foreach (var entity in models)
            {
                context.DeleteOnCommit(entity);
            }
        }

        public static bool IsAttached<TModel>(this DbContext context, TModel model) where TModel : class
        {
            var dbEntityEntry = context.Entry(model);
            {
                return !((int)dbEntityEntry.State).BitIsSet((int)EntityState.Detached);
            }
        }

        public static void AttachOnCommit<TModel>(this DbContext context, TModel model) where TModel : class
        {
            if (context.Entry(model).State != EntityState.Added) // since it's added dont' updated
            {
                context.Set<TModel>().Attach(model);
                context.Entry(model).State = EntityState.Modified;
            }
        }


        public static void Detach<TModel>(this DbContext context, TModel model) where TModel : class
        {
            context.Entry(model).State = EntityState.Detached;
        }


        public static bool IsNew<T>(T model) where T : IHasTimestamp
        {
            IHasTimestamp timestampped = model;
            return timestampped != null && (timestampped.Timestamp == null ? true : false);
        }

    }
}