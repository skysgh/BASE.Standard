// Copyright MachineBrains, Inc. 2019

//namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
//{
//    using System;
//    using System.ComponentModel.DataAnnotations.Schema;
//    //using Microsoft.EntityFrameworkCore.ModelConfiguration.Conventions;

//    // Note by default
//    // OneToManyCascadeDeleteConvention
//    // ManyToManyCascadeDeleteConvention
//    // Are already installed.

//    public class IdConvention : Convention
//    {
//        public IdConvention()
//        {
//            Properties()
//                .Where(p =>
//                    p.PropertyType == typeof(Guid)
//                    &&
//                    p.Name == "Id")
//                .Configure(
//                    p =>
//                    {
//                        p.IsKey();
//                        p.ValueGeneratedNever();
//                    });
//        }
//    }
//}

