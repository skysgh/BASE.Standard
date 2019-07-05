using System;
using App.Modules.Core.Shared.Models.Messages;

namespace App
{
    public static class ConfigurationStatusComponentBaseExtensions
    {
        public static void SetToError(this ConfigurationStatusComponentBase configurationStatus, Exception e)
        {
            if (configurationStatus.Status ==
                ConfigurationStatusComponentStatusType.ConfigurationVerified)
            {
                return;
            }
            configurationStatus.Status =
                ConfigurationStatusComponentStatusType
                    .ConfigurationError;

            configurationStatus.AddStep(ConfigurationStatusComponentStepType.General,ConfigurationStatusComponentStepStatusType.Red,e.Message,"Error");
        }
        public static void SetToVerified(this ConfigurationStatusComponentBase configurationStatus)
        {
            if (configurationStatus.Status ==
                ConfigurationStatusComponentStatusType.ConfigurationVerified)
            {
                return;
            }
            configurationStatus.Status =
                ConfigurationStatusComponentStatusType
                    .ConfigurationVerified;
        }

    }
}
