// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Entities
{
    // TODO: Enums are evil (offset issue of Interface Localization)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum NZDataClassification
    {
        //An error state:
        Undefined = 0,

        //Policy and Privacy:
        Unspecified = 1,

        Unclassified = 2,
        InConfidence = 3,
        Sensitive = 4,

        //National Security:
        Restricted = 5,
        Confidential = 6,
        Secret = 7,

        //
        TopSecret = 8
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}