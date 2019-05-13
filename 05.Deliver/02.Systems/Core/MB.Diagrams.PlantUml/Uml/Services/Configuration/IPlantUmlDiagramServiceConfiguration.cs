namespace App.Diagrams.PlantUml.Uml.Services.Configuration
{
    /// <summary>
    /// Contract for a singleton Configuration object for the <see cref="IPlantUmlDiagramService"/>
    /// </summary>
    public interface IPlantUmlDiagramServiceConfiguration 
    {


        /// <summary>
        /// Gets or sets the base url of the PlantUml service.
        /// </summary>
        /// <value>
        /// The server URL.
        /// </value>
        string ServerUrl { get; set; }

    }
}