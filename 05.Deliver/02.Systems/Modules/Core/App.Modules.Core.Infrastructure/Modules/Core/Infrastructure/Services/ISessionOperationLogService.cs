// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     record the current <see cref="SessionOperation" />
    ///     log that will be Committed at the end of the
    ///     Request (delayed so that it can record the Response Code).
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface ISessionOperationLogService : IInfrastructureService
    {
        /// <summary>
        ///     Return the current Request Context's OperationLog record.
        ///     <para>
        ///         Creates a new one if this is the first request for the OperationLog.
        ///     </para>
        /// </summary>
        SessionOperation Current { get; }

        Dictionary<string, object> CurrentDetails { get; }

        object GetDetail(string key);
        void SetDetail(string key, object value);

        void IncrementDetail(string key);
    }
}