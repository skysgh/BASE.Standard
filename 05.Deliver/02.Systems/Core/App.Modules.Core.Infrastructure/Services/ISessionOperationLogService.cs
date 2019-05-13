﻿namespace App.Modules.Core.Infrastructure.Services
{
    using System.Collections.Generic;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Contracts.Services;

    /// <summary>
    ///  Contract for an Infrastructure Service to
    /// record the current <see cref="SessionOperation"/>
    /// log that will be Committed at the end of the 
    /// Request (delayed so that it can record the Response Code).
    /// </summary>
    /// <seealso cref="IAppModuleCoreService" />
    public interface ISessionOperationLogService : IAppModuleCoreService
    {
        /// <summary>
        ///     Return the current Request Context's OperationLog record.
        ///     <para>
        ///         Creates a new one if this is the first request for the OperationLog.
        ///     </para>
        /// </summary>
        SessionOperation Current { get; }

        Dictionary<string,object> CurrentDetails { get; }

        object GetDetail(string key);
        void SetDetail(string key,object value);

        void IncrementDetail(string key);

    }
}