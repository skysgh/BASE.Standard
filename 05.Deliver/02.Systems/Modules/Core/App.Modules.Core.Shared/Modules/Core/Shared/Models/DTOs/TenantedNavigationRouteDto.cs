// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     A message/Dto defining
    ///     a default set of navigation routes.
    ///     <para>
    ///         Service clients are free to design their own
    ///         navigation routes.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class TenantedNavigationRouteDto : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ IHasGuidId
    {
        private ICollection<TenantedNavigationRouteDto> _children;

        /// <summary>
        ///     Gets or sets a value indicating whether this
        ///     <see cref="TenantedNavigationRouteDto" /> is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     FK of the owner record.
        /// </summary>
        public Guid OwnerFK { get; set; }

        /// <summary>
        ///     Gets or sets the navigation title.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a hint as to the order in which to display this order.
        ///     <para>
        ///         Note that natural orders can always be superseded by personal ordering (MRU, etc.)
        ///     </para>
        /// </summary>
        public int DisplayOrderHint { get; set; }

        /// <summary>
        ///     A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        public string DisplayStyleHint { get; set; }

        /// <summary>
        ///     Gets the collection of
        ///     child
        ///     <see cref="TenantedNavigationRouteDto" />
        ///     under this <see cref="TenantedNavigationRouteDto" />
        /// </summary>
        public ICollection<TenantedNavigationRouteDto> Children =>
            _children ?? (_children = new Collection<TenantedNavigationRouteDto>());

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}