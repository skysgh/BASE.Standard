﻿// Copyright MachineBrains, Inc. 2019

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ICertSignService" />
    ///     Infrastructure Service Contract
    /// </summary>
    public class CertSignService : AppCoreServiceBase, ICertSignService
    {
        public byte[] Sign(string text, X509FindType certFindType, string certSearchTerm)
        {
            var encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            return Sign(data, certFindType, certSearchTerm);
        }

        public byte[] Sign(byte[] data, X509FindType certFindType, string certSearchTerm)
        {
            var cryptoServiceProvider = GetCrytoServiceProvider(certFindType, certSearchTerm);
            return Sign(data, cryptoServiceProvider);
        }

        public byte[] Sign(byte[] data, RSACryptoServiceProvider cryptoServiceProvider)
        {
            var sha512 = new SHA512Managed();

            byte[] privateKeyBlob = cryptoServiceProvider.ExportCspBlob(true);
            var cp = new CspParameters(24);
            cryptoServiceProvider = new RSACryptoServiceProvider(cp);
            cryptoServiceProvider.ImportCspBlob(privateKeyBlob);

            byte[] hash = sha512.ComputeHash(data);
            // Sign the hash
            byte[] signature = cryptoServiceProvider.SignHash(hash, CryptoConfig.MapNameToOID("SHA-512"));
            return signature;
        }

        public bool Verify(string clearText, byte[] signature, X509FindType certFindType, string certSearchTerm)
        {
            var encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(clearText);
            return Verify(data, signature, certFindType, certSearchTerm);
        }

        public bool Verify(byte[] data, byte[] signature, X509FindType certFindType, string certSearchTerm)
        {
            var cryptoServiceProvider = GetCrytoServiceProvider(certFindType, certSearchTerm);
            return Verify(data, signature, cryptoServiceProvider);
        }

        public bool Verify(byte[] data, byte[] signature, RSACryptoServiceProvider cryptoServiceProvider)
        {
            return cryptoServiceProvider.VerifyData(data, CryptoConfig.MapNameToOID("SHA-512"), signature);
        }

        private RSACryptoServiceProvider GetCrytoServiceProvider(X509FindType certFindType, string certSearchTerm)
        {
            // Access Personal (MY) certificate store of current user

            var certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly);
            var certsFound = certStore.Certificates.Find(certFindType, certSearchTerm, false);
            if (certsFound.Count == 0)
            {
                throw new Exception("No valid cert was certsFound");
            }

            if (certsFound.Count > 1)
            {
                throw new Exception("More than one valid cert was certsFound");
            }

            var cert = certsFound[0];
            RSACryptoServiceProvider cryptoServiceProvider;
            var b = cert.HasPrivateKey;
            var pk = cert.PrivateKey;
            cryptoServiceProvider = pk as RSACryptoServiceProvider;
            return cryptoServiceProvider;
        }
    }
}