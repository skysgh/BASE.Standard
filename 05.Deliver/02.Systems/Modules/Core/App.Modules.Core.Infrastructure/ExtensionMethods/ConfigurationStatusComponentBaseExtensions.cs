using System;
using App.Modules.Core.Shared.Models.Messages;

namespace App
{
    public static class ConfigurationStatusComponentBaseExtensions
    {
        public static void SetToErrorIfNotYetVerified(
            this ConfigurationStatusComponentBase configurationStatus,
            Exception e)
        {
            configurationStatus.SetToErrorIfNotYetVerified(e.Message);
        }

        public static void SetToErrorIfNotYetVerified(this ConfigurationStatusComponentBase configurationStatus, string reason)
        {
            configurationStatus.ErrorCount += 1;

            if (configurationStatus.Status ==
                ConfigurationStatusComponentStatusType.ConfigurationVerified)
            {
                return;
            }
            // Don't want a ton of errors here, so add only once
            if (configurationStatus.Status !=
                ConfigurationStatusComponentStatusType
                    .ConfigurationError){

                configurationStatus.AddStep(
                    ConfigurationStatusComponentStepType.General,
                    ConfigurationStatusComponentStepStatusType.Fail, reason,
                    "Error");
            }
            configurationStatus.Status =
                ConfigurationStatusComponentStatusType
                    .ConfigurationError;
        }
        public static void SetToVerified(this ConfigurationStatusComponentBase configurationStatus)
        {
            configurationStatus.SuccessCount += 1;

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
