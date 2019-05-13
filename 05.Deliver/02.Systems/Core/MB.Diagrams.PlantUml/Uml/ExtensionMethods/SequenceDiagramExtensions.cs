using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Uml;

namespace App.Diagrams.PlantUml.Uml
{
    using App.Diagrams.PlantUml.Uml;

    public static class SequenceDiagramExtensions
    {
        /// <summary>
        /// Adds the participant.
        /// </summary>
        /// <param name="participant">The title.</param>
        /// <returns></returns>
        public static SequenceDiagram AddParticipant(this SequenceDiagram sequenceDiagram, string participant, string type=null)
        {
            //Get self:
            if (!type.IsNullOrEmpty())
            {
                participant = "{0} {1}".FormatStringInvariantCulture(type, participant);
            }
            sequenceDiagram.Root.Participants.Add(participant);

            return sequenceDiagram;
        }

    }

    public static class SequenceDiagramGroupExtensions
    {
        /// <summary>
        /// Add a title to the current group.
        /// </summary>
        /// <param name="title"></param>
        public static SequenceDiagramGroup SetTitle(this SequenceDiagramGroup sequenceDiagramGroup, string title)
        {
            sequenceDiagramGroup.Title = title;
            return sequenceDiagramGroup;
        }

        /// <summary>
        /// Add a Comment to the current group.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static SequenceDiagramGroup AddComment(this SequenceDiagramGroup sequenceDiagramGroup, string comment)
        {
            sequenceDiagramGroup.Sequences.Add(new SequenceDiagramCommentDiagramElement(comment));

            return sequenceDiagramGroup;
        }

        /// <summary>
        /// Begins a new group, returning the group.
        /// </summary>
        /// <returns></returns>
        public static SequenceDiagramGroup BeginGroup(this SequenceDiagramGroup sequenceDiagramGroup, string title, string prefix = "group")
        {
            //No quote
                title = "{0} {1}".FormatStringInvariantCulture(prefix, title).Trim();

                SequenceDiagramGroup nestedSequenceDiagramGroup = new SequenceDiagramGroup()
            {
                Title = title,
                Root = sequenceDiagramGroup.Root,
                Parent = sequenceDiagramGroup
            };

            sequenceDiagramGroup.Sequences.Add(nestedSequenceDiagramGroup);

            sequenceDiagramGroup.Root.Groups.Push(nestedSequenceDiagramGroup);

            return nestedSequenceDiagramGroup;
        }

        /// <summary>
        /// Begins the group alt.
        /// </summary>
        /// <param name="sequenceDiagramGroup">The sequence diagram group.</param>
        /// <param name="elseGroupName">The title.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public static SequenceDiagramGroup CreateElseGroup(this SequenceDiagramGroup sequenceDiagramGroup, string elseGroupName, string prefix="else")
        {
            sequenceDiagramGroup.Sequences.Add(new SequenceDiagramGroupAlt(elseGroupName,prefix));
            return sequenceDiagramGroup;

        }

        /// <summary>
        /// Ends the current group, returning the parent group's handler.
        /// </summary>
        public static SequenceDiagramGroup EndGroup(this SequenceDiagramGroup sequenceDiagramGroup)
        {
            var me = sequenceDiagramGroup.Root.Groups.Pop();

            return sequenceDiagramGroup.Parent;
        }


        /// <summary>
        /// Adds a sequence
        /// </summary>
        /// <param name="toParticipant">To participant.</param>
        /// <param name="text">The text.</param>
        /// <param name="isResponse">if set to <c>true</c> [is response].</param>
        /// <returns></returns>
        public static SequenceDiagramGroup AddSequence(this SequenceDiagramGroup sequenceDiagramGroup, string toParticipant, string text = null, bool isResponse = false)
        {
            SequenceDiagram sequenceDiagram = sequenceDiagramGroup.Root;
            sequenceDiagramGroup.AddSequence(sequenceDiagram.CurrentParticipant, toParticipant, text, isResponse);
            return sequenceDiagramGroup;
        }
        /// <summary>
        /// Adds the sequence.
        /// </summary>
        /// <param name="fromParticipant">From participant.</param>
        /// <param name="toParticipant">To participant.</param>
        /// <param name="text">The text.</param>
        /// <param name="isResponse">if set to <c>true</c> [is response].</param>
        /// <returns></returns>
        public static SequenceDiagramGroup AddSequence(this SequenceDiagramGroup sequenceDiagramGroup, string fromParticipant, string toParticipant, string text = null, bool isResponse = false)
        {
            SequenceDiagram sequenceDiagram = sequenceDiagramGroup.Root;
            sequenceDiagramGroup.Sequences.Add(new SequenceDiagramSequence(fromParticipant, toParticipant, text, isResponse));
            sequenceDiagram.CurrentParticipant = toParticipant;
            return sequenceDiagramGroup;
        }

        /// <summary>
        /// Adds the response sequence.
        /// </summary>
        /// <param name="toParticipant">To participant.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static SequenceDiagramGroup AddSequenceResponse(this SequenceDiagramGroup sequenceDiagramGroup, string toParticipant, string text = null)
        {
            SequenceDiagram sequenceDiagram = sequenceDiagramGroup.Root;

            return sequenceDiagramGroup.AddSequenceResponse(sequenceDiagram.CurrentParticipant, toParticipant, text);
        }

        /// <summary>
        /// Adds the response sequence.
        /// </summary>
        /// <param name="sequenceDiagramGroup">The sequence diagram group.</param>
        /// <param name="fromParticipant">From participant.</param>
        /// <param name="toParticipant">To participant.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static SequenceDiagramGroup AddSequenceResponse(this SequenceDiagramGroup sequenceDiagramGroup, string fromParticipant, string toParticipant, string text = null)
        {
            SequenceDiagram sequenceDiagram = sequenceDiagramGroup.Root;
            sequenceDiagramGroup.Sequences.Add(new SequenceDiagramSequence(fromParticipant, toParticipant, text, true));
            sequenceDiagram.CurrentParticipant = toParticipant;
            return sequenceDiagramGroup;
        }


        public static SequenceDiagramGroup AddNote(this SequenceDiagramGroup sequenceDiagramGroup, string note,
                                                   bool onRight = false)
        {
            sequenceDiagramGroup.Sequences.Add(new SequenceDiagramNote(note,onRight));

            return sequenceDiagramGroup;
            
        }


    }
}
