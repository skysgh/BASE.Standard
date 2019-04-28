namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Infrastructure.Services.Configuration;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// provide Mime information.
    /// <para>
    /// Of use by MediaUploadServices as well as SMTP (attachment) services.
    /// </para>
    /// </summary>
    /// <seealso cref="IAppModuleCoreService" />
    public interface IDictionaryBasedMimeTypeService : IAppModuleCoreService
    {
        //IDictionaryBasedMimeTypeServiceConfiguration Configuration { get; }

        string GetMimeTypeFromFileExtension(string fileNameExtensionWithPrefixDot);
    }
}