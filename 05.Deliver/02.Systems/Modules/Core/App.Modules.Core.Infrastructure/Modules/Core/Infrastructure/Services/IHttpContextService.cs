// Copyright MachineBrains, Inc. 2019

using Microsoft.AspNetCore.Http;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a Service to get hold of the
    ///     HttpContext.
    ///     <para>
    ///         Warning: do not access/use this service directly (use it through IOperationContextService, etc.)
    ///     </para>
    ///     <para>
    ///         Warning for relying too heavily on it as it is not available
    ///         when running outside of a web server.
    ///     </para>
    /// </summary>
    public interface IHttpContextService
    {
        HttpContext Current { get; }
    }
}