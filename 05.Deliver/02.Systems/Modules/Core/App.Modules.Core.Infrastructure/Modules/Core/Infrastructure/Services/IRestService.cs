// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IRestService : IInfrastructureService
    {
        string Get(Uri uri, string bearerToken = null, params RestResponseHandler[] alternateResponseHandlers);

        T Get<T>(Uri uri, string bearerToken = null, params RestResponseHandler[] alternateResponseHandlers)
            where T : class;

        void Post(Uri uri, string body, string bearerToken = null,
            params RestResponseHandler[] alternateResponseHandlers);

        void Put(Uri uri, string body, string bearerToken = null,
            params RestResponseHandler[] alternateResponseHandlers);
    }
}