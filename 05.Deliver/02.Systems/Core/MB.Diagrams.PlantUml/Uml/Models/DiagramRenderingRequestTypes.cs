// Copyright MachineBrains, Inc.

using System;

namespace App.Diagrams.PlantUml.Models
{
    /// <summary>
    /// Information about the Types to render,
    /// if the diagram type is not of Assemblies or Namespaces.
    /// </summary>
    public class DiagramRenderingRequestTypes 
    {

        /// <summary>
        /// The 
        /// </summary>
        public Type[] Include
        {
            get => _include ?? (_include = new Type[0]);
            set { _include = value; }
        }
        public Type[] _include;


        public Type[] StopAt
        {
            get => _stopAt ?? (_stopAt = new Type[0]);
            set { _stopAt = value; }
        }
        private Type[] _stopAt;


        public Type[] Ignore
        {
            get => _ignore ?? (_ignore = new Type[0]);
            set => _ignore = value;
        }
        private Type[] _ignore;


        ///// <summary>
        ///// 
        ///// </summary>
        //public Assembly[] Assemblies
        //{
        //    get => _assemblies ?? (_assemblies = new Assembly[0]);
        //    set { _assemblies = value; }

        //}
        //public Assembly[] _assemblies;

    }
}