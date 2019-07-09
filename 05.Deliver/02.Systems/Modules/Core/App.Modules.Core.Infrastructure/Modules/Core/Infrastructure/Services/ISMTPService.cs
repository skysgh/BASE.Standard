// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service
    ///     to send email messages.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Services.IInfrastructureService" />
    [TitleDescription("SMTP Service", "Service used to notify users via Email. Used to invite Users to User Groups, etc.",
        "Settings are set in both the Host Settings(AppSettings) and KeyVault.")]
    public interface ISmtpService : IInfrastructureService
    {
        /// <summary>
        ///     Sends a Text email message.
        /// </summary>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        void SendMessage(string toAddress, string subject, string body);
    }
}