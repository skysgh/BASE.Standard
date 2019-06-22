// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IObjectMappingService : IInfrastructureService
    {
        TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new();
        TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class;

        IQueryable<TTarget> ProjectTo<TTarget>(IQueryable source,
            object parameters = null,
            params Expression<Func<TTarget, object>>[] expand)
            where TTarget : new();

        IQueryable<TTarget> ProjectTo<TSource, TTarget>(IQueryable<TSource> source,
            object parameters = null,
            params Expression<Func<TTarget, object>>[] expand)
            where TSource : class
            where TTarget : new();
    }
}