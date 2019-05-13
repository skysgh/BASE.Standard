// Copyright MachineBrains, Inc.

using System.Reflection;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// A Service to render a diagram based on provided search term.
    /// </summary>
    public interface INetClassPlantUmlDiagramService
    {


        PlantUmlDiagramRenderingResult Document(string searchText, string svglinkBaseUrl=null);




    }
}