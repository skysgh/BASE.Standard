// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IPrincipalManagmentService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IPrincipalManagmentService" />
    public class PrincipalManagmentService : AppCoreServiceBase, IPrincipalManagmentService
    {
        private static readonly string _resourceListCacheKey = "_PrincipalManagmentCache";
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly IOperationContextService _operationContextService;

        public PrincipalManagmentService(ModuleDbContext repositoryService,
            IOperationContextService operationContextService,
            IAzureRedisCacheService azureRedisCacheService,
            IObjectMappingService objectMappingService)
        {
            _coreRepositoryService = repositoryService;
            _operationContextService = operationContextService;
            _azureRedisCacheService = azureRedisCacheService;
            _objectMappingService = objectMappingService;
        }

        public Principal Get(string idpPrincipalKey, string subPrincipalKey, string uniqueCacheId,
            TimeSpan? timespanToCache = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId))
            {
                return null;
            }

            //First, search in Request Cache:
            var result = GetFromLocalCache();
            if (result == null)
            {
                //Otherwise look in shared cache:
                result = GetFromDistributedCacheAndCacheLocally(uniqueCacheId);
            }

            if (result != null)
            {
                return MaptoEntity(result);
            }

            return GetFromRepositoryAndCache(idpPrincipalKey, subPrincipalKey, uniqueCacheId, timespanToCache);
        }

        /// <summary>
        /// </summary>
        public Principal CreateIfNotExists(string idpPrincipalKey, string subPrincipalKey, string name,
            string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var currentPrincipal = Get(idpPrincipalKey, subPrincipalKey, uniqueCacheId);
            if (currentPrincipal != null)
            {
                return currentPrincipal;
            }

            throw new NotImplementedException();

            //currentPrincipal = new Principal
            //{
            //    CategoryFK = CoreModuleDbContextSeederPrincipalCategory.GetDefaultPrincipalCategory().Id,
            //    FullName = name,
            //    Enabled = true,
            //    EnabledBeginningUtc = DateTimeOffset.UtcNow
            //};
            //var login = new PrincipalLogin()
            //{
            //    PrincipalFK = currentPrincipal.Id,
            //    CreatedByPrincipalId = currentPrincipal.Id.ToString(),
            //    LastModifiedByPrincipalId = currentPrincipal.Id.ToString(),
            //    LastLoggedInUtc = DateTimeOffset.UtcNow,
            //    IdPLogin = idpPrincipalKey,
            //    SubLogin = subPrincipalKey,
            //};
            //currentPrincipal.Logins.Add(login);
            //this._repositoryService.AddOnCommit(Constants.Db.CoreModuleDbContextNames.Core, currentPrincipal);
            //// Yep Want to save as quickly as possible. 
            //this._repositoryService.SaveChanges(Constants.Db.CoreModuleDbContextNames.Core);
            //AddToCache(uniqueCacheId, currentPrincipal, timespanToCache);
            //return currentPrincipal;
        }


        public Principal Get(Guid id)
        {
            var result = _coreRepositoryService.GetSingle<Principal>(x => x.Id == id);
            return result;
        }

        public Principal GetFromRepositoryAndCache(string idpPrincipalKey, string subPrincipalKey,
            string uniqueCacheId = null, TimeSpan? timespanToCache = null)
        {
            var result =
                _coreRepositoryService
                    .GetQueryableSingle<Principal>(
                        x => x.Logins.Any(y => y.IdPLogin == idpPrincipalKey && y.SubLogin == subPrincipalKey))
                    .Include(x => x.Claims)
                    .FirstOrDefault();
            AddToCache(uniqueCacheId, result, timespanToCache);
            return result;
        }

        public PrincipalDto GetFromLocalCache()
        {
            return _operationContextService.Get<PrincipalDto>(_resourceListCacheKey);
        }

        public PrincipalDto GetFromDistributedCacheAndCacheLocally(string uniqueCacheId)
        {
            var redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            var result = _azureRedisCacheService.Get<PrincipalDto>(redisKey);
            if (result != null)
            {
                AddToLocalCache(result);
            }

            return result;
        }


        public void AddToCache(string uniqueCacheId, Principal result, TimeSpan? timespan = null)
        {
            AddToCache(uniqueCacheId, MapToDto(result), timespan);
        }

        public void AddToCache(string uniqueCacheId, PrincipalDto result, TimeSpan? timespan = null)
        {
            AddToLocalCache(result);
            AddToDistributedCache(uniqueCacheId, result);
        }

        public void AddToLocalCache(PrincipalDto result)
        {
            if (result == null)
            {
                return;
            }

            _operationContextService.Set(_resourceListCacheKey, result);
        }

        public void AddToLocalCache(Principal result)
        {
            AddToLocalCache(MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, Principal result, TimeSpan? timespan = null)
        {
            AddToDistributedCache(uniqueCacheId, MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, PrincipalDto result, TimeSpan? timespan = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId) || result == null)
            {
                return;
            }

            var redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            _azureRedisCacheService.Set(redisKey, result, timespan ?? TimeSpan.FromMinutes(5));
        }

        protected PrincipalDto MapToDto(Principal principal)
        {
            return _objectMappingService.Map<Principal, PrincipalDto>(principal);
        }

        protected Principal MaptoEntity(PrincipalDto principal)
        {
            return _objectMappingService.Map<PrincipalDto, Principal>(principal);
        }

        protected string GetRedisKey()
        {
            return _resourceListCacheKey + ":" + "Key" + ":";
        }
    }
}