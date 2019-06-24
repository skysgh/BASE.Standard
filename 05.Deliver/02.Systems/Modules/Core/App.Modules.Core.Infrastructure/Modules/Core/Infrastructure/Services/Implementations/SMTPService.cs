// Copyright MachineBrains, Inc. 2019

using System.Net;
using System.Net.Mail;
using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
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
        private readonly SmtpServiceConfigurationStatus _configurationStatus;

        public SmtpService(
            SMTPServiceConfiguration smtpServiceConfiguration,
            SmtpServiceConfigurationStatus configurationStatus)
        {
            SmtpServiceConfiguration = smtpServiceConfiguration;
            this._configurationStatus = configurationStatus;
            // configure the smtp server
            SmtpClient = new SmtpClient(smtpServiceConfiguration.Configuration.BaseUri);
            SmtpClient.Port = smtpServiceConfiguration.Configuration.Port ?? 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.Credentials =
                new NetworkCredential(
                    smtpServiceConfiguration.Configuration.Key,
                    smtpServiceConfiguration.Configuration.Secret);
        }

        private SMTPServiceConfiguration SmtpServiceConfiguration { get; }

        private SmtpClient SmtpClient { get; }

        public void SendMessage(string toAddress, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(SmtpServiceConfiguration.Configuration.From);
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            // send the message
            SmtpClient.Send(msg);
        }
    }
}