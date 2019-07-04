// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISessionService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISessionService" />
    public class SessionService : AppCoreServiceBase, ISessionService
    {
        //private static readonly string _currentRequestCacheKey = "_CurrentSessionKey";
        private static readonly string _resourceListCacheKey = "_SessionCache";
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly IOperationContextService _operationContextService;

        public SessionService(ModuleDbContext repositoryService,
            IOperationContextService operationContextService,
            IAzureRedisCacheService azureRedisCacheService,
            IObjectMappingService objectMappingService)
        {
            _coreRepositoryService = repositoryService;
            _operationContextService = operationContextService;
            _azureRedisCacheService = azureRedisCacheService;
            _objectMappingService = objectMappingService;
        }

        public Session Get(string uniqueCacheId, TimeSpan? timespanToCache = null)
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

            return GetFromRepositoryAndCache(uniqueCacheId, timespanToCache);
        }

        public Session CreateAndSave(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var session = Create(principal, uniqueCacheId, timespanToCache);
            _coreRepositoryService.SaveChanges();
            return session;
        }

        public Session Create(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var session = new Session
            {
                PrincipalFK = principal.Id,
                UniqueIdentifier = uniqueCacheId
            };

            _coreRepositoryService.AddOnCommit(session);
            AddToCache(uniqueCacheId, session, timespanToCache);

            return session;
        }

        public SessionDto GetFromLocalCache()
        {
            return _operationContextService.Get<SessionDto>(_resourceListCacheKey);
        }

        public SessionDto GetFromDistributedCacheAndCacheLocally(string uniqueCacheId)
        {
            var redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            var result = _azureRedisCacheService.Get<SessionDto>(redisKey);
            if (result != null)
            {
                AddToLocalCache(result);
            }

            return result;
        }

        public Session GetFromRepositoryAndCache(string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var session = _coreRepositoryService.GetQueryableSingle<Session>(
                    x => x.UniqueIdentifier == uniqueCacheId)
                .Include(x => x.Principal)
                .FirstOrDefault();

            AddToCache(uniqueCacheId, session, timespanToCache);
            return session;
        }

        public void AddToCache(string uniqueCacheId, Session result, TimeSpan? timespan = null)
        {
            AddToCache(uniqueCacheId, MapToDto(result), timespan);
        }

        public void AddToCache(string uniqueCacheId, SessionDto result, TimeSpan? timespan = null)
        {
            AddToLocalCache(result);
            AddToDistributedCache(uniqueCacheId, result);
        }

        public void AddToLocalCache(SessionDto result)
        {
            if (result == null)
            {
                return;
            }

            _operationContextService.Set(_resourceListCacheKey, result);
        }

        public void AddToLocalCache(Session result)
        {
            AddToLocalCache(MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, Session result, TimeSpan? timespan = null)
        {
            AddToDistributedCache(uniqueCacheId, MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, SessionDto result, TimeSpan? timespan = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId) || result == null)
            {
                return;
            }

            var redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            _azureRedisCacheService.Set(redisKey, result, timespan ?? TimeSpan.FromMinutes(5));
        }

        protected SessionDto MapToDto(Session session)
        {
            return _objectMappingService.Map<Session, SessionDto>(session);
        }

        protected Session MaptoEntity(SessionDto session)
        {
            return _objectMappingService.Map<SessionDto, Session>(session);
        }

        protected string GetRedisKey()
        {
            return _resourceListCacheKey + ":" + "Key" + ":";
        }
    }
}