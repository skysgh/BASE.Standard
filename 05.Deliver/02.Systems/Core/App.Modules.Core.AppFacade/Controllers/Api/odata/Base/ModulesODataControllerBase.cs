// Copyright MachineBrains, Inc.

using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata.Base
{
    public abstract class ModulesODataControllerBase : AllModulesODataControllerBase
    {
        protected ModulesODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {

        }
    }
}