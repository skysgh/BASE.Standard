// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Messages;

namespace App.Modules.Design.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     A Service to render a diagram based on provided search term.
    /// </summary>
    public interface INetClassPlantUmlDiagramService
    {
        /// <summary>
        ///     Documents the types discovered according
        ///     to the given Module, Assembly or Type name.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="svglinkBaseUrl">The svglink base URL.</param>
        /// <returns></returns>
        PlantUmlDiagramRenderingResult Document(string searchText, string svglinkBaseUrl = null);
    }
}