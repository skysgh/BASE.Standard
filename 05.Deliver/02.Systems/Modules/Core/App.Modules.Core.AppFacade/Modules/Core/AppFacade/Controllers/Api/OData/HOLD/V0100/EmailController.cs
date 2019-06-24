using System;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Application.API.Controllers.V0100
{

    /// <summary>
    /// API Controller used to send SMTP based Notifications.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Base.CommonODataControllerBase" />
    public class EmailController : CommonODataControllerBase
    {
        private readonly ISmtpService _smtpService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="smtpService">The SMTP service.</param>
        public EmailController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ISmtpService smtpService)
            :base(
                diagnosticsTracingService,
                principalService)
        {
            _smtpService = smtpService;
        }

        //[WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        /// <summary>
        /// Posts the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public IActionResult Post(EmailDto email)
        {
            try
            {
                _smtpService.SendMessage(email.To, email.Subject, email.Body);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
