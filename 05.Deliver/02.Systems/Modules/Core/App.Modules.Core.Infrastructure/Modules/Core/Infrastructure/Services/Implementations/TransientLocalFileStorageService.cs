﻿// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Modules.Core.Infrastructure.Services.Implementations
//{
//    using System.IO;
//    using System.Web;

//    /// <summary>
//    ///     Implementation of the
//    ///     <see cref="ITransientLocalFileStorageService" />
//    ///     Infrastructure Service Contract
//    /// </summary>
//    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ITransientLocalFileStorageService" />
//    public class TransientLocalFileStorageService : AppCoreServiceBase, ITransientLocalFileStorageService
//    {
//        public TransientLocalFileStorageService()
//        {
//            string targetFolder = HttpContext.Current.Server.MapPath("~/uploads/");
//            if (!Directory.Exists(targetFolder))
//            {
//                Directory.CreateDirectory(targetFolder);
//            }
//        }
//        public void Persist(byte[] bytes, string fileName)
//        {
//            string targetFolder = HttpContext.Current.Server.MapPath("~/uploads/");

//            string targetPath = Path.Combine(targetFolder, fileName);
//            File.WriteAllBytes(targetPath, bytes);
//        }
//    }
//}

