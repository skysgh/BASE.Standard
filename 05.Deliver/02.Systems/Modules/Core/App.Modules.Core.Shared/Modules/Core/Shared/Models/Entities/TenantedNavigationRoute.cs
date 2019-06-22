// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A single element within a Navigation Map used by user interfaces.
    ///     <see cref="NavigationRoute" />.
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="IHasGuidId" />
    /// <seealso cref="IHasText" />
    /// <seealso cref="IHasDescription" />
    /// <seealso cref="IHasDisplayOrderHint" />
    /// <seealso cref="IHasDisplayStyleHint" />
    public class TenantedNavigationRoute
        : TenantFKRecordStatedTimestampedGuidIdEntityBase,
            IHasGuidId,
            IHasOwnerFK,
            IHasText,
            IHasDescription,
            IHasDisplayOrderHint,
            IHasDisplayStyleHint
    {
        private ICollection<TenantedNavigationRoute> _children;

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TenantedNavigationRoute" /> is enabled.
        /// </summary>
        public bool Enabled { get; set; }


        /// <summary>
        ///     Gets or sets the owner fk.
        ///     TODO: Not even used not sure what this was supposed to be
        /// </summary>
        public Guid OwnerFK { get; set; }

        /// <summary>
        ///     Gets the collection of child
        ///     <see cref="TenantedNavigationRoute" />.
        /// </summary>
        public ICollection<TenantedNavigationRoute> Children =>
            _children ?? (_children = new Collection<TenantedNavigationRoute>());

        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     A convention based hint as to the natural order in which to display this list item
        ///     (note that the natural order can be superseded/influenced by MRU information, etc.)
        /// </summary>
        public int DisplayOrderHint { get; set; }

        /// <summary>
        ///     A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        public string DisplayStyleHint { get; set; }

        /// <summary>
        ///     Returns the FK of the
        ///     parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return OwnerFK;
        }

        /// <summary>
        ///     Gets or sets the displayed title.
        /// </summary>
        public string Title { get; set; }
    }
}