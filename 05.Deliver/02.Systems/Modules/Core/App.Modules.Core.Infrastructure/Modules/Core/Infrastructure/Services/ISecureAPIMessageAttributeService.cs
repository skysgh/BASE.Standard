using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using System.Collections;

    public interface ISecureAPIMessageAttributeService : IInfrastructureService
    {
        bool NeedsProcessing(Type type);

        void Process(IEnumerable models);
        void Process(object model);
    }
}