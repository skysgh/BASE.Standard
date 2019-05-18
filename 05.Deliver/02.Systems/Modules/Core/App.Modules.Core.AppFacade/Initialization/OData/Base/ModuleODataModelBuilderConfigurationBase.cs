// Copyright MachineBrains, Inc.

using App.Modules.Core.Shared.Models;

namespace App.Modules.Core.AppFacade.Initialization.OData.Base
{
    public abstract class ModuleODataModelBuilderConfigurationBase<T> : AllModulesODataModelBuilderConfigurationBase<T>
        where T : class, IHasGuidId, new()
    {
        protected string ModuleName => App.Modules.Core.Shared.Constants.Module.Id;
    }
}