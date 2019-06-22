// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ILocalisationService : IInfrastructureService
    {
        bool ThreadCultureSet { get; }
        void SetThreadCulture(string localisationCode);
        bool IsValidCultureInfoName(string clientLocalisationCode);
    }
}