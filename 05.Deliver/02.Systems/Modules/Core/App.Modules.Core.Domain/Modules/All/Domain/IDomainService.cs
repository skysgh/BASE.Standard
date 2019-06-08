﻿using App.Modules.All.Shared.Services;

namespace App.Modules.All.Domain
{
    /// <summary>
    /// Contract that all Domain Services
    /// should inherit from.
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from
    /// <see cref="App.Modules.All.Shared.DependencyResolution.Lifecycles.IHasSingletonLifecycle"/>)
    /// and allowing for filtering per Core/Module.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Services.ISystemService" />
    public interface IDomainService : ISystemService
    {
    }
}