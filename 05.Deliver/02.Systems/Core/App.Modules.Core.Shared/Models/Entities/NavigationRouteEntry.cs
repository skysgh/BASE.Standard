namespace App.Modules.Core.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// An untenanted (ie, Universal/App) Navigation route entry.
    /// <see cref="TenantedNavigationRoute"/>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Entities.UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasText" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasDescription" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasDisplayOrderHint" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasDisplayStyleHint" />
    public class NavigationRoute : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasGuidId, IHasOwnerFK, IHasText, IHasDescription, IHasDisplayOrderHint, IHasDisplayStyleHint
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