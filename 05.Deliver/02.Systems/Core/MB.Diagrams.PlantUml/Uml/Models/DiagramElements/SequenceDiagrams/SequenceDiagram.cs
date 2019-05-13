using System.Collections.Generic;

namespace App.Diagrams.PlantUml.Uml
{
    using System.Text;


    /// <summary>
    /// 
    /// </summary>
    public class SequenceDiagram : SequenceDiagramGroup
    {

        /// <summary>
        /// The last 'toParticipant' mentioned.
        /// </summary>
        public string CurrentParticipant { get; set; }

        /// <summary>
        /// An optional list of Participants to help
        /// lay out the sequence diagram intelligently.
        /// </summary>
        public IList<string> Participants
        {
            get { return _participants ?? (_participants = new List<string>()); }
        }
        private IList<string> _participants;



        public SequenceDiagramGroup CurrentGroup
        {
            get { return Groups.Peek(); }
        }

        internal Stack<SequenceDiagramGroup> Groups 
        {
            get { return _groups ?? (_groups = new Stack<SequenceDiagramGroup>()); }
        }
        private Stack<SequenceDiagramGroup> _groups;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagram"/> class.
        /// </summary>
        public SequenceDiagram()
            : base()
        {

            this.Parent = null;
            this.Root = this;
            this.Groups.Push(this);
        }



        /// <summary>
        /// Clears the Title, Sequence, CurrentParticipant, and Participants list.
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            CurrentParticipant = null;

            Participants.Clear();
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

            if (Participants.Count > 0)
            {
                foreach (string participant in this.Participants)
                {
                    stringBuilder.AppendLine("participant {0}".FormatStringInvariantCulture(participant));
                }
            }
            stringBuilder.Append(base.ToString());

            return stringBuilder.ToString();

        }

    }
}
