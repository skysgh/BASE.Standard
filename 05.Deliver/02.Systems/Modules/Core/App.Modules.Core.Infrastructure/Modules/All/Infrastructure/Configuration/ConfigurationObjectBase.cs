// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Infrastructure.Configuration
{/// <summary>
///  Implementation of <see cref="IConfigurationObject"/>
/// as a base class for a Configuration Object.
/// <para>
/// Configuration Object's are *singletons* that are
/// just collection of settings for a similar domain.
/// </para>
/// <para>
/// For example, the might just be the settings needed
/// by an SMTPNotificationService (the settings required
/// to connect to a remote MTA).
/// </para>
/// <para>
/// Etc.
/// </para>
/// </summary>
    public abstract class ConfigurationObjectBase : IConfigurationObject
    {

    }
}