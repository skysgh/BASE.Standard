// Copyright MachineBrains, Inc.
namespace App.Diagrams.PlantUml.Models
{
    /// <summary>
    /// Enumeration of the 
    /// diagram type (App, Module, Assembly, Namespaces, Types)
    /// is rendered within the
    /// of <see cref="DiagramRenderingResponse"/>
    /// </summary>
    public enum DiagramRenderingResponseType
    {
        /// <summary>
        /// The Diagram Search is a string, and the Type is still unmatched.
        /// </summary>
        Undefined,
        /// <summary>
        /// Renders the App's Module's as Packages. No Assemblies are rendered.
        /// </summary>
        App,
        /// <summary>
        /// Renders a single Module's set of Assemblies as a set of linked Packages. No Namespaces are rendered.
        /// </summary>
        Module,
        /// <summary>
        /// Renders a single Assembly, with it's base Namespaces as nested Packages. No Types are rendered.
        /// </summary>
        Assembly,

        /// <summary>
        /// Renders a single Namespace, with it's nested Namespaces Types.
        /// </summary>
        Namespace,

        /// <summary>
        /// Renders a set of Types, inter-related to other Types, with Namespaces shown in order to keep Type names shorter.
        /// </summary>
        Type
    }
}