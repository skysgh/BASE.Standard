// Copyright MachineBrains, Inc.

using App.Modules.Core.Infrastructure.Services.Messages;

namespace App.Modules.Design.Infrastructure.Services.Implementations
{
    /// <summary>
    /// A Service to render a diagram based on provided search term.
    /// </summary>
    public interface INetClassPlantUmlDiagramService
    {


        PlantUmlDiagramRenderingResult Document(string searchText, string svglinkBaseUrl = null);




    }
}