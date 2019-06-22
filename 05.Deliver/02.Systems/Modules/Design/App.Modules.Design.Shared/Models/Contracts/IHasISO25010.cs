// Copyright MachineBrains, Inc. 2019

using App.Modules.Design.Shared.Models.Entities;

namespace App.Modules.Design.Shared.Models
{
    /// <summary>
    ///     Contract for models that have
    ///     an attribute describing a relationship
    ///     to ISO25010. All Requirements should have it.
    /// </summary>
    public interface IHasISO25010
    {
        /// <summary>
        ///     Gets or sets the ISO25010 quality
        ///     associated to this item.
        /// </summary>
        ISO25010 ISO25010Quality { get; set; }
    }
}