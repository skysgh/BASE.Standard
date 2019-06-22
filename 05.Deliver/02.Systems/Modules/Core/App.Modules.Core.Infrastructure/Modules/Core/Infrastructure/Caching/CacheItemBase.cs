// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Exceptions;
using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Infrastructure.Caching
{
    public abstract class CacheItemBase : IAppCoreCacheItem
    {
        protected TimeSpan _duration;
        protected string _key;


        protected CacheItemBase()
        {
            var attribute = GetType().GetCustomAttribute<KeyAttribute>(false);

            if (attribute == null)
            {
                throw new DevelopmentException($"No KeyAttribute was defined for {GetType()}");
            }

            _key = attribute.Key;

            _duration = TimeSpan.FromSeconds(30);
        }

        public string Key => _key;

        public abstract object Get();
    }
}