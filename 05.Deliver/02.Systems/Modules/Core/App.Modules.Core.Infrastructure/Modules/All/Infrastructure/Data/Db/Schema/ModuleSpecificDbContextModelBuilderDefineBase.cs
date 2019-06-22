﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema
{
    /// <summary>
    ///     Base class
    ///     for Defining a single entity within
    ///     the given ModelBuilder of
    ///     a specif Logical Module DbContext.
    /// </summary>
    /// <seealso cref="IHasModuleSpecificDbContextModelBuilderSchemaInitializer" />
    public abstract class ModuleSpecificDbContextModelBuilderDefineBase
        : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        private string _defaultSchemaName;

        /// <summary>
        ///     Gets or sets the default name of the schema
        ///     (which is the same as the Logical Module).
        /// </summary>
        public string DefaultSchemaName
        {
            get => _defaultSchemaName ?? (_defaultSchemaName = Module.Id(GetType()));
            set => _defaultSchemaName = value;
        }


        /// <summary>
        ///     Defines the Module specific DbContext schema
        ///     for a given entity.
        ///     <para>
        ///         Invoked at startup.
        ///     </para>
        /// </summary>
        /// <param name="model">The model.</param>
        public abstract void DefineSchema(ModelBuilder model);
    }
}