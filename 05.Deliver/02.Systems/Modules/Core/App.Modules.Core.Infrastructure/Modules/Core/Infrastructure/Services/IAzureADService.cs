// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Infrastructure.Services
{
    [TitleDescription("Azure AD Configuration",
        "Service required to provide authentication between components on the server.",
        "Settings are set in both the Host Settings(AppSettings) and KeyVault.")]
    public interface IAzureADService : IAzureService, IInfrastructureService
    {
    }
}