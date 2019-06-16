using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// An untenanted (ie, Universal/App) Navigation route entry.
    /// <see cref="TenantedNavigationRoute"/>
    /// </summary>
    /// <seealso cref="UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="IHasGuidId" />
    /// <seealso cref="IHasOwnerFK" />
    /// <seealso cref="IHasText" />
    /// <seealso cref="IHasDescription" />
    /// <seealso cref="IHasDisplayOrderHint" />
    /// <seealso cref="IHasDisplayStyleHint" />
    public class NavigationRoute : 
        UntenantedRecordStatedTimestampedGuidIdEntityBase, 
        IHasGuidId, 
        IHasEnabled,
        IHasOwnerFK, 
        IHasText, 
        IHasDescription, 
        IHasDisplayOrderHint, 
        IHasDisplayStyleHint
    {
        // Class Not even used not sure what this was supposed to be
        /// <summary>
        /// Gets or sets the owner fk.
        /// </summary>
        /// <value>
        /// The owner fk.
        /// </value>
        public Guid OwnerFK
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        public bool Enabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the displayed title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the optional displayed description.
        /// </summary>
        public string Description
        {
            get; set;
        }
        /// <summary>
        /// A convention based hint as to the natural order in which to display this list item
        /// (note that the natural order can be superseded/influenced by MRU information, etc.)
        /// </summary>
        public int DisplayOrderHint
        {
            get; set;
        }
        /// <summary>
        /// A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        public string DisplayStyleHint
        {
            get; set;
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public ICollection<NavigationRoute> Children
        {
            get
            {
                return this._children ?? (this._children = new Collection<NavigationRoute>());
            }
        }

        private ICollection<NavigationRoute> _children;


        /// <summary>
        /// Returns the FK of the
        /// parent, owning entity.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Guid GetOwnerFk()
        {
            throw new NotImplementedException();
        }
    }
}