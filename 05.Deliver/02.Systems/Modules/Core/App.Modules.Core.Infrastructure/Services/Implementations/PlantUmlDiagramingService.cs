// Copyright MachineBrains, Inc.

using App.Diagrams.PlantUml.Uml;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class PlantUmlDiagramingService : IPlantUmlDiagramingService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IPlantUmlDiagramService _plantUmlDiagramService;

        public PlantUmlDiagramingService(IDiagnosticsTracingService diagnosticsTracingService,
            IPlantUmlDiagramService plantUmlDiagramService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _plantUmlDiagramService = plantUmlDiagramService;
        }

        public string DevelopImageUrl(string umlText)
        {
            string result = _plantUmlDiagramService.DevelopImageUrl(umlText);
            return result;
        }
        public byte[] DevelopImageByteArray(string umlText)
        {
            var result = _plantUmlDiagramService.RetrieveImageAsByteArray(umlText);
            return result;
        }
    }
}

