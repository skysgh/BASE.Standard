// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     provide Mime information.
    ///     <para>
    ///         Of use by MediaUploadServices as well as SMTP (attachment) services.
    ///     </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface IDictionaryBasedMimeTypeService : IInfrastructureService
    {
        //IDictionaryBasedMimeTypeServiceConfiguration Configuration { get; }

        string GetMimeTypeFromFileExtension(string fileNameExtensionWithPrefixDot);
    }
}