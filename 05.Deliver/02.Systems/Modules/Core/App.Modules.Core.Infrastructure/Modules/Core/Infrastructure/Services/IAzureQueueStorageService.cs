// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base Contract for an Infrastructure Service to
    ///     to manage access to an Azure Queue Storage.
    ///     <para>
    ///         Azure Queue storage is a service for storing large numbers of messages.
    ///         Assessible via authenticated HTTPS calls.
    ///         A single queue message can be up to 64 KB in size, and a queue can contain millions of messages.
    ///     </para>
    /// </summary>
    public interface IAzureQueueStorageService : IRemoteServiceClientInfrastructureService, IAzureService
    {
    }
}