using System;
using System.Linq;
using System.Security.Claims;
using App.Modules.Core.Infrastructure.Constants.IDA;

namespace App
{
    public static class ClaimsIdentityExtensions
    {
        public static string GetIdp(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.IdpIdentifierId)?.Value;
        }

        public static string GetSub(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.SubjectIdentifierId)?.Value;
        }

        public static string GetIat(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.IssuedAtId)?.Value;
        }

        public static DateTimeOffset GetIssuedAtTime(this ClaimsIdentity identity)
        {
            var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0,TimeSpan.Zero);

            return epoch.AddSeconds(Convert.ToUInt64(GetIat(identity)));
        }

        public static string GetExp(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.ExpiryId)?.Value;
        }

        public static DateTimeOffset GetExpiry(this ClaimsIdentity identity)
        {
            var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

            return epoch.AddSeconds(Convert.ToUInt64(GetExp(identity)));
        }

        public static TimeSpan GetDurationToLive(this ClaimsIdentity identity)
        {
            return GetExpiry(identity) - GetIssuedAtTime(identity);
        }


        public static string GetSessionUniqueIdentifier(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == ClaimTitles.UniqueSessionIdentifier)?.Value;
        }
    }
}
