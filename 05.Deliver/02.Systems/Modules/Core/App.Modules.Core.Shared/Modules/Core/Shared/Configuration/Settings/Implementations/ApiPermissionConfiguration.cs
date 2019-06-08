﻿using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    public class ApiPermissionConfiguration
    {
        private string _serviceIdentifier;

        /// <summary>
        ///     The Service Identifier is the uri that was developed when the Service (not the Client)
        ///     was registered.
        ///     <para>
        ///         Used by both the API Provider, in its Setup phase, and the Consumer when it is about to make a remote API
        ///         call.
        ///     </para>
        ///     <para>eg: https://myb2c.onmicrosoft.com/example_webapi </para>
        ///     <para>
        ///         Note: When registering the Service as an App in the B2C, the Url should have been registered
        ///         with a final slash as it will be prefixed to Scopes (eg:'example.read' would become
        ///         `https://myb2c.onmicrosoft.com/example_webapi/exampe.read`) to disambiguate
        ///         across services with the same scope name.
        ///     </para>
        /// </summary>
        [Alias(ModuleSpecificApiScopes.ServiceUrl)]
        public string ServiceIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this._serviceIdentifier) && !this._serviceIdentifier.EndsWith("/"))
                {
                    //Ensure it ends with a slash, so that it can be easily 
                    // joined up with Scope.
                    this._serviceIdentifier += "/";
                }
                return this._serviceIdentifier;
            }
            set => this._serviceIdentifier = value;
        }
    }
}
