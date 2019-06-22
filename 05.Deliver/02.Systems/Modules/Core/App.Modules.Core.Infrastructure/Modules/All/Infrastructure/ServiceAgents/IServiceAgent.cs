// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.DependencyResolution.Lifecycles;

namespace App.Modules.All.Infrastructure.ServiceAgents
{
    public interface IContextScopedServiceAgent : IHasContextScopedLifecycle
    {
    }
}