// Copyright MachineBrains, Inc. 2019

using App.Diagrams.PlantUml.Models;

namespace App.Modules.Core.Infrastructure.Services.Messages
{
    /// <summary>
    ///     A response object from the Application's Infrastructure service
    /// </summary>
    public class PlantUmlDiagramRenderingResult
    {
        public string Title { get; set; }
        public DiagramRenderingResponse Response { get; set; }
    }
}