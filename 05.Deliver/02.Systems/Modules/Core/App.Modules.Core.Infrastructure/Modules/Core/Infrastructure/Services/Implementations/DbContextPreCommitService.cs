// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Infrastructure.Data.Db.CommitInterceptions;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    //using App.Modules.Core.Infrastructure.Db.DbContextFactories;
    //using App.Modules.Core.Infrastructure.Db.DbContextFactories.Implementations;
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IDbContextPreCommitService" />
    ///     Infrastructure Service Contract
    ///     to pre-process all new/updated/modified entities
    ///     belonging to a specific DbContext, before
    ///     they are saved.
    ///     <para>
    ///         This service implementation is invoked because
    ///         the various DbContext implementations (eg: AppDbContext)
    ///         override their SaveChanges method to do so
    ///         TODO: currently it's not automatically handled from the IUnitOfWorkService implementation.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IDbContextPreCommitService" />
    public class DbContextPreCommitService : AppCoreServiceBase, IDbContextPreCommitService
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbContextPreCommitService" /> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        public DbContextPreCommitService(IDependencyResolutionService dependencyResolutionService)
        {
            _dependencyResolutionService = dependencyResolutionService;
        }

        /// <summary>
        ///     Pass all entities belonging to the specified DbContext
        ///     through all implementations of
        ///     TODO
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public void PreProcess(DbContext dbContext)
        {
            IEnumerable<IDbCommitPreCommitProcessingStrategy> preprocessors =
                _dependencyResolutionService
                    .GetAllInstances<IDbCommitPreCommitProcessingStrategy>();

            try
            {
                preprocessors
                    .ForEach(x => x.Process(dbContext));
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }
    }
}