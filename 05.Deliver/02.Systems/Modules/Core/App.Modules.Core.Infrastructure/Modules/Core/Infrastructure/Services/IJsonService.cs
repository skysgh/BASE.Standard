// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Instead of dragging references to Newtonsoft all over your app...
    /// </summary>
    public interface IJsonService : IInfrastructureService
    {
        T Parse<T>(string input);

        string Serialize<T>(T model);
    }
}