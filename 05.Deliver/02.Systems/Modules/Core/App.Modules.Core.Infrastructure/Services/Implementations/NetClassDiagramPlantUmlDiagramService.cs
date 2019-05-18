// Copyright MachineBrains, Inc.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Models;
using StackExchange.Redis;

namespace App.Modules.Core.Infrastructure.Services.Implementations
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
            diagramRenderingRequest.AssemblyNamePrefixFilter = Shared.Constants.Application.AssemblyPrefix;
            diagramRenderingRequest.RenderingStats.LinkBaseUrl = svglinkBaseUrl;


            PlantUmlDiagramRenderingResult result = new PlantUmlDiagramRenderingResult();

            result.Response = _netClassDiagramPlantUmlDiagramService.Document(diagramRenderingRequest);

            result.Title = result.Response.DiagramTitle;
            return result;

        }

    }
}

