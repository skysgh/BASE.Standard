namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Contracts.Services;

    public interface ILocalisationService : IModuleSpecificService
    {
        bool ThreadCultureSet { get; }
        void SetThreadCulture(string localisationCode);
        bool IsValidCultureInfoName(string clientLocalisationCode);
    }
}