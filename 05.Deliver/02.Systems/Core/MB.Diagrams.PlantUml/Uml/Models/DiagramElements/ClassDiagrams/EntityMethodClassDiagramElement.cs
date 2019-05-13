using MB.Diagrams.PlantUml;

namespace App.Diagrams.PlantUml.Uml
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EntityMethodClassDiagramElement
    {
        public EntityDiagramMemberVisibility Visibility { get; set; }
        public string PropertyTypeName { get; set; }
        public string Name { get; set; }

        public List<string> TypeParameterNames
        {
            get { return _typeParameters ?? (_typeParameters = new List<string>()); }
        }
        private List<string> _typeParameters;

        public List<EntityMethodArgumentClassDiagramElement> Parameters
        {
            get { return _parameters ?? (_parameters = new List<EntityMethodArgumentClassDiagramElement>()); }
        }
        private List<EntityMethodArgumentClassDiagramElement> _parameters;

        public string ResultTypeName { get; set; }

        public EntityMethodClassDiagramElement(EntityDiagramMemberVisibility visibility, Type returnType, string name,
                                   IEnumerable<string> typeParams, IEnumerable<EntityMethodArgumentClassDiagramElement> arguments)
            : this(visibility, returnType.GetName(false), name, typeParams, arguments)
        {

        }

        public EntityMethodClassDiagramElement(EntityDiagramMemberVisibility visibility, string returnType, string name,
                                   IEnumerable<string> typeParams, IEnumerable<EntityMethodArgumentClassDiagramElement> arguments)
        {
            this.Visibility = visibility;
            this.ResultTypeName = returnType;
            this.Name = name;
            this.TypeParameterNames.Add(typeParams);
            this.Parameters.Add(arguments);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            switch (Visibility)
            {
                case EntityDiagramMemberVisibility.Abstract:
                    stringBuilder.Append("{abstract} +");
                    break;
                case EntityDiagramMemberVisibility.Public:
                    stringBuilder.Append("+");
                    break;
                case EntityDiagramMemberVisibility.Internal:
                    stringBuilder.Append("~");
                    break;
                case EntityDiagramMemberVisibility.Protected:
                    stringBuilder.Append("#");
                    break;
                case EntityDiagramMemberVisibility.Private:
                    stringBuilder.Append("-");
                    break;
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(Name);
            int iMax;
            if (TypeParameterNames.Count > 0)
            {
                stringBuilder.Append("<");
                iMax = TypeParameterNames.Count;
                for (int i = 0; i < iMax; i++)
                {
                    var arg = TypeParameterNames[i];
                    if (i != 0)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(arg);
                    }
                    else
                    {
                        stringBuilder.Append(arg);
                    }
                }
                stringBuilder.Append(">");
            }
            stringBuilder.Append("(");
            iMax = Parameters.Count;
            for (int i = 0; i < iMax; i++)
            {
                var arg = Parameters[i];
                if (i != 0)
                {
                    stringBuilder.Append(", ");
                    stringBuilder.Append(arg);
                }
                else
                {
                    stringBuilder.Append(arg);
                }
            }
            stringBuilder.Append(")");

            stringBuilder.Append(" ");
            stringBuilder.Append(":");
            stringBuilder.Append(" ");

            stringBuilder.Append(ResultTypeName??"void");


            return stringBuilder.ToString();
        }

    }
}