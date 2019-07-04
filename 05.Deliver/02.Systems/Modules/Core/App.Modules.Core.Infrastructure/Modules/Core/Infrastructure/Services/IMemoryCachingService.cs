﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base contract for an Infrastructure Service to
    ///     Cache information.
    ///     <para>
    ///         Only suitable for Immutable information.
    ///         Consider Redis Cache Service for Muttable information
    ///         shared between devices.
    ///     </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IMemoryCachingService : IInfrastructureService
    {
        /// <summary>
        /// Gets the specified Typed item (refreshed if it has expired).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Registers a function to retrieve values when requested.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="expiredCallback">The expired callback.</param>
        void Register<T>(string key, TimeSpan duration, Func<T> expiredCallback);
    }
}