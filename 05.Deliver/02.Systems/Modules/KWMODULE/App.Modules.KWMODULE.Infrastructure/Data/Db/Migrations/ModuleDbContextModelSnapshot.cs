﻿// <auto-generated />

using System;
using App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Migrations
{
    [DbContext(typeof(ModuleDbContext))]
    internal class ModuleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Modules.KWMODULE.Shared.Models.Entities.Example", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title");

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_Example_RecordState");

                b.ToTable("Examples", "KWMODULE");

                b.HasData(
                    new
                    {
                        Id = new Guid("26a6ed19-2da9-c401-e486-39ee70ad642c"),
                        Description = "Some Description",
                        RecordState = 0,
                        Title = "Some Title"
                    },
                    new
                    {
                        Id = new Guid("e6c7aae8-c7c2-e6ed-7bf6-39ee70ad642c"),
                        RecordState = 0,
                        Title = "Another Title"
                    });
            });

            modelBuilder.Entity("App.Modules.KWMODULE.Shared.Models.Entities.LinkedExample", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("DataClassificationFK");

                b.Property<string>("Description");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp");

                b.Property<string>("Title")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("LinkedExamples", "KWMODULE");

                b.HasData(
                    new
                    {
                        Id = new Guid("926fa677-04ea-dc0d-d523-39ee70ad642d"),
                        DataClassificationFK = 1,
                        Description = "Some Description",
                        RecordState = 0,
                        Title = "Some Title"
                    },
                    new
                    {
                        Id = new Guid("b6509e2e-4058-53c7-258c-39ee70ad642d"),
                        DataClassificationFK = 6,
                        RecordState = 0,
                        Title = "Another Title"
                    });
            });

            modelBuilder.Entity("App.Modules.KWMODULE.Shared.Models.Entities.TenantedExample", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantedExample_RecordState");

                b.ToTable("TenantedExamples", "KWMODULE");

                b.HasData(
                    new
                    {
                        Id = new Guid("ee27bb8d-bf02-cd18-8484-39ee70ad642d"),
                        Description = "Some Description",
                        RecordState = 0,
                        TenantFK = new Guid("00000003-0000-0000-0000-000000000000"),
                        Title = "Some Title"
                    },
                    new
                    {
                        Id = new Guid("c8e49b8c-7393-147d-3ba4-39ee70ad642e"),
                        RecordState = 0,
                        TenantFK = new Guid("00000003-0000-0000-0000-000000000000"),
                        Title = "Another Title"
                    });
            });
#pragma warning restore 612, 618
        }
    }
}