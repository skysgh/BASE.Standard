// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Services;

namespace App.Modules.All.Shared.DependencyResolution.Lifecycles
{
    /// <summary>
    ///     A non-functional interface to hint
    ///     as to the default IoC lifespan of the implementor.
    ///     <para>
    ///         At startup the IoC Container (ie, StructureMap)
    ///         searches all assemblies for services, etc.
    ///         and uses <see cref="IHasLifecycle" /> to hint as to how
    ///         to register them.
    ///     </para>
    ///     <para>
    ///         Implemented by <see cref="IHasSingletonLifecycle" />,
    ///         which in turn is implemented by <see cref="ISystemService" />
    ///         etc.
    ///     </para>
    /// </summary>
    public interface IHasLifecycle
    {
    }
}