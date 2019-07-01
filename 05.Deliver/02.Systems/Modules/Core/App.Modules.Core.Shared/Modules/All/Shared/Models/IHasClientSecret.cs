using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.All.Shared.Models
{

    /// <summary>
    /// Contract for <c>IConfigurationObject</c>s
    /// that hold the secret/key to a remote 3rd party service.
    /// </summary>
    public interface IHasServiceClientSecret
    {
        /// <summary>
        /// Gets or sets the client secret/key
        /// used by this system to authenticate and authorise
        /// access to the remote service
        /// (ie, the secret key unique to
        /// the <see cref="IHasServiceClientIdentifier"/>.
        /// <para>
        /// Note the difference with
        /// <see cref="IHasKey"/> which is used to define
        /// which attribute of an object is used as the
        /// primary index key (and is not necessarily
        /// the same as it's <see cref="IHasName"/>)
        /// </para>
        /// </summary>
        string ClientSecret { get; set; }
    }
}
