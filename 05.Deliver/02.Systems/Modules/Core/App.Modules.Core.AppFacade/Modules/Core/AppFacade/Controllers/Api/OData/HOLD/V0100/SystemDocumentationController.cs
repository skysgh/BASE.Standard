namespace App.Core.Application.API.Controllers.V0100
{
    /// <summary>
    /// Controller for returning 
    /// * Cookie Policy Document Text
    /// * Privacy Document Text
    /// * Data Usage Document
    /// </summary>
    [ODataPath(Constants.Api.ApiControllerNames.SystemDocumentation)]
    public class SystemDocumentationController : CoreODataControllerBase
    {
        public SystemDocumentationController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {
            throw new ToDoException("SystemDocumentationController");
        }
    }
}