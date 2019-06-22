// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using Newtonsoft.Json;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Instead of dragging references to Newtonsoft all over your app...
    /// </summary>
    public class JsonService : AppCoreServiceBase, IJsonService
    {
        public T Parse<T>(string input)
        {
            var result = JsonConvert.DeserializeObject<T>(input);
            return result;
        }


        public string Serialize<T>(T model)
        {
            if (model == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(model);
        }
    }
}