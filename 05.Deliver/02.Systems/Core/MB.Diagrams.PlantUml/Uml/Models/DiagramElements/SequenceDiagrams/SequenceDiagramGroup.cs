namespace App.Diagrams.PlantUml.Uml
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class SequenceDiagramGroup : ISequenceDiagramElement
    {
        /// <summary>
        /// Title of Group (or Diagram, if base Group).
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The root
        /// </summary>
        internal SequenceDiagram Root { get; set; }

        /// <summary>
        /// Pointer to parent <see cref="SequenceDiagramGroup"/>
        /// </summary>
        internal SequenceDiagramGroup Parent { get; set; }



        /// <summary>
        /// The list of sequences added to this group so far.
        /// </summary>
        public IList<ISequenceDiagramElement> Sequences
        {
            get { return _sequence ?? (_sequence = new List<ISequenceDiagramElement>()); }
        }
        private IList<ISequenceDiagramElement> _sequence;


        /// <summary>
        /// Clears the Title, Sequence and CurrentParticipant, and the Participants list.
        /// </summary>
        public virtual void Clear()
        {
            while (_sequence.Any())
            {
                ISequenceDiagramElement sequenceElement = _sequence.Last();
                SequenceDiagramGroup sequenceDiagramGroup = sequenceElement as SequenceDiagramGroup;
                if (sequenceDiagramGroup != null)
                {
                    sequenceDiagramGroup.Clear();
                }
                _sequence.Remove(sequenceElement);
            }
            Title = null;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

                if (!Title.IsNullOrEmpty())
                {
                    if (this == this.Root)
                    {
                        stringBuilder.AppendLine("title {0}".FormatStringInvariantCulture(Title));
                    }
                    else
                    {
                        stringBuilder.AppendLine("{0}".FormatStringInvariantCulture(Title));
                    }
                }

            foreach (ISequenceDiagramElement sequenceDiagramElement in this.Sequences)
            {
                SequenceDiagramGroup sequenceDiagramGroup = sequenceDiagramElement as SequenceDiagramGroup;
                if (sequenceDiagramGroup != null)
                {
                    stringBuilder.Append(sequenceDiagramElement.ToString());
                }
                else
                {
                    stringBuilder.AppendLine(sequenceDiagramElement.ToString());
                }

            }
            if (this != this.Root)
            {
                //Nested groups end with 'end'
                stringBuilder.AppendLine("end");
            }
            return stringBuilder.ToString();
        }
    }
}