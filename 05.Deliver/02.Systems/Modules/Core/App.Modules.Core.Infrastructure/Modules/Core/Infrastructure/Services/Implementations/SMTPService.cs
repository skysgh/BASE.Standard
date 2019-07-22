// Copyright MachineBrains, Inc. 2019

using System.Net;
using System.Net.Mail;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services.Configuration;
using App.Modules.Core.Infrastructure.Services.Statuses;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISmtpService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="ISmtpService" />
    public class SmtpService 
        : AppCoreServiceBase
            , ISmtpService
            , IHasPing
    {
        private readonly SMTPServiceConfiguration _configuration;
        private readonly IConfigurationStatusService _configurationStatusService;
        private SmtpClient _smtpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationStatusService">The configuration status service.</param>
        public SmtpService(
            SMTPServiceConfiguration configuration,
            IConfigurationStatusService configurationStatusService)
        {
            _configuration = configuration;
            this._configurationStatusService = configurationStatusService;

            CreateClient();
        }




        private void CreateClient()
        {
            _smtpClient = new SmtpClient(_configuration.BaseUri);
            _smtpClient.Port = _configuration.Port ?? 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials =
                new NetworkCredential(
                    _configuration.ClientIdentifier,
                    _configuration.ClientSecret);

        }
        public void SendMessage(string toAddress, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(_configuration.From);
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            // send the message
            _smtpClient.Send(msg);
            //Update as needed:
            _configurationStatusService.SetStatusToVerified<ISmtpService>();
        }

        public bool Ping()
        {
            if (!_configuration.Enabled)
            {
                return false;
            }

            try
            {
                SendMessage("anyone@anywhere.com", "A simple test",
                    "A simple <b>body</b>.");
                return true;
            }
            catch
            {
            }

            return false;
        }
    }
}