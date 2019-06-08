﻿// <auto-generated />
using System;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations
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

            modelBuilder.Entity("App.Modules.Design.Shared.Models.Entities.Example", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("DataClassificationFK");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("RecordState")
                        .HasName("IX_Example_RecordState");

                    b.ToTable("Examples","Design");

                    b.HasData(
                        new
                        {
                            Id = new Guid("212f49e5-572c-018e-9aa8-39ee47b592b8"),
                            DataClassificationFK = 1,
                            RecordState = 0
                        },
                        new
                        {
                            Id = new Guid("092f23e0-8dd1-6119-59d5-39ee47b592b9"),
                            DataClassificationFK = 6,
                            RecordState = 0
                        });
                });

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