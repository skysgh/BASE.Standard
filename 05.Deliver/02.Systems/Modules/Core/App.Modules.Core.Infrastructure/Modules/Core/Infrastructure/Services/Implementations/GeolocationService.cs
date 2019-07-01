// Copyright MachineBrains, Inc. 2019

using System.Net.Http;
using System.Web;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Messages;
using Newtonsoft.Json;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class GeoIPService : AppCoreServiceBase, IGeoIPService
    {
        private readonly GeoIPServiceConfiguration _geolocationServiceConfiguration;

        public GeoIPService(GeoIPServiceConfiguration geolocationServiceConfiguration)
        {
            _geolocationServiceConfiguration = geolocationServiceConfiguration;
        }

        public GeoInformation Get(string ip)
        {
            using (var httpClient = new HttpClient())
            {
                var url = _geolocationServiceConfiguration.BaseUri + CreateQueryString(ip);

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = httpClient.SendAsync(request).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<GeoInformation>(json);
                return obj;
            }
        }

        public string CreateQueryString(string ip)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["subscription-key"] = _geolocationServiceConfiguration.ClientIdentifier;
            query["api-version"] = "1.0";
            query["ip"] = ip;
            return "?" + query;
        }
    }
}