using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IObjectMappingService /// TODO: IHasAppCoreService
    {
        TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new();
        TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class;
    }

}