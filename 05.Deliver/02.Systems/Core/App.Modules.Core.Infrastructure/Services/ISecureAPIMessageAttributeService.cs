﻿namespace App.Modules.Core.Infrastructure.Services
{
    using System;
    using System.Collections;
    using App.Modules.Core.Shared.Services;

    public interface ISecureAPIMessageAttributeService : IHasAppCoreService
    {
        bool NeedsProcessing(Type type);

        void Process(IEnumerable models);
        void Process(object model);
    }
}