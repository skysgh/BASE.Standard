// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IDictionaryBasedMimeTypeService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <internal>
    ///     See: http://stackoverflow.com/questions/1029740/get-mime-type-from-filename-extension
    /// </internal>
    public class DictionaryBasedMimeTypeService : AppCoreServiceBase, IDictionaryBasedMimeTypeService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DictionaryBasedMimeTypeService" /> class.
        /// </summary>
        /// <param name="dictionaryBasedMimeTypeServiceConfiguration">The dictionary based MIME type service configuration.</param>
        public DictionaryBasedMimeTypeService(
            DictionaryBasedMimeTypeServiceConfiguration dictionaryBasedMimeTypeServiceConfiguration)
        {
            Configuration = dictionaryBasedMimeTypeServiceConfiguration;
        }

        /// <summary>
        ///     Gets or sets the configuration used by this service.
        ///     <para>
        ///         The Configuration object is shared between instances of
        ///         this service, therefore should only be modified as per the application's needs
        ///         during Bootstrapping, and no later.
        ///     </para>
        /// </summary>
        public DictionaryBasedMimeTypeServiceConfiguration Configuration { get; }


        /// <summary>
        ///     Gets the MIME type from the given file extension.
        /// </summary>
        /// <param name="fileNameExtensionWithPrefixDot">
        ///     The file name extension (with prefix dot) as is returned with
        ///     Path.GetExtension().
        /// </param>
        /// <returns></returns>
        public string GetMimeTypeFromFileExtension(string fileNameExtensionWithPrefixDot)
        {
            string mimeType;

            if (Configuration.Cache.TryGetValue(fileNameExtensionWithPrefixDot, out mimeType))
            {
                return mimeType;
            }

            return null;
        }
    }
}