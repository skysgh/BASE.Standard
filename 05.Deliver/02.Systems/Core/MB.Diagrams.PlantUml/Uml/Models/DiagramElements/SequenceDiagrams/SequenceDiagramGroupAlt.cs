namespace App.Diagrams.PlantUml.Uml
{
    /// <summary>
    /// 
    /// </summary>
    public class SequenceDiagramGroupAlt : ISequenceDiagramElement
    {
        /// <summary>
        /// The group prefix (usually else)
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// Gets or sets the title of the Group division.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagramGroupAlt"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public SequenceDiagramGroupAlt(string title,string prefix = "else")
        {
            Prefix = prefix;
            Title = title;
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            //No quotes
            return "{0} {1}".FormatStringInvariantCulture(Prefix,Title).Trim();
        }
    }
}