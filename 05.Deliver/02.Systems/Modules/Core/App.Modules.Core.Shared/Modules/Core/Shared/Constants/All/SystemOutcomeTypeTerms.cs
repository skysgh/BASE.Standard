namespace App.Modules.Core.Shared.Constants.All
{
    /// <summary>
    /// To organize XUnit tests 
    /// they should be decorated with 'TraitAttribute'.
    /// The Trait key can be anything -- so it's best
    /// to create a convention. 
    /// The following static words are this system's
    /// convention.
    /// </summary>
    public class SystemOutcomeTypeTerms
    {
        public class Traits {
            public const string Feature = "Feature";
            public const string Quality = "Quality";
        }

        public class Features
        {
            public const string General = Traits.Feature + "/" + "General";
        }



        public class Qualities {
            public class ISO25010Terms
            {
                public const string FunctionalSuitability = Traits.Quality + "/" + "ISO25010" + "/" + "FunctionalSuitability";
                public const string PerformanceEfficiency = Traits.Quality + "/" + "ISO25010" + "/" + "PerformanceEfficiency";
                public const string Compatibility = Traits.Quality + "/" + "ISO25010" + "/" + "Compatibility";
                public const string Usability = Traits.Quality + "/" + "ISO25010" + "/" + "Usability";
                public const string Reliability = Traits.Quality + "/" + "ISO25010" + "/" + "Reliability";
                public const string Security = Traits.Quality + "/" + "ISO25010" + "/" + "Security";
                public const string Maintainability = Traits.Quality + "/" + "ISO25010" + "/" + "Maintainability";
                public const string Portability = Traits.Quality + "/" + "ISO25010" + "/" + "Portability";
            }
        }

    }

}
