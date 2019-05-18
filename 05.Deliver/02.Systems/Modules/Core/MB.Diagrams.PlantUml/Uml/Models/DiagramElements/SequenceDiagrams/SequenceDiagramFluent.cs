//namespace App.Diagrams.PlantUml.Uml
//{
//    /// <summary>
//    /// Fluent wrapper to a <see cref="SequenceDiagram"/>
//    /// </summary>
//    public class SequenceDiagramFluent : SequenceDiagramGroupFluent
//    {

//        internal SequenceDiagramFluent():base(new SequenceDiagram())
//        {
//        }

//        internal SequenceDiagramFluent(SequenceDiagram sequenceDiagram)
//            : base(sequenceDiagram)
//        {
//        }

//        /// <summary>
//        /// Adds the participant.
//        /// </summary>
//        /// <param name="participant">The title.</param>
//        /// <returns></returns>
//        public SequenceDiagramFluent AddParticipant(string participant)
//        {
//            //Get self:
//            SequenceDiagramGroup.Root.Participants.Add(participant);

//            return this;
//        }

//    }
//}