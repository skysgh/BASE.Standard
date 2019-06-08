﻿using System;
using App.Modules.All.Infrastructure.Exceptions;
using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Infrastructure.Caching
{
    public abstract class CacheItemBase : IAppCoreCacheItem
    {
        public string Key { get { return _key; } }
        protected string _key;

        protected TimeSpan _duration;




        protected CacheItemBase()
        {
            KeyAttribute attribute = this.GetType().GetCustomAttribute<KeyAttribute>(false);

            if (attribute == null)
            {
                throw new DevelopmentException($"No KeyAttribute was defined for {this.GetType()}");
            }

            _key = attribute.Key;

            _duration = TimeSpan.FromSeconds(30);
        }

        public abstract object Get();

    }
}
