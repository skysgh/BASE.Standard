// Copyright MachineBrains, Inc.
namespace App.Diagrams.PlantUml.Models
{

    public class DiagramRenderingResponse
    {
        /// <summary>
        /// The Scope of the Image (App, Module, Assembly, Namespace, Type) 
        /// </summary>
        public DiagramRenderingResponseType ResponseType { get; set; }

        /// <summary>
        /// The title for the result.
        /// </summary>
        public string DiagramTitle { get; set; }

        /// <summary>
        /// The PlantUML text used to describe the Diagram.
        /// </summary>
        public string DiagramText { get; set; }

        /// <summary>
        /// The url to request the diagram result (in svg or png).
        /// </summary>
        public string DiagramImageUrl { get; set; }

        /// <summary>
        /// The resulting diagram image -- or text svg.
        /// </summary>
        public byte[] DiagramImage { get; set; }

        /// <summary>
        /// The resulting diagram svg
        /// </summary>
        public string DiagramSvg { get; set; }
    }
}