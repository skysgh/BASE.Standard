// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISecureAPIMessageAttributeService : IInfrastructureService
    {
        bool NeedsProcessing(Type type);

        void Process(IEnumerable models);
        void Process(object model);
    }
}