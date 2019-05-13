using System;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml
{
    /// <summary>
    /// Contract for a service
    /// to render a Class Diagram.
    /// <para>
    /// Handles the build up of a requiest for types
    /// Invokes
    /// <see cref="INetClassDiagramPlantUmlDiagramService"/>.
    /// </para>
    /// </summary>
    public interface INetClassDiagramPlantUmlDiagramService 
    {



        /// <summary>
        /// Develop PlantUml based description of the given Types.
        /// </summary>
        /// <param name="diagramRenderingRequest">The rendering stats.</param>
        /// <returns></returns>
        DiagramRenderingResponse Document(DiagramRenderingRequest diagramRenderingRequest);
    }
}