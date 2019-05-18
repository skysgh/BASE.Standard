﻿using Microsoft.EntityFrameworkCore;
using App.Modules.Core.Infrastructure.Data.Db.CommitInterceptions;
using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    //using App.Modules.Core.Infrastructure.Db.DbContextFactories;
    //using App.Modules.Core.Infrastructure.Db.DbContextFactories.Implementations;
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IDbContextPreCommitService" />
    ///     Infrastructure Service Contract
    /// to pre-process all new/updated/modified entities
    /// belonging to a specific DbContext, before 
    /// they are saved.
    /// <para>
    /// This service implementation is invoked because
    /// the various DbContext implementations (eg: AppDbContext)
    /// override their SaveChanges method to do so
    /// TODO: currently it's not automatically handled from the IUnitOfWorkService implementation.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IDbContextPreCommitService" />
    public class DbContextPreCommitService : AppCoreServiceBase, IDbContextPreCommitService
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;

        public DbContextPreCommitService(IDependencyResolutionService dependencyResolutionService)
        {
            _dependencyResolutionService = dependencyResolutionService;
        }
        /// <summary>
        /// Pass all entities belonging to the specified DbContext
        /// through all implementations of 
        /// <see cref=""/>
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public void PreProcess(DbContext dbContext)
        {
            var preprocessors =
            _dependencyResolutionService
                .GetAllInstances<IDbCommitPreCommitProcessingStrategy>();

            try
            {
                preprocessors
                    .ForEach(x => x.Process(dbContext));
            }catch(System.Exception e)
            {
                var s = e.Message;
            }



        }
    }
}