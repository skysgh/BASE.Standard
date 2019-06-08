using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using AutoMapper;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IObjectMappingService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IObjectMappingService" />
    public class ObjectMappingService : AppCoreServiceBase, IObjectMappingService
    {
        private readonly ObjectMappingServiceConfiguration _objectMappingServiceConfiguration;

        public ObjectMappingService(ObjectMappingServiceConfiguration objectMappingServiceConfiguration){
            _objectMappingServiceConfiguration = objectMappingServiceConfiguration;
        }
        public TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new()
        {
            var target = Mapper.Map<TSource, TTarget>(source);
            return target;
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class
        {
            target = Mapper.Map(source, target);
            return target;
        }
    }
}