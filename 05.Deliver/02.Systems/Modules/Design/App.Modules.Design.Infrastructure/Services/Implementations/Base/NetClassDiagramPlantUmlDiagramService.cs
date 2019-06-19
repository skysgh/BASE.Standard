// Copyright MachineBrains, Inc.

using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Models;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Services.Messages;

namespace App.Modules.Design.Infrastructure.Services.Implementations.Base
{
    /// <summary>
    /// Implementation of
    /// <see cref="INetClassPlantUmlDiagramService"/>
    /// to self-document the system.
    /// </summary>
    /// <seealso cref="App.Modules.Design.Infrastructure.Services.Implementations.INetClassPlantUmlDiagramService" />
    public class NetClassPlantUmlDiagramService : INetClassPlantUmlDiagramService
    {
        private readonly INetClassDiagramPlantUmlDiagramService _netClassDiagramPlantUmlDiagramService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetClassPlantUmlDiagramService"/> class.
        /// </summary>
        /// <param name="netClassDiagramPlantUmlDiagramService">The net class diagram plant uml diagram service.</param>
        public NetClassPlantUmlDiagramService(INetClassDiagramPlantUmlDiagramService netClassDiagramPlantUmlDiagramService)
        {
            _netClassDiagramPlantUmlDiagramService = netClassDiagramPlantUmlDiagramService;
        }



        /// <summary>
        /// Documents the types discovered according
        /// to the given Module, Assembly or Type name.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="svglinkBaseUrl">The svglink base URL.</param>
        /// <returns></returns>
        public PlantUmlDiagramRenderingResult Document(string searchText, string svglinkBaseUrl = null)
        {
            var diagramRenderingRequest = new DiagramRenderingRequest(searchText);
            diagramRenderingRequest.AssemblyNamePrefixFilter = Application.AssemblyPrefix;
            diagramRenderingRequest.RenderingStats.LinkBaseUrl = svglinkBaseUrl;


            PlantUmlDiagramRenderingResult result = new PlantUmlDiagramRenderingResult();

            result.Response = _netClassDiagramPlantUmlDiagramService.Document(diagramRenderingRequest);

            result.Title = result.Response.DiagramTitle;
            return result;

        }

    }
}

