// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.DTOs
{


    /// <summary>
    ///     Gets or sets the child Tag associated to a parent
    ///     <see cref="PrincipalDto" />.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class PrincipalTagDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId, IHasEnabled,
            IHasDescription
    {
        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        public virtual string Text { get; set; }

        /// <summary>
        ///     Gets or sets the display order hint.
        /// </summary>
        /// <value>
        ///     The display order hint.
        /// </value>
        public virtual int DisplayOrderHint { get; set; }

        /// <summary>
        ///     Gets or sets the display style hint.
        /// </summary>
        /// <value>
        ///     The display style hint.
        /// </value>
        public virtual string DisplayStyleHint { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="PrincipalTagDto" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
    }
}