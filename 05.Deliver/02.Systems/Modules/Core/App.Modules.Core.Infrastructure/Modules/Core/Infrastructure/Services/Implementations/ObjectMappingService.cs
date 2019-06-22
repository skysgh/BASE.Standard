// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IObjectMappingService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IObjectMappingService" />
    public class ObjectMappingService : AppCoreServiceBase, IObjectMappingService
    {
        //private readonly ObjectMappingServiceConfiguration _objectMappingServiceConfiguration;
        private readonly IMapper _mapper;

        public ObjectMappingService(
            //ObjectMappingServiceConfiguration objectMappingServiceConfiguration, 
            IMapper mapper
        )
        {
            _mapper = mapper;
        }

        public TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new()
        {
            var target = _mapper.Map<TSource, TTarget>(source);
            return target;
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class
        {
            target = _mapper.Map(source, target);
            return target;
        }

        public IQueryable<TTarget> ProjectTo<TTarget>(IQueryable source,
            object parameters = null,
            params Expression<Func<TTarget, object>>[] expand)
            where TTarget : new()
        {
            return _mapper.ProjectTo(source, parameters, expand);
        }

        public IQueryable<TTarget> ProjectTo<TSource, TTarget>(IQueryable<TSource> source,
            object parameters = null,
            params Expression<Func<TTarget, object>>[] expand)
            where TSource : class
            where TTarget : new()
        {
            return _mapper.ProjectTo(source, parameters, expand);
        }
    }
}