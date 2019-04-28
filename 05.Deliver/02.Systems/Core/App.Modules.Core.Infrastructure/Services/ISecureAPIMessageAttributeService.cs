namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using System.Collections;
    using App.Modules.Core.Shared.Contracts.Services;

    public interface ISecureAPIMessageAttributeService : IAppModuleCoreService
    {
        bool NeedsProcessing(Type type);

        void Process(IEnumerable models);
        void Process(object model);
    }
}