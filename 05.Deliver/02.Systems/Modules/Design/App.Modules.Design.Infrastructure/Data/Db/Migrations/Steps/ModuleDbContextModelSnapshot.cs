﻿// <auto-generated />
using System;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations.Steps
{
    [DbContext(typeof(ModuleDbContext))]
    partial class ModuleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Modules.Design.Shared.Models.Entities.NonTenantSpecific.Requirement", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Description");

                    b.Property<int>("ISO25010Quality");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(32768);

                    b.HasKey("Id");

                    b.HasIndex("ISO25010Quality")
                        .HasName("IX_Requirement_ISO25010Quality");

                    b.HasIndex("RecordState")
                        .HasName("IX_Requirement_RecordState");

                    b.ToTable("Requirements","Design");
                });
#pragma warning restore 612, 618
        }
    }
}
