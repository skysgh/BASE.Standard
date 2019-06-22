// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq.Expressions;
using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public static class ModelBuilderExtensions
    {
        public static void AssignIndex<T>(this ModelBuilder modelBuilder,
            Expression<Func<T, object>> identifierExpression, bool isUnique = false, string indexIdentifier = null)
            where T : class
        {
            if (string.IsNullOrEmpty(indexIdentifier))
            {
                var body = identifierExpression.Body as MemberExpression;

                if (body == null)
                {
                    var ubody = identifierExpression.Body as UnaryExpression;
                    if (ubody == null)
                    {
                        var nbody = identifierExpression.Body as NewExpression;
                        indexIdentifier = "CompositeIndex";
                    }
                    else
                    {
                        body = ubody.Operand as MemberExpression;
                    }
                }

                if (string.IsNullOrEmpty(indexIdentifier))
                {
                    indexIdentifier = body.Member.Name;
                }
            }


            if (!isUnique)
            {
                modelBuilder.Entity<T>().HasIndex(identifierExpression)
                    .HasName($"IX_{typeof(T).Name}_{indexIdentifier}");
            }
            else
            {
                modelBuilder.Entity<T>().HasAlternateKey(identifierExpression)
                    .HasName($"IX_{typeof(T).Name}_{indexIdentifier}");
            }
        }


        public static void DefineTenantFK<T>(this ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK
        {
            modelBuilder.AssignIndex<T>(x => x.TenantFK);

            modelBuilder.Entity<T>()
                .Property(x => x.TenantFK)
                //.HasColumnOrder(order++)
                .IsRequired()
                ;
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            //modelBuilder.Entity<T>()
            //    .HasRequired(x => x.Tenant)
            //    .WithMany()
            //    .HasForeignKey(x => x.TenantFK)
            //    .WillCascadeOnDelete(false);
        }

        public static void DefineCustomId<T, TId>(this ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>
            where TId : struct
        {
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<T>()
                .Property(x => x.Id)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired();
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }
        }


        public static void DefineUniqueKey<T>(this ModelBuilder modelBuilder, ref int order,
            int size = TextFieldSizes.X64, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasKey
        {
            modelBuilder.AssignIndex<T>(x => x.Key, true);

            modelBuilder.Entity<T>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(size)
                .IsRequired()
                ;
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }
        }


        public static void DefineNonUniqueKey<T>(this ModelBuilder modelBuilder, ref int order,
            int size = TextFieldSizes.X64, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasKey
        {
            modelBuilder.AssignIndex<T>(x => x.Key);

            modelBuilder.Entity<T>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(size)
                .IsRequired()
                ;
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }
        }


        public static void DefineTimestampedRecordStated<T>(
            this ModelBuilder modelBuilder,
            ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTimestamp,
            //IHasInRecordAuditability, 
            IHasRecordState
        {
            modelBuilder.AssignIndex<T>(x => x.RecordState);

            order = DefineTimeStamped<T>(modelBuilder, ref order, injectedPropertyDefs);

            //4:

            modelBuilder.Entity<T>()
                .Property(x => x.RecordState)
                //.HasColumnOrder(order++)
                .IsRequired()
                ;
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            ////5:
            //modelBuilder.Entity<T>()
            //    .Property(x => x.CreatedOnUtc)
            //    //.HasColumnOrder(order++)
            //    .IsRequired(true);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            ////6:
            //modelBuilder.Entity<T>()
            //    .Property(x => x.CreatedByPrincipalId)
            //    //.HasColumnOrder(order++)
            //    .HasMaxLength(TextFieldSizes.GuidStringLength)
            //    .IsRequired(true);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            ////7:


            //modelBuilder.Entity<T>()
            //    .Property(x => x.LastModifiedOnUtc)
            //    //.HasColumnOrder(order++)
            //    .IsRequired(true);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            ////8:
            //modelBuilder.Entity<T>()
            //    .Property(x => x.LastModifiedByPrincipalId)
            //    //.HasColumnOrder(order++)
            //    .HasMaxLength(TextFieldSizes.GuidStringLength)
            //    .IsRequired(true);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            ////9:
            //modelBuilder.Entity<T>()
            //    .Property(x => x.DeletedOnUtc)
            //    //.HasColumnOrder(order++)
            //    .IsRequired(false);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            ////10:
            //modelBuilder.Entity<T>()
            //    .Property(x => x.DeletedByPrincipalId)
            //    //.HasColumnOrder(order++)
            //    .HasMaxLength(TextFieldSizes.GuidStringLength)
            //    .IsRequired(false);
            //if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }

        public static int DefineTimeStamped<T>(this ModelBuilder modelBuilder,
            ref int order,
            Func<int, int> injectedPropertyDefs = null) where T : class,
            IHasTimestamp
        {
            //3:
            modelBuilder.Entity<T>()
                .Property(x => x.Timestamp)
                .IsConcurrencyToken()
                .IsRowVersion()
                //.HasColumnOrder(order++)
                //.IsRequired()
                ;
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            return order;
        }

        public static void DefineRequiredEnabled<T>(this ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasEnabled
        {
            modelBuilder.Entity<T>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired();
        }

        public static void DefineTitleAndDescription<T>(this ModelBuilder modelBuilder, ref int order,
            int fieldSize = TextFieldSizes.X64, bool applyTitleIndex = true, bool descriptionIsMaxLength = false,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTitleAndDescription
        {
            modelBuilder.AssignIndex<T>(x => x.Title);

            modelBuilder.Entity<T>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(fieldSize)
                //.HasColumnAnnotation("Index",
                //    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_Title")
                //    {
                //        IsUnique = false
                //    }))
                .IsRequired()
                ;

            if (applyTitleIndex)
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Title)
                    .IsRequired()
                    ;
            }

            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            if (descriptionIsMaxLength)
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Description)
                    //.HasColumnOrder(order++)
                    //No: .IsMaxLength()
                    .IsRequired(false);
            }
            else
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Description)
                    //.HasColumnOrder(order++)
                    .HasMaxLength(TextFieldSizes.X2048)
                    .IsRequired(false);
            }

            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }
        }

        public static void DefineReferenceData<T>(this ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasReferenceData
        {
            //12:
            modelBuilder.DefineRequiredEnabled<T>(ref order);
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            //-- Might inject keys here...(if order == 12...)

            //13:
            modelBuilder.DefineTitleAndDescription<T>(ref order);
        }


        public static void DefineDisplayableReferenceData<T>(this ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasDisplayableReferenceData
        {
            modelBuilder.DefineReferenceData<T>(ref order, injectedPropertyDefs);

            //14:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayOrderHint)
                //.HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }

            //15:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayStyleHint)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);
            if (injectedPropertyDefs != null)
            {
                order = injectedPropertyDefs.Invoke(order);
            }
        }

        //        public static void DefineStandard(this ModelBuilder modelBuilder, Expression<Func<TDto, object>> func)
        //        {
        //            ((MemberExpression)func.Body).Member.MemberType
        //            Func<TDto, object> p;
        //            p.)
        //            func.
        //            modelBuilder.Entity<Course>()
        //.Property(x => x.Key)
        ////.HasColumnOrder(order++)
        //.IsRequired(true);

        //        }
    }
}