// Copyright MachineBrains, Inc. 2019

using System.Net.Http;
using System.Web;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Shared.Models.Messages;
using Newtonsoft.Json;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    /// An Implementation of the <see cref="GeoIPService"/>
    /// contract of a service to convert IP's to geographic
    /// information (city/country).
    /// <para>
    /// Used for UX purposes - as well as potentially
    /// excluding users from certain countries (although
    /// this type of security check is limited as it
    /// can be rendered in terms of security due to local
    /// VPNs)
    /// </para>
    /// </summary>
    /// <seealso cref="All.Infrastructure.Services.AppCoreServiceBase" />
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IGeoIPService" />
    public class GeoIPService : AppCoreServiceBase, IGeoIPService
    {
        private readonly GeoIPServiceConfiguration _geolocationServiceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoIPService"/> class.
        /// </summary>
        /// <param name="geolocationServiceConfiguration">The geolocation service configuration.</param>
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