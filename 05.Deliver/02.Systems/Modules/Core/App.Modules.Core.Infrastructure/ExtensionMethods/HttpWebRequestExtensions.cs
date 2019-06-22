// Copyright MachineBrains, Inc. 2019

using System.Net;

namespace App
{
    public static class HttpWebRequestExtensions
    {
        public static void AttachBearerToken(this HttpWebRequest httpWebRequest, string bearerToken)
        {
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + bearerToken);
        }
    }
}