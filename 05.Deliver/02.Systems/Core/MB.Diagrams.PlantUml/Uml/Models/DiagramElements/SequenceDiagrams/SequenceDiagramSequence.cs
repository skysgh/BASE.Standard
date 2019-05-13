namespace App.Diagrams.PlantUml.Uml
{
    /// <summary>
    /// 
    /// </summary>
    public class SequenceDiagramSequence : ISequenceDiagramElement
    {
        /// <summary>
        /// The name of the From Participant.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The name of the From Participant.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// The optional text to place over the sequence line.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets a flag indicating that the Sequence line should be dotted or not.
        /// </summary>
        public bool IsReturn { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagramSequence"/> class.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="text">The text.</param>
        /// <param name="isReturn">if set to <c>true</c> [is return].</param>
        public SequenceDiagramSequence(string from, string to, string text, bool isReturn = false)
        {
            From = from;
            To = to;
            Text = text;
            IsReturn = isReturn;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string result = "\"{0}\" {1} \"{2}\"".FormatStringInvariantCulture(From, IsReturn ? "-->" : "->", To);
            if (!Text.IsNullOrEmpty())
            {
                result = "{0} : \"{1}\"".FormatStringInvariantCulture(result, Text);
            }
            
            return result;
        }
    }
}