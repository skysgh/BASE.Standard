//using App.Modules.Core.Infrastructure.Constants.Db;
//using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;

//namespace App.Modules.Core.Infrastructure.Services.Implementations
//{
//    using Microsoft.EntityFrameworkCore;


//    /// <summary>
//    ///     Implementation of the
//    ///     <see cref="IUnitOfWorkService" />
//    ///     Infrastructure Service Contract
//    /// for a generic unit of work service
//    /// which manages the persistence of entities
//    /// using one or more channels (note 
//    /// that in most apps, this is usually just wrapping
//    /// one -- the DbContext client). 
//    /// </summary>
//    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IUnitOfWorkService" />
//    public class UnitOfWorkService : AppCoreServiceBase, IUnitOfWorkService
//    {
//        /// <summary>
//        /// Commits a single specific named repository, or all of pending changes.
//        /// </summary>
//        /// <param name="contextName"></param>
//        /// <returns></returns>
//        public int Commit(string contextName = null)
//        {
//            var result = 0;
            
//            foreach (var dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
//            {
//                try
//                {
//                    // Note that I've sort of forgetten how, 
//                    // it's wired up, but this will trigger 
//                    // calls to all instances of 
//                    // IDbCommitPreCommitProcessingStrategy
//                    // via IDbContextPreCommitService
//                    result += dbContext.SaveChanges();
//                }
//                catch (System.Exception e)
//                {
//                    throw e;
//                }
//            }
//            return result;
//        }

//        public int CommitBatch(string contextName = null)
//        {
//            var result = 0;
//            if (string.IsNullOrWhiteSpace(contextName))
//            {
//                contextName = CoreModuleDbContextNames.Core;
//            }

//            var dbContext = AppDependencyLocator.Current.GetInstance<DbContext>(contextName);
//            try
//            {
//                // Note that I've sort of forgetten how, 
//                // it's wired up, but this will trigger 
//                // calls to all instances of 
//                // IDbCommitPreCommitProcessingStrategy
//                // via IDbContextPreCommitService
//                dbContext.Configuration.AutoDetectChangesEnabled = false;
//                dbContext.Configuration.ValidateOnSaveEnabled = false;
//                result += dbContext.SaveChanges();
//            }
//            catch (System.Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                dbContext.Configuration.AutoDetectChangesEnabled = true;
//                dbContext.Configuration.ValidateOnSaveEnabled = true;
//            }
//            return result;
//        }
//    }
//}