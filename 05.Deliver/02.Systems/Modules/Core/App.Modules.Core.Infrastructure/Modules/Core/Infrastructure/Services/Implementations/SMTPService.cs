// Copyright MachineBrains, Inc. 2019

using System.Net;
using System.Net.Mail;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Services.Statuses;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISmtpService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="ISmtpService" />
    public class SmtpService : AppCoreServiceBase, ISmtpService
    {
        private readonly SmtpServiceConfigurationStatusComponent _configurationStatus;

        public SmtpService(
            SMTPServiceConfiguration configuration,
            SmtpServiceConfigurationStatusComponent configurationStatus)
        {
            SmtpServiceConfiguration = configuration;
            this._configurationStatus = configurationStatus;
            // configure the smtp server
            SmtpClient = new SmtpClient(configuration.BaseUri);
            SmtpClient.Port = configuration.Port ?? 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.Credentials =
                new NetworkCredential(
                    configuration.ClientIdentifier,
                    configuration.ClientSecret);
        }

        private SMTPServiceConfiguration SmtpServiceConfiguration { get; }

        private SmtpClient SmtpClient { get; }

        public void SendMessage(string toAddress, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(SmtpServiceConfiguration.From);
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            // send the message
            SmtpClient.Send(msg);
        }
    }
}