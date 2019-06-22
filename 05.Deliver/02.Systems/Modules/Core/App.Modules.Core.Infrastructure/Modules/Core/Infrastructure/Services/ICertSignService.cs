﻿// Copyright MachineBrains, Inc. 2019

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     Sign data.
    ///     <para>
    ///         Use to sign OperationLog entries.
    ///     </para>
    /// </summary>
    public interface ICertSignService : IInfrastructureService
    {
        byte[] Sign(byte[] data, RSACryptoServiceProvider cryptoServiceProvider);
        byte[] Sign(byte[] data, X509FindType certFindType, string certSearchTerm);
        byte[] Sign(string text, X509FindType certFindType, string certSearchTerm);
        bool Verify(byte[] data, byte[] signature, RSACryptoServiceProvider cryptoServiceProvider);
        bool Verify(byte[] data, byte[] signature, X509FindType certFindType, string certSearchTerm);
        bool Verify(string clearText, byte[] signature, X509FindType certFindType, string certSearchTerm);
    }
}