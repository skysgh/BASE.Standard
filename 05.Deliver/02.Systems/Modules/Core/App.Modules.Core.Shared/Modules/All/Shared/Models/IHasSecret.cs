// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract on objects that have a Secret Attribute.
    ///     Often applied to configuration objects.
    /// </summary>
    public interface IHasSecret
    {
        /// <summary>
        ///     Gets or sets the secret.
        /// </summary>
        string Secret { get; set; }
    }
}