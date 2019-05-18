//namespace App.Diagrams.PlantUml.Uml
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class SequenceDiagramGroupFluent
//    {
//        //protected SequenceDiagramGroupFluent Parent;

//        protected SequenceDiagramGroup SequenceDiagramGroup;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="SequenceDiagramGroupFluent"/> class.
//        /// </summary>
//        /// <param name="sequenceDiagramGroup">The sequence diagram group.</param>
//        protected SequenceDiagramGroupFluent(SequenceDiagramGroup sequenceDiagramGroup)
//        {
//            SequenceDiagramGroup = sequenceDiagramGroup;
//        }


//        /// <summary>
//        /// Add a title to the current group.
//        /// </summary>
//        /// <param name="title"></param>
//        public SequenceDiagramGroupFluent AddTitle(string title)
//        {
//            SequenceDiagramGroup.Title = title;
//            return this;
//        }

//        /// <summary>
//        /// Add a Comment to the current group.
//        /// </summary>
//        /// <param name="comment"></param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent AddComment(string comment)
//        {
//            SequenceDiagramGroup.Sequences.Add(new SequenceDiagramComment(comment));
 
//            return this;
//        }

//        /// <summary>
//        /// Begins a new group, returning the group.
//        /// </summary>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent BeginGroup(string title, bool isConditionalGroup=false)
//        {
//            if (isConditionalGroup)
//            {
//                title = "alt {0}".FormatStringInvariantCulture(title);
//            }

//            SequenceDiagramGroup sequenceDiagramGroup = new SequenceDiagramGroup(title)
//                {
//                    Root = SequenceDiagramGroup.Root,
//                    Parent = SequenceDiagramGroup
//                };

//            SequenceDiagramGroup.Sequences.Add(sequenceDiagramGroup);

//            var sequenceDiagramGroupFluent = new SequenceDiagramGroupFluent(sequenceDiagramGroup) {Parent = this};

//            //Point back to this handler so that the EndGroup can return the same instance:

//            return sequenceDiagramGroupFluent;
//        }

//        /// <summary>
//        /// Begins the group alt.
//        /// </summary>
//        /// <param name="title">The title.</param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent BeginGroupAlt(string title)
//        {
//            SequenceDiagramGroup.Sequences.Add(new SequenceGroupAlt(title));
//            return this;

//        }

//        /// <summary>
//        /// Ends the current group, returning the parent group's handler.
//        /// </summary>
//        public SequenceDiagramGroupFluent EndGroup()
//        {
//            return this.Parent;
//        }


//        /// <summary>
//        /// Adds a sequence
//        /// </summary>
//        /// <param name="toParticipant">To participant.</param>
//        /// <param name="text">The text.</param>
//        /// <param name="isResponse">if set to <c>true</c> [is response].</param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent AddSequence(string toParticipant, string text=null,bool isResponse=false)
//        {
//            SequenceDiagram sequenceDiagram = SequenceDiagramGroup.Root;
//            AddSequence(sequenceDiagram.CurrentParticipant, toParticipant, text,isResponse);
//            return this;
//        }
//        /// <summary>
//        /// Adds the sequence.
//        /// </summary>
//        /// <param name="fromParticipant">From participant.</param>
//        /// <param name="toParticipant">To participant.</param>
//        /// <param name="text">The text.</param>
//        /// <param name="isResponse">if set to <c>true</c> [is response].</param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent AddSequence(string fromParticipant, string toParticipant, string text = null, bool isResponse = false)
//        {
//            SequenceDiagram sequenceDiagram = SequenceDiagramGroup.Root;
//            SequenceDiagramGroup.Sequences.Add(new SequenceDiagramSequence(fromParticipant, toParticipant, text, isResponse));
//            sequenceDiagram.CurrentParticipant = toParticipant;
//            return this;
//        }

//        /// <summary>
//        /// Adds the response sequence.
//        /// </summary>
//        /// <param name="toParticipant">To participant.</param>
//        /// <param name="text">The text.</param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent AddSequenceResponse(string toParticipant, string text = null)
//        {
//            SequenceDiagram sequenceDiagram = SequenceDiagramGroup.Root;

//            return AddSequenceResponse(sequenceDiagram.CurrentParticipant, toParticipant, text);
//        }

//        /// <summary>
//        /// Adds the response sequence.
//        /// </summary>
//        /// <param name="fromParticipant">From participant.</param>
//        /// <param name="toParticipant">To participant.</param>
//        /// <param name="text">The text.</param>
//        /// <returns></returns>
//        public SequenceDiagramGroupFluent AddSequenceResponse(string fromParticipant, string toParticipant, string text = null)
//        {
//            SequenceDiagram sequenceDiagram = SequenceDiagramGroup.Root;
//            SequenceDiagramGroup.Sequences.Add(new SequenceDiagramSequence(fromParticipant, toParticipant, text, true));
//            sequenceDiagram.CurrentParticipant = toParticipant;
//            return this;
//        }




//    }
//}