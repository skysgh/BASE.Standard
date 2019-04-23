﻿namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections;
    using System.Reflection;
    using App.Modules.Core.Shared.Attributes;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISecureAPIMessageAttributeService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ISecureAPIMessageAttributeService" />
    public class SecureAPIMessageAttributeService : AppCoreServiceBase, ISecureAPIMessageAttributeService
    {
        private readonly IConversionService _conversionService;
        private readonly IPrincipalService _principalService;

        public SecureAPIMessageAttributeService(IConversionService conversionService,
            IPrincipalService principalService)
        {
            this._conversionService = conversionService;
            this._principalService = principalService;
        }

        public void Process(IEnumerable models)
        {
            foreach (var m in models)
            {
                Process(m);
            }
        }

        public bool NeedsProcessing(Type type)
        {
            foreach (var pi in type.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attribute = pi.GetCustomAttribute<RoleSecuredDtoModelAttributeAttribute>(true);
                if (attribute == null)
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(attribute.Roles)
                    &&
                    this._principalService.IsInRole(attribute.Roles.Split(new[] { ',', ';', ':' },
                        StringSplitOptions.RemoveEmptyEntries)))
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        public void Process(object model)
        {
            if (model == null)
            {
                return;
            }
            foreach (var pi in model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attribute = pi.GetCustomAttribute<RoleSecuredDtoModelAttributeAttribute>(true);
                if (attribute == null)
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(attribute.Roles)
                    &&
                    this._principalService.IsInRole(attribute.Roles.Split(new[] {',', ';', ':'},
                        StringSplitOptions.RemoveEmptyEntries)))
                {
                    continue;
                }
                //Clear Out Properties:
                var defaultValue = pi.PropertyType.GetDefaultValue();
                pi.SetValue(model, defaultValue, null);
            }
        }
    }
}