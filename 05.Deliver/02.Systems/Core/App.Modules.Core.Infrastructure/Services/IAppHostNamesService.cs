namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppHostNamesService : IModuleSpecificService
    {

        string[] GetAppHostNamesList();

        string[] GetRoutesList();
    }
}
