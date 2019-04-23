namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Services;

    public interface ILocalisationService : IHasAppCoreService
    {
        bool ThreadCultureSet { get; }
        void SetThreadCulture(string localisationCode);
        bool IsValidCultureInfoName(string clientLocalisationCode);
    }
}