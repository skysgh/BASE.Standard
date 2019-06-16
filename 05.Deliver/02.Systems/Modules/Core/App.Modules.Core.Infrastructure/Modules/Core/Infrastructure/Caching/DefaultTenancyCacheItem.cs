﻿using System;
using System.Linq;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;

using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper.QueryableExtensions;

namespace App.Modules.Core.Infrastructure.Caching
{


    /// <summary>
    /// Notice the Key. This is how it gets registered automatically.
    /// </summary>
    [Key(Constants.Cache.StaticKeys.DefaultTenant)]
    public class DefaultTenancyCacheItem : CacheItemBase, IAppCoreCacheItem
    {
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly ModuleDbContext _coreRepositoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="azureRedisCacheService"></param>
        public DefaultTenancyCacheItem(
            IAzureRedisCacheService azureRedisCacheService,
            IObjectMappingService objectMappingService,
            ModuleDbContext repositoryService
            )
        {
            _azureRedisCacheService = azureRedisCacheService;
            this._objectMappingService = objectMappingService;
            this._coreRepositoryService = repositoryService;

            this._duration = TimeSpan.FromMinutes(1);
        }

        public override object Get()
        {
            TenantDto result = _azureRedisCacheService.Get<TenantDto>(_key);

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
                        (object)null,
                        x => x.Properties)
                    .FirstOrDefault(x => true);


                _azureRedisCacheService.Set(_key, result);
            }

            return result;
        }
    }
}
