// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Linq;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ITenantService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ITenantService" />
    public class TenantService : AppCoreServiceBase, ITenantService
    {
        private static readonly string _currentRequestCacheKey = "_CurrentTenantKey";
        private static readonly string _ResourceListCacheKey = "_TenantCache";

        private static string _defaultTenantString;

        //private readonly ICacheItemService _cacheItemService;
        //private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly IOperationContextService _operationContextService;
        private readonly IPrincipalService _principalService;

        //private readonly IAppHostNamesService _hostNamesService;
        private Guid _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantService"/> class.
        /// </summary>
        /// <param name="operationContextService">The operation context service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="repositoryService">The repository service.</param>
        public TenantService(
            IOperationContextService operationContextService,
            IPrincipalService principalService,
            IObjectMappingService objectMappingService,
            //IAzureRedisCacheService azureRedisCacheService, 
            ModuleDbContext repositoryService
            //,
            //IAppHostNamesService appHostNamesService
        )
        {
            _operationContextService = operationContextService;
            _principalService = principalService;
            _objectMappingService = objectMappingService;

            //this._azureRedisCacheService = azureRedisCacheService;
            _coreRepositoryService = repositoryService;
            //this._hostNamesService = appHostNamesService;
            _id = Guid.NewGuid();
        }


        /// <summary>
        ///     The current Tenant (ie, the start of the Url)
        ///     <para>
        ///         Used to set the resource' appearance (skin header/logo/footer, etc.)
        ///     </para>
        /// </summary>
        public TenantDto CurrentTenant
        {
            get => _operationContextService.Get<TenantDto>(_currentRequestCacheKey);
            private set => _operationContextService.Set(_currentRequestCacheKey, value);
        }


        /// <summary>
        ///     <para>
        ///         Inovked by Middleware Module
        ///         (before Routing gets involved)
        ///     </para>
        /// </summary>
        /// <param name="tenantKeyOrPath"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public TenantDto SetTenantFromUrl(string tenantKeyOrPath, string hostName = null)
        {
            var result = GetTenantAndAddToCache(tenantKeyOrPath, hostName);

            CurrentTenant = result;
            return result;
        }


        /// <summary>
        ///     <para>
        ///         Can be invoked by Route Condition
        ///         to verify that first part of route is valid.
        ///         (note that when done from there,
        ///         this will be the same as what was resolved
        ///         within the Middleware, when it set the Tenancy).
        ///     </para>
        ///     <para>
        ///         If invoked from another location, will be slower.
        ///     </para>
        /// </summary>
        /// <param name="tenantKey"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public bool IsValidTenantKey(string tenantKey, string hostName = null)
        {
            // Since this is after the Middleware has parsed it, 
            // it's already in cache... so can use local cache.
            tenantKey = tenantKey.ToLowerInvariant();

            var result = GetTenant(tenantKey, hostName, false);

            return result != null;
        }


        ///// <summary>
        /////     The Key of the Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current
        /////     Principal)
        ///// </summary>
        //public string PrincipalTenantKey
        //{
        //    get => this._principalService.PrincipalTenantKey;
        //    set => this._principalService.PrincipalTenantKey = value;
        //}

        //public static string CurrentRequestCacheKey => _currentRequestCacheKey;


        private TenantDto GetDefaultTenant()
        {
            TenantDto result;
            if (!string.IsNullOrWhiteSpace(GetDefaultTenantKey()))
            {
                result = GetTenant(_defaultTenantString, false);
                if (result != null)
                {
                    return result;
                }
            }

            result =
                //this._coreRepositoryService
                //.GetQueryableSet<Tenant>()
                //.Where(x => (x.IsDefault == true))
                //.ProjectTo<TenantDto>((object)null, x => x.Properties)
                _objectMappingService
                    .ProjectTo<Tenant, TenantDto>(
                        _coreRepositoryService
                            .GetQueryableSet<Tenant>()
                            .Where(x => x.IsDefault == true)
                    )
                    .FirstOrDefault();

            if (result != null)
            {
                _defaultTenantString = result.Key;
                AddToCache(result);
            }

            return result;
        }

        public string GetDefaultTenantKey()
        {
            return _defaultTenantString;
        }

        public TenantDto GetTenant(string tenantKeyOrPath, string hostName = null, bool defaultIfNotFound = true)
        {
            var searchKey = ExtractTenantKey(hostName, tenantKeyOrPath);
            return GetTenant(searchKey, defaultIfNotFound);
        }


        private TenantDto GetTenant(string searchKey, bool defaultIfNotFound = true)
        {
            TenantDto result = null;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                result = SearchCacheForTenantByKey(searchKey);
            }

            if (defaultIfNotFound)
            {
                return GetDefaultTenant();
            }

            return result;
        }

        public TenantDto GetTenantAndAddToCache(string tenantKeyOrPath, string hostName)
        {
            var searchKey = ExtractTenantKey(hostName, tenantKeyOrPath);
            return GetTenantAndAddToCache(searchKey);
        }


        private TenantDto GetTenantAndAddToCache(string searchKey)
        {
            var result = GetTenant(searchKey, false);
            if (result != null)
            {
                return result;
            }

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                //result = this._coreRepositoryService
                //    .GetQueryableSet<Tenant>()
                //    .Where(x => (x.Key == searchKey))
                //    .ProjectTo<TenantDto>((object)null, x => x.Properties)
                //    .FirstOrDefault();

                result =
                    _objectMappingService
                        .ProjectTo<Tenant, TenantDto>(
                            _coreRepositoryService
                                .GetQueryableSet<Tenant>()
                                .Where(x => x.Key == searchKey),
                            null,
                            x => x.Properties
                        )
                        .FirstOrDefault();
            }

            if (result != null)
            {
                AddToCache(result);
            }
            else
            {
                result = GetDefaultTenant();
            }

            return result;
        }


        public string ExtractTenantKey(string hostName, string path)
        {
            var hostTenancy = GetHostNameTenant(hostName);
            if (string.IsNullOrWhiteSpace(hostTenancy))
            {
                hostTenancy = GetUrlTenant(path);
            }

            return hostTenancy;
        }

        public string GetHostNameTenant(string hostName)
        {
            throw new NotImplementedException();

            //if (string.IsNullOrWhiteSpace(hostName)){ return null; }

            //string[] defaultHostNames = _hostNamesService.GetAppHostNamesList();
            //if(defaultHostNames.Length == 0) { return null;}
            //hostName = CleanHostName(hostName);

            //foreach (var potentialTenant in defaultHostNames)
            //{
            //    var regexDefaultHostName = $"/^{potentialTenant.Replace("*", "(.*?)")}/";
            //    var match = Regex.Match(hostName, regexDefaultHostName);
            //    if (match.Success)
            //    {
            //        return match.Value.ToLower();
            //    }
            //}

            //return null;
        }

        public string GetUrlTenant(string path)
        {
            throw new NotImplementedException();
            //if (string.IsNullOrWhiteSpace(path)) { return null; }

            //if (path.StartsWith("/"))
            //{
            //    path = path.TrimStart('/');
            //}
            //string[] defaultHostNames = _hostNamesService.GetRoutesList();
            //path = path.ToLower().Split('/').First();
            //foreach (var check in defaultHostNames)
            //{
            //    if (path.Equals(check, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return null;
            //    }
            //}

            //return path;
        }

        public string CleanHostName(string hostName)
        {
            //remove port and www
            if (!string.IsNullOrEmpty(hostName))
            {
                hostName = hostName.ToLower().Split(':').First();
                if (hostName.StartsWith("www."))
                {
                    hostName = hostName.Substring(4, hostName.Length - 4);
                }
            }

            return hostName;
        }

        private TenantDto SearchCacheForTenantByKey(string searchKey)
        {
            throw new NotImplementedException();
            //if (string.IsNullOrWhiteSpace(searchKey))
            //{
            //    return null;
            //}
            ////First, search in Request Cache:
            //var list = GetContextCache();
            //TenantDto result = list.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.Key, searchKey) == 0) ;

            //if (result != null)
            //{
            //    return result;
            //}
            ////Otherwise look in shared cache:
            //string redisKey = GetRedisKey() + searchKey.ToLower();

            //result = _azureRedisCacheService.Get<TenantDto>(redisKey);

            //return result;
        }

        private void AddToCache(TenantDto tenant)
        {
            throw new NotImplementedException();
            //string redisKey = GetRedisKey() + tenant.Key.ToLower();
            //_azureRedisCacheService.Set(redisKey, tenant, TimeSpan.FromMinutes(5));
            //// Then in local request:
            //GetContextCache().Add(tenant);
        }

        private string GetRedisKey()
        {
            return _ResourceListCacheKey + ":" + "Key" + ":";
        }

        /// <summary>
        ///     Gets the list of cached Resources retrieved during this request:
        /// </summary>
        /// <returns></returns>
        private List<TenantDto> GetContextCache()
        {
            List<TenantDto> result = _operationContextService.Get<List<TenantDto>>(_ResourceListCacheKey);
            if (result == null)
            {
                result = new List<TenantDto>();
                _operationContextService.Set(_ResourceListCacheKey, result);
            }

            return result;
        }
    }
}