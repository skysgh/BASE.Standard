namespace App.Diagrams.PlantUml.Uml
{
    /// <summary>
    /// A comment
    /// </summary>
    public class SequenceDiagramCommentDiagramElement :ISequenceDiagramElement
    {
        /// <summary>
        /// Gets or sets the comment text.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagramCommentDiagramElement"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public SequenceDiagramCommentDiagramElement(string comment)
        {
            Comment = comment;
        }
        public override string ToString()
        {
            return "'{0}".FormatStringInvariantCulture(Comment);
        }
    }
}