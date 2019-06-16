using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO for <see cref="NavigationRoute"/> entities.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class NavigationRouteDto 
        : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  
            IHasGuidId,
            IHasDescription
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id {
            get; set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NavigationRouteDto"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled
        {
            get; set;
        }


        /// <summary>
        /// TODO: Gets or sets the owner fk.
        /// </summary>
        /// <value>
        /// The owner fk.
        /// </value>
        public Guid OwnerFK
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
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
        /// Gets or sets the display order hint.
        /// </summary>
        /// <value>
        /// The display order hint.
        /// </value>
        public int DisplayOrderHint
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the display style hint.
        /// </summary>
        /// <value>
        /// The display style hint.
        /// </value>
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
        public ICollection<NavigationRouteDto> Children
        {
            get
            {
                return this._children ?? (this._children = new Collection<NavigationRouteDto>());
            }
        }

        private ICollection<NavigationRouteDto> _children;
    }
}
