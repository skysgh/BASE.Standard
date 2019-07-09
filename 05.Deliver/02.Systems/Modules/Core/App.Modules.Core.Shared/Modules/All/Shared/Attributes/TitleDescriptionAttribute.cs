// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.All.Shared.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class TitleDescriptionAttribute : Attribute, IHasTitleAndDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleDescriptionAttribute" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="instructions">The instructions.</param>
        public TitleDescriptionAttribute(string title, string description, string instructions=null)
        {
            Title = title;
            Description = description;
            Instructions = instructions;
        }


        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        public string Instructions { get; set; }
    }
}