// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Infrastructure.Constants.Cache;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Caching
{
    /// <summary>
    ///     Notice the Key. This is how it gets registered automatically.
    /// </summary>
    [Key(StaticKeys.DefaultTenant)]
    public class DefaultTenancyCacheItem : CacheItemBase, IAppCoreCacheItem
    {
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IObjectMappingService _objectMappingService;

        /// <summary>
        /// </summary>
        /// <param name="azureRedisCacheService"></param>
        public DefaultTenancyCacheItem(
            IAzureRedisCacheService azureRedisCacheService,
            IObjectMappingService objectMappingService,
            ModuleDbContext repositoryService
        )
        {
            _azureRedisCacheService = azureRedisCacheService;
            _objectMappingService = objectMappingService;
            _coreRepositoryService = repositoryService;

            _duration = TimeSpan.FromMinutes(1);
        }

        public override object Get()
        {
            var result = _azureRedisCacheService.Get<TenantDto>(_key);

            if (result.IsDefaultOrNotInitialized())
            {
                result =

                    //_coreRepositoryService
                    //.GetQueryableSet<Tenant>()
                    //.Where(x => x.IsDefault == true)
                    //.ProjectTo<TenantDto>((object)null, x => x.Properties)
                    //.FirstOrDefault(x => true);
                    _objectMappingService.ProjectTo<Tenant, TenantDto>(
                            _coreRepositoryService.GetQueryableSet<Tenant>()
                                .Where(x => x.IsDefault == true),
                            null,
                            x => x.Properties)
                        .FirstOrDefault(x => true);


                _azureRedisCacheService.Set(_key, result);
            }

            return result;
        }
    }
}