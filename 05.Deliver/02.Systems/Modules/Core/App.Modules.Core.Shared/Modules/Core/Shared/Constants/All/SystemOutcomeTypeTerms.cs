// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Constants.All
{
    /// <summary>
    ///     To organize XUnit tests
    ///     they should be decorated with 'TraitAttribute'.
    ///     The Trait key can be anything -- so it's best
    ///     to create a convention.
    ///     The following static words are this system's
    ///     convention.
    /// </summary>
    public class SystemOutcomeTypeTerms
    {
        /// <summary>
        ///     TODO
        /// </summary>
        public static class Traits
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string Feature = "Feature";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string Quality = "Quality";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }

        /// <summary>
        ///     TODO
        /// </summary>
        public static class Features
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            public const string General = Traits.Feature + "/" + "General";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }


        /// <summary>
        ///     Qualities that can be assigned to systems and data.
        /// </summary>
        public static class Qualities
        {
            /// <summary>
            ///     Qualities that can be assigned to Systems.
            /// </summary>
            public class ISO25010Terms
            {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
                public const string FunctionalSuitability =
                    Traits.Quality + "/" + "ISO25010" + "/" + "FunctionalSuitability";

                public const string PerformanceEfficiency =
                    Traits.Quality + "/" + "ISO25010" + "/" + "PerformanceEfficiency";

                public const string Compatibility = Traits.Quality + "/" + "ISO25010" + "/" + "Compatibility";
                public const string Usability = Traits.Quality + "/" + "ISO25010" + "/" + "Usability";
                public const string Reliability = Traits.Quality + "/" + "ISO25010" + "/" + "Reliability";
                public const string Security = Traits.Quality + "/" + "ISO25010" + "/" + "Security";
                public const string Maintainability = Traits.Quality + "/" + "ISO25010" + "/" + "Maintainability";
                public const string Portability = Traits.Quality + "/" + "ISO25010" + "/" + "Portability";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            }
        }
    }
}