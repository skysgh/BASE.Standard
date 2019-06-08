using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IObjectMappingService : IInfrastructureService
    {
        TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : new();
        TTarget Map<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class;
    }
}