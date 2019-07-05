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
    /// An Implementation of the <see cref="GeoLocationService"/>
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
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IGeoLocationService" />
    public class GeoLocationService : AppCoreServiceBase, IGeoLocationService
    {
        private readonly GeoLocationServiceConfiguration _geolocationServiceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocationService"/> class.
        /// </summary>
        /// <param name="geolocationServiceConfiguration">The geolocation service configuration.</param>
        public GeoLocationService(GeoLocationServiceConfiguration geolocationServiceConfiguration)
        {
            _geolocationServiceConfiguration = geolocationServiceConfiguration;
        }

        public GeoInformation Get(string ip)
        {
            using (var httpClient = new HttpClient())
            {
                var secret = _geolocationServiceConfiguration.ClientSecret ??
                             _geolocationServiceConfiguration.ClientIdentifier;

                var url = $"http://api.ipstack.com/{ip}?access_key={secret}";

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = httpClient.SendAsync(request).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<GeoInformation>(json);
                return obj;
            }
        }

    }
}