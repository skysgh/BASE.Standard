// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.Classic
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class DbController
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbController" /> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        public DbController(IDependencyResolutionService dependencyResolutionService)
        {
            _dependencyResolutionService = dependencyResolutionService;
        }

        /// <summary>
        ///     TODO: Seeds the specified module.
        /// </summary>
        /// <param name="module">The module.</param>
        public void Seed(string module)
        {
            var dbContext = _dependencyResolutionService.GetInstance<DbContext>(module);

            ((ModuleDbContextBase) dbContext).EnsureMutableDataIsSeeded();
        }
    }
}