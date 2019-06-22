// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base class for <see cref="IMutableSettingsService" />
    /// </summary>
    public interface IImmutableSetingsService : IInfrastructureService
    {
        /// <summary>
        ///     Return a single Host Setting, typed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T Get<T>(string key, T defaultValue);
    }
}