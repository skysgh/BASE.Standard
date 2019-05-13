using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Uml;

namespace App.Diagrams.PlantUml.Uml
{
    using System;
    using System.Text;

    public class SequenceDiagramNote :ISequenceDiagramElement
    {
        public bool OnRight { get; set; }
        public string Note { get; set; }

        public SequenceDiagramNote(string note, bool onRight=false)
        {
            Note = note;
            OnRight = onRight;
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

            stringBuilder.AppendLine("{0} {1}".FormatStringInvariantCulture("note {0}", OnRight ? "right" : "left"));
            foreach (string line in Note.Split(new[] {"\\n"}, StringSplitOptions.None))
            {
                stringBuilder.AppendLine(line);
            }
            stringBuilder.AppendLine("end note");

            return stringBuilder.ToString();
        }
    }
}