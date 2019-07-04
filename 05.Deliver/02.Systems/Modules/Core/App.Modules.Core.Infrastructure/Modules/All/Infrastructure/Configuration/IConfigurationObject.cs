﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.DependencyResolution.Lifecycles;

namespace App.Modules.All.Infrastructure.Configuration
{
    /// <summary>
    ///     Contract to be applied to all *singleton* instances
    ///     of Configuration Objects
    ///     to Configure Services (eg: configure SMTPNotificationService, etc.)
    ///     or simply be hold single general
    ///     information (eg: SystemVendorInformation, etc.)
    ///     <para>
    ///         Dependency Injectors work primarily with objects(there are some esoteric exceptions, but generally
    ///         most DIs can inject objects into objects into objects -- all based on the Parameter Types of each
    ///         classes Constructor -- but get stumped when a constructor argument is a Value type (string, int, etc.)
    ///         not knowing where to find the needed string.
    ///     </para>
    ///     <para>
    ///         The common solution is to use Configuration Object that are easily discoverable by the
    ///         Dependency Injector. We pack them with the strings/ints needed, and the DI happily injects the whole
    ///         object/egg into the target service.Done.
    ///     </para>
    ///     <para>
    ///         It also solves other problems.The first being that OO always expected us to work with Objects, so the
    ///         code becomes more mature/maintainable (rather than loose bits/pieces flying in close formation),
    ///         and secondly, the ConfigurationObject in itself is injectable...so can be injected with other services
    ///         (eg: IHostSettingsService) to configure the strings/ints on its own, like a big boy...
    ///     </para>
    ///     <para>
    ///         Inherits from <see cref="IHasSingletonLifecycle" />
    ///         to hint at startup that the Configuration object should be
    ///         IoC registered for the duration of the application (not the thread).
    ///         as some configuration hits remote services (eg: Azure KeyVault)
    ///         which would be rather slow.
    ///     </para>
    /// </summary>
    /// <seealso cref="IHasSingletonLifecycle" />
    public interface IConfigurationObject : IHasSingletonLifecycle
    {
    }
}