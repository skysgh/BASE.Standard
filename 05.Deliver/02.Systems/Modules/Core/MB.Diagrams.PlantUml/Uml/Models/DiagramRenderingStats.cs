// Copyright MachineBrains, Inc.
namespace App.Diagrams.PlantUml.Models
{
    public class DiagramRenderingStats
    {
        /// <summary>
        /// The base Url to use when developing Clickable
        /// links within an SVG based image.
        /// </summary>
        public string LinkBaseUrl { get; set; }

        /// <summary>
        /// Packages with lots of elements
        /// become unreadable.
        /// </summary>
        public int MaxElementsPerPackage = 10;
        public int MaxPropertiesPerClass = 5;
        public int MaxMethodsPerClass = 5;

        /// <summary>
        /// The rendering approach to use.
        /// </summary>
        public PackageRenderingType RenderingApproach
        {
            get => _showPackages;
            set => _showPackages = value;
        }
        private PackageRenderingType _showPackages = PackageRenderingType.None;

        public DiagramRenderingRequestImageType ImageOutputType
        {
            get => _imageOutputType;
            set => _imageOutputType = value;
        }
        private DiagramRenderingRequestImageType _imageOutputType = DiagramRenderingRequestImageType.Svg;

    }
}