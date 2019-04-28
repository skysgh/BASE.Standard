namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppHostNamesService : IAppModuleCoreService
    {

        string[] GetAppHostNamesList();

        string[] GetRoutesList();
    }
}
