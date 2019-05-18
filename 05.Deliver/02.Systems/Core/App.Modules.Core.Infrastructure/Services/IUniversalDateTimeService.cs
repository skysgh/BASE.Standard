﻿namespace App.Modules.Core.Infrastructure.Services
{
    using System;

    /// <summary>
    /// Contract for an infrastructure service to
    /// return UTC based DateTimeOffset (not just UTC DateTime, 
    /// and certainly not Local DateTime!)
    /// to all services that need to coordinate datetime in a
    /// geo-capable manner (which you certainly need to do when
    /// you are hosting some infrastructure in one timezone, 
    /// and other pieces in another).
    /// </summary>
    /// <seealso cref="IModuleSpecificService" />
    public interface IUniversalDateTimeService : IModuleSpecificService
    {
        /// <summary>
        /// Return the DateTime, in UTC.
        /// </summary>
        DateTimeOffset NowUtc();
    }
}