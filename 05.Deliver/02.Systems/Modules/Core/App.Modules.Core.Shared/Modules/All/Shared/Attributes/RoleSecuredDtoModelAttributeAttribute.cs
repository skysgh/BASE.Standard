// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Attributes
{
    /// <summary>
    ///     Attribute to attach a specific Role Key to a Controller Action.
    ///     <para>
    ///         TODO: Dumb. SHould be more fine grain and be a Permission.
    ///     </para>
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class RoleSecuredDtoModelAttributeAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RoleSecuredDtoModelAttributeAttribute" /> class.
        /// </summary>
        /// <param name="roles">The roles.</param>
        public RoleSecuredDtoModelAttributeAttribute(string roles)
        {
            Roles = roles;
        }

        /// <summary>
        ///     Gets or sets the roles
        ///     allowed to do this operation.
        /// </summary>
        /// <value>
        ///     The roles.
        /// </value>
        public string Roles { get; set; }
    }
}