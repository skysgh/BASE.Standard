﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     pre-process all new/updated/modified entities
    ///     belonging to a specific DbContext, before
    ///     they are saved.
    ///     <para>
    ///         This service implementation is invoked because
    ///         the various DbContext implementations (eg: AppDbContext)
    ///         override their SaveChanges method to do so
    ///         TODO: currently it's not automatically handled from the IUnitOfWorkService implementation.
    ///     </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IDbContextPreCommitService : IInfrastructureService
    {
        /// <summary>
        ///     Pass all entities belonging to the specified DbContext
        ///     through all implementations of
        ///     <see cref="IDbCommitPreCommitProcessingStrategy" />
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        void PreProcess(DbContext dbContext);
    }
}