﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Attributes;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper.QueryableExtensions;

namespace App.Modules.Core.Infrastructure.Cache
{


    /// <summary>
    /// Notice the Key. This is how it gets registered automatically.
    /// </summary>
    [Key(Constants.Cache.StaticKeys.DefaultTenant)]
    public class DefaultTenancyCacheItem : CacheItemBase, IAppCoreCacheItem
    {
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly IRepositoryService _repositoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="azureRedisCacheService"></param>
        public DefaultTenancyCacheItem(IAzureRedisCacheService azureRedisCacheService, IRepositoryService repositoryService)
        {
            _azureRedisCacheService = azureRedisCacheService;

            this._repositoryService = repositoryService;

            this._duration = TimeSpan.FromMinutes(1);
        }

        public override object Get()
        {
            TenantDto result = _azureRedisCacheService.Get<TenantDto>(_key);

            if (result.IsDefaultOrNotInitialized())
            {
                result = _repositoryService
                    .GetQueryableSet<Tenant>(Constants.Db.CoreModuleDbContextNames.Core)
                    .Where(x => x.IsDefault == true)
                    .ProjectTo<TenantDto>((object)null, x => x.Properties)
                    .FirstOrDefault(x => true);

                _azureRedisCacheService.Set(_key, result);
            }

            return result;
        }
    }
}
