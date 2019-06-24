// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using LamarCodeGeneration.Util;
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

        protected DefaultCustomRegistrationConventionBase(ServiceLifetime lifetime, bool useFactory=false, params string[] typeNameSuffixToStrip)
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

            foreach (var implementationType in implementationTypes.Where(x => _contractType.IsAssignableFrom(x)
            ))
            {
                var tag = GetName(implementationType);
                //services.For(_contractType).UseInstance(System.Activator.CreateInstance(implementationType)).Named(tag).Lifetime = _lifetime;



                if (_lifetime == ServiceLifetime.Singleton && _useFactory)
                {
                    var instance = Activator.CreateInstance(implementationType);
                    services.AddSingleton( _contractType, x => instance);
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

            ;
        }

        private string GetName(Type type)
        {
            // Register against all the interfaces implemented
            // by this concrete class
            var name = type.GetAliasKeyIfAny();

            if (name != null)
            {
                return name;
            }

            name = type.Name;

            foreach (string tmp in _typeNameSuffixToStrip)
            {
                if (name.Contains(tmp))
                {
                    return name.Substring(0, name.IndexOf(tmp));
                }
            }
            return name;
        }
    }
}