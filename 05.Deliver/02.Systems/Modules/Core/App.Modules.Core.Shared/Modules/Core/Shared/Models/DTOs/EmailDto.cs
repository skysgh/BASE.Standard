// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     A DTO for EMail entities.
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        ///     Gets or sets whom the message is to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        ///     Gets or sets message subject.
        /// </summary>
        /// <value>
        ///     The subject.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        ///     Gets or sets the message body.
        /// </summary>
        public string Body { get; set; }
    }
}