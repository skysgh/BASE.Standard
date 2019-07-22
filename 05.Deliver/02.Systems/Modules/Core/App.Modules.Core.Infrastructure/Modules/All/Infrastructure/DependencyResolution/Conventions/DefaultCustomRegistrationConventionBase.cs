// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Exceptions;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{


    /// <summary>
    ///     A Custom Lamar initialization convention used
    ///     to register Databases under their name.
    /// </summary>
    public abstract class DefaultCustomRegistrationConventionBase<TInterface> : IRegistrationConvention
    {
        private readonly ServiceLifetime _lifetime;
        private readonly bool _useFactory;
        private readonly string[] _typeNameSuffixToStrip;
        private Type _contractType;

        protected DefaultCustomRegistrationConventionBase(ServiceLifetime lifetime, bool useFactory = false, params string[] typeNameSuffixToStrip)
        {
            _contractType = typeof(TInterface);
            this._lifetime = lifetime;
            this._useFactory = useFactory;
            this._typeNameSuffixToStrip = typeNameSuffixToStrip;
        }

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            // Only work on concrete types
            Type[] implementationTypes =
                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed).ToArray();

            var matchingTypes = implementationTypes.Where(
                x => _contractType.IsAssignableFrom(x));

            foreach (var implementationType in matchingTypes)
            {
                var tag =
                    implementationType.GetKeyOrNameFromType(
                        _typeNameSuffixToStrip);
                //services.For(_contractType).UseInstance(System.Activator.CreateInstance(implementationType)).Named(tag).Lifetime = _lifetime;



                if (_lifetime == ServiceLifetime.Singleton && _useFactory)
                {
                    object instance;
                    try
                    {
                        instance = Activator.CreateInstance(implementationType);
                    }
                    catch (SystemException e)
                    {
                        throw new ConfigurationException("Activator cannot create complex objects...", e);
                    }
                    services.AddSingleton(_contractType, x => instance);
                    services.AddSingleton(implementationType, x => instance);
                }
                else
                {
                    services.For(_contractType).Use(implementationType)
                        .Named(tag).Lifetime = _lifetime;

                    services.For(implementationType).Use(implementationType)
                        .Lifetime = _lifetime;
                }
            }
        }
    }
}