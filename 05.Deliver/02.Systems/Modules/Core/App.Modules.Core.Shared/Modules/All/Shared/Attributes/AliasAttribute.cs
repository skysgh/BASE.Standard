using System;

namespace App.Modules.All.Shared.Attributes
{

    /// <summary>
    /// The name under which the Configuration name is persisted.
    /// <para>
    /// In effect, should maybe be called
    /// something like "ConfigurationKey"
    /// </para>
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class AliasAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public AliasAttribute(string displayName)
        {
            DisplayName = displayName;
        }


        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
         public string DisplayName { get; set; }
    }
}