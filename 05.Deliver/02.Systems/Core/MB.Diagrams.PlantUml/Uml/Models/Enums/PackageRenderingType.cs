// Copyright MachineBrains, Inc.
namespace App.Diagrams.PlantUml.Models
{
    public enum PackageRenderingType
    {
        /// <summary>
        /// We rendering the types, with no Packages
        /// around them (so all class/interfaces will
        /// be rendered with full name).
        /// </summary>
        None=0,
        
        /// <summary>
        /// Render all nested namespaces
        /// around the given types.
        /// Can get busy.
        /// </summary>
        Namespace=1,

        /// <summary>
        /// Render the Assembly the type
        /// is in, but not the different Namespaces
        /// under it.
        /// </summary>
        Assembly=2
    }
}