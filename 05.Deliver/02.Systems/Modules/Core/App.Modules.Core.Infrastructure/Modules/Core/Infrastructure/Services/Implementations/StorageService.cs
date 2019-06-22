// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Implementations.Base;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IStorageService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IStorageService" />
    public class StorageService : AppCoreServiceBase, IStorageService
    {
        private readonly ITransientLocalFileStorageService _transientLocalFileStorageService;

        public StorageService(ITransientLocalFileStorageService transientLocalFileStorageService)
        {
            _transientLocalFileStorageService = transientLocalFileStorageService;
        }

        public void Persist(byte[] bytes, string fileName)
        {
            _transientLocalFileStorageService.Persist(bytes, fileName);
        }
    }
}