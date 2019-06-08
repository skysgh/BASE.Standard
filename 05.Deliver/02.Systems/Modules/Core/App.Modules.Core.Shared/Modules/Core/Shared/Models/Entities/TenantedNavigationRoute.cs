using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A single element within a Navigation Map used by user interfaces.
    /// <see cref="NavigationRoute"/>.
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="IHasGuidId" />
    /// <seealso cref="IHasText" />
    /// <seealso cref="IHasDescription" />
    /// <seealso cref="IHasDisplayOrderHint" />
    /// <seealso cref="IHasDisplayStyleHint" />
    public class TenantedNavigationRoute : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
    {

        public bool Enabled {get; set;}
        // Class Not even used not sure what this was supposed to be
        public Guid OwnerFK { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int DisplayOrderHint { get; set; }
        public string DisplayStyleHint { get; set; }

        public ICollection<TenantedNavigationRoute> Chilldren {
            get
            {
                return _children ?? (_children = new Collection<TenantedNavigationRoute>());
            }
        }

        private ICollection<TenantedNavigationRoute> _children;

        public Guid GetOwnerFk()
        {
            return OwnerFK;
        }
    }
}
