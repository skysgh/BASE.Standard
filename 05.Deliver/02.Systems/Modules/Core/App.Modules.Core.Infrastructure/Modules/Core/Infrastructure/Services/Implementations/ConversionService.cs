﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;

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
        public T ConvertTo<T>(object source, T defaultValue = default)
        {
            return source.ConvertTo(defaultValue);
        }


        public object GetDefaultValue(Type t)
        {
            return t.GetDefaultValue();
        }
    }
}