// Copyright MachineBrains, Inc. 2019

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IDbContextSchemaModelInitializationService
    {
        void DefineByReflection(ModelBuilder modelBuilder, Assembly assemblyToSearchForModelsWithin = null);
    }
}