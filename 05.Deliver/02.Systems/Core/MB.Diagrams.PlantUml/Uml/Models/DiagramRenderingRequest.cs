// Copyright MachineBrains, Inc.
namespace App.Diagrams.PlantUml.Models
{
    public class DiagramRenderingRequest
    {
        public string AssemblyNamePrefixFilter { get; set; }
        //private DiagramRenderingRequestSearchType _searchType = DiagramRenderingRequestSearchType.String;

        //public DiagramRenderingRequestSearchType SearchType
        //{
        //    get => _searchType;
        //    set => _searchType = value;
        //}

        /// <summary>
        /// Empty, or the name of an Assembly, Namespace, or Type.
        /// Used to fill the
        /// Assemblies
        /// or
        /// <see cref="Include"/> Type array.
        /// </summary>
        public string SearchTerm { get; set; }


        /// <summary>
        /// The types to search for
        /// </summary>
        public DiagramRenderingRequestTypes Types => _types ?? (_types = new DiagramRenderingRequestTypes());
        private DiagramRenderingRequestTypes _types;


        public DiagramRenderingStats RenderingStats
        {
            get { return _diagramRenderingStats ?? (_diagramRenderingStats = new DiagramRenderingStats()); }
        }
        private DiagramRenderingStats _diagramRenderingStats;




        /// <summary>
        /// The Type of the Image (default is Svg in order to enable linking).
        /// </summary>




        public DiagramRenderingRequest(string searchTerm)
        {
            this.SearchTerm = searchTerm;
           // this.SearchType = DiagramRenderingRequestSearchType.String;
        }

        public DiagramRenderingRequest(DiagramRenderingRequestTypes diagramRenderingRequestTypes)
        {
            _types = diagramRenderingRequestTypes;
            //this.SearchType = DiagramRenderingRequestSearchType.Type;
        }
    }
}