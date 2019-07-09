// Copyright MachineBrains, Inc. 2019

using System.Net.Http;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Models;
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
    public class GeoLocationService : AppCoreServiceBase, IGeoLocationService,
        IHasPing
    {
        private readonly GeoLocationServiceConfiguration _configuration;
        private readonly IConfigurationStatusService _configurationStatusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocationService" /> class.
        /// </summary>
        /// <param name="configuration">The geolocation service configuration.</param>
        /// <param name="configurationStatusService">The configuration status service.</param>
        public GeoLocationService(
            GeoLocationServiceConfiguration configuration,
            IConfigurationStatusService configurationStatusService
            )
        {
            _configuration = configuration;
            this._configurationStatusService = configurationStatusService;
        }

        public GeoInformation Get(string ip)
        {
            if (!_configuration.Enabled)
            {
                var result =
                    new GeoInformation();

                result.IP = ip;
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // It should be in the secret, but it's a bit unclear...
                    var secret = _configuration.ClientSecret ??
                                 _configuration.ClientIdentifier;

                    var url =
                        $"http://api.ipstack.com/{ip}?access_key={secret}";

                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    var response = httpClient.SendAsync(request).Result;
                    var json = response.Content.ReadAsStringAsync().Result;
                    var obj =
                        JsonConvert.DeserializeObject<GeoInformation>(json);

                    _configurationStatusService.SetStatusToVerified<IGeoLocationService>();
                    return obj;
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Verify connectivity to remote service.
        /// </summary>
        /// <returns></returns>
        public bool Ping()
        {
            if (!_configuration.Enabled)
            {
                return false;
            }

            try
            {
                var result =
                    Get("1.1.1.1");

                if (result.IP == "1.1.1.1")
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

    }
}