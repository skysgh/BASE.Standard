namespace App.Diagrams.PlantUml.Uml.Services.Configuration.Implemtations
{
    /// <summary>
    /// An implementation for the <see cref="IPlantUmlDiagramServiceConfiguration"/>
    /// </summary>
    public class PlantUmlDiagramServiceConfiguration : IPlantUmlDiagramServiceConfiguration
    {

        /// <summary>
        /// Gets or sets the base url of the PlantUml service.
        /// </summary>
        /// <value>
        /// The server URL.
        /// </value>
        public string ServerUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlantUmlDiagramServiceConfiguration"/> class.
        /// </summary>
        public PlantUmlDiagramServiceConfiguration()
        {
            ServerUrl = "http://www.plantuml.com/plantuml";
        }

    }
}