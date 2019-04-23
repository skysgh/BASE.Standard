namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppHostNamesService
    {

        string[] GetAppHostNamesList();

        string[] GetRoutesList();
    }
}
