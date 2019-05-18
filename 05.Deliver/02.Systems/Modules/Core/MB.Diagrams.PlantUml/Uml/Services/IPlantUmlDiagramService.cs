namespace App.Diagrams.PlantUml.Uml
{
    using App.Diagrams.PlantUml.Uml.Services.Configuration;

    /// <summary>
    /// Contract for a service to communicate with a remote PlantUml server.
    /// <para>
    /// Invoked by <see cref="INetClassDiagramPlantUmlDiagramService"/>
    /// </para>
    /// </summary>
    public interface IPlantUmlDiagramService 
    {
        /// <summary>
        /// Configuration
        /// </summary>
        IPlantUmlDiagramServiceConfiguration Configuration { get; }



            /// <summary>
        /// Develops the url to the remote diagram image.
        /// </summary>
        /// <param name="diagramText">The diagram text.</param>
        /// <returns></returns>
        string DevelopImageUrl(string diagramText, string imageFormat = "svg");


        /// <summary>
        /// Retrieves from the remote PlantUml server the image
        /// as a byte array.
        /// <para>
        /// The invoker must convert the byte array to a png/other format
        /// in a platform specific way -- as PCL does not provide such classes.
        /// </para>
        /// </summary>
        /// <param name="diagramText"></param>
        /// <returns></returns>
        byte[] RetrieveImageAsByteArray(string diagramText);

    }
}
