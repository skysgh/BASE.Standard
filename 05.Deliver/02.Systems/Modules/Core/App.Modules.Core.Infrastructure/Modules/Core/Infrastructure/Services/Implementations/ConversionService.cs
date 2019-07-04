// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IConversionService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IConversionService" />
    public class ConversionService : AppCoreServiceBase, IConversionService
    {
        /// <summary>
        /// Convert one type to another, falling back to the
        /// provided default Type if the value is null.
        /// </summary>
        /// <typeparam name="T">The target Type</typeparam>
        /// <param name="source">The source object</param>
        /// <param name="defaultValue">The default target value</param>
        /// <returns></returns>
        public T ConvertTo<T>(object source, T defaultValue = default)
        {
            return source.ConvertTo(defaultValue);
        }


        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public object GetDefaultValue(Type t)
        {
            return t.GetDefaultValue();
        }
    }
}