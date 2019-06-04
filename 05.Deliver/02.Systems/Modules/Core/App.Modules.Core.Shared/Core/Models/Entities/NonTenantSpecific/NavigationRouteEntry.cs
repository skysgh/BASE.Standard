using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Models.Entities
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
    public class NavigationRoute : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
    {
        // Class Not even used not sure what this was supposed to be
        public Guid OwnerFK
        {
            get; set;
        }

        public bool Enabled
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public int DisplayOrderHint
        {
            get; set;
        }
        public string DisplayStyleHint
        {
            get; set;
        }

        public ICollection<NavigationRoute> Chilldren
        {
            get
            {
                return this._children ?? (this._children = new Collection<NavigationRoute>());
            }
        }

        private ICollection<NavigationRoute> _children;


        public Guid GetOwnerFk()
        {
            throw new NotImplementedException();
        }
    }
}