﻿// Copyright MachineBrains, Inc.

using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Models;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Services.Messages;

namespace App.Modules.Design.Infrastructure.Services.Implementations.Base
{
    public class NetClassPlantUmlDiagramService : INetClassPlantUmlDiagramService
    {
        private readonly INetClassDiagramPlantUmlDiagramService _netClassDiagramPlantUmlDiagramService;

        public NetClassPlantUmlDiagramService(INetClassDiagramPlantUmlDiagramService netClassDiagramPlantUmlDiagramService)
        {
            _netClassDiagramPlantUmlDiagramService = netClassDiagramPlantUmlDiagramService;
        }



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

