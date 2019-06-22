// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service to store files
    ///     on the host.
    ///     THIS IS ONLY VALID FOR LOCAL DEBUGGING AS CLOUD SERVICES
    ///     DO NOT GUARANTEE THAT THE APP IS RESTARTED ON THE SAME
    ///     SERVER (both a source of bug and security issues)
    /// </summary>
    public interface ITransientLocalFileStorageService : IInfrastructureService
    {
        /// <summary>
        ///     Persists the specified byte array
        ///     to the given filename.
        ///     <para>
        ///         Note that when cloud hosted, on PaaS,
        ///         the file location is transient, and will
        ///         no longer be available upon a restart (one
        ///         can end up being restarted on a different
        ///         device...). So avoid. And if so, use only
        ///         for short term diagnostics, at best.
        ///     </para>
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="fileName">Name of the file.</param>
        void Persist(byte[] bytes, string fileName);
    }
}