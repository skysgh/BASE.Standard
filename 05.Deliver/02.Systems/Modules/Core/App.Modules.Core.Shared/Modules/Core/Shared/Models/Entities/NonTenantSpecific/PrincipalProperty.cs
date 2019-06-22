// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Property of a Principal
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasValue{String}" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasPrincipalFK" />
    public class PrincipalProperty
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasOwnerFK,
            IHasKey,
            IHasValue<string>,
            IHasPrincipalFK
    {
        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        public virtual string Key { get; set; }


        /// <summary>
        ///     Returns the FK of the
        ///     parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return PrincipalFK;
        }

        /// <summary>
        ///     Gets or sets the FK of the Principal.
        ///     <para>
        ///         Note that as as the property name
        ///         ends with FK (and not Id)
        ///         it is Db enforced, and not just a weak
        ///         reference.
        ///     </para>
        /// </summary>
        public virtual Guid PrincipalFK { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }
    }
}