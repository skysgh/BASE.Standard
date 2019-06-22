﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations
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

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.DataClassification", b =>
            {
                b.Property<int>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<int>("DisplayOrderHint");

                b.Property<string>("DisplayStyleHint")
                    .HasMaxLength(64);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_DataClassification_RecordState");

                b.HasIndex("Title")
                    .HasName("IX_DataClassification_Title");

                b.ToTable("DataClassifications", "Core");

                b.HasData(
                    new
                    {
                        Id = 1,
                        DisplayOrderHint = 1,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Unspecified"
                    },
                    new
                    {
                        Id = 2,
                        DisplayOrderHint = 2,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Unclassified"
                    },
                    new
                    {
                        Id = 3,
                        DisplayOrderHint = 3,
                        Enabled = false,
                        RecordState = 0,
                        Title = "In Confidence"
                    },
                    new
                    {
                        Id = 4,
                        DisplayOrderHint = 4,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Sensitive"
                    },
                    new
                    {
                        Id = 5,
                        DisplayOrderHint = 5,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Restricted"
                    },
                    new
                    {
                        Id = 6,
                        DisplayOrderHint = 6,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Confidential"
                    },
                    new
                    {
                        Id = 7,
                        DisplayOrderHint = 7,
                        Enabled = false,
                        RecordState = 0,
                        Title = "Secret"
                    },
                    new
                    {
                        Id = 8,
                        DisplayOrderHint = 8,
                        Enabled = false,
                        RecordState = 0,
                        Title = "TopSecret"
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.DataToken", b =>
            {
                b.Property<Guid>("Id");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(32768);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_DataToken_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_DataToken_TenantFK");

                b.ToTable("DataTokens", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.ExceptionRecord", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("ClientId");

                b.Property<int>("Level");

                b.Property<string>("Message")
                    .IsRequired()
                    .HasMaxLength(32768);

                b.Property<string>("Stack")
                    .IsRequired();

                b.Property<string>("ThreadId");

                b.Property<DateTimeOffset>("UtcDateTimeCreated");

                b.HasKey("Id");

                b.ToTable("ExceptionRecords", "Core");

                b.HasData(
                    new
                    {
                        Id = new Guid("00000001-0000-0000-0000-000000000000"),
                        Level = 3,
                        Message = "Installation of System occurred on: 6/16/2019 10:06:23 AM +00:00",
                        Stack = "",
                        UtcDateTimeCreated =
                            new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                                new TimeSpan(0, 0, 0, 0, 0))
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.MediaMetadata", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("ContentHash")
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property<long>("ContentSize");

                b.Property<int>("DataClassificationFK");

                b.Property<DateTimeOffset?>("LatestScanDateTimeUtc");

                b.Property<bool?>("LatestScanMalwareDetetected");

                b.Property<string>("LatestScanResults");

                b.Property<string>("LocalName")
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property<string>("MimeType")
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property<int>("RecordState");

                b.Property<string>("SourceFileName")
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<DateTime>("UploadedDateTimeUtc");

                b.HasKey("Id");

                b.HasAlternateKey("LocalName")
                    .HasName("IX_MediaMetadata_LocalName");

                b.HasIndex("ContentHash")
                    .HasName("IX_MediaMetadata_ContentHash");

                b.HasIndex("DataClassificationFK");

                b.HasIndex("RecordState")
                    .HasName("IX_MediaMetadata_RecordState");

                b.HasIndex("SourceFileName")
                    .HasName("IX_MediaMetadata_SourceFileName");

                b.ToTable("MediaMetadatas", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Notification", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Class")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<DateTime>("DateTimeCreatedUtc");

                b.Property<DateTimeOffset?>("DateTimeReadUtc");

                b.Property<string>("From")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<string>("ImageUrl")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<int>("Level");

                b.Property<Guid>("PrincipalFK");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<string>("Text")
                    .IsRequired()
                    .IsFixedLength(false);

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<int>("Type");

                b.Property<int>("Value");

                b.HasKey("Id");

                b.HasIndex("From")
                    .HasName("IX_Notification_From");

                b.HasIndex("PrincipalFK")
                    .HasName("IX_Notification_PrincipalFK");

                b.HasIndex("RecordState")
                    .HasName("IX_Notification_RecordState");

                b.ToTable("Notifications", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Principal", b =>
            {
                b.Property<Guid>("Id");

                b.Property<Guid>("CategoryFK");

                b.Property<int>("DataClassificationFK");

                b.Property<string>("DisplayName")
                    .HasMaxLength(128);

                b.Property<bool>("Enabled");

                b.Property<DateTimeOffset?>("EnabledBeginningUtcDateTime");

                b.Property<DateTimeOffset?>("EnabledEndingUtcDateTime");

                b.Property<string>("FullName")
                    .HasMaxLength(128);

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasIndex("CategoryFK");

                b.HasIndex("DataClassificationFK");

                b.HasIndex("RecordState")
                    .HasName("IX_Principal_RecordState");

                b.ToTable("Principals", "Core");

                b.HasData(
                    new
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000000"),
                        CategoryFK = new Guid("00000003-0000-0000-0000-000000000000"),
                        DataClassificationFK = 2,
                        DisplayName = "Anon",
                        Enabled = true,
                        RecordState = 0
                    },
                    new
                    {
                        Id = new Guid("00000001-0000-0000-0000-000000000000"),
                        CategoryFK = new Guid("00000002-0000-0000-0000-000000000000"),
                        DataClassificationFK = 2,
                        DisplayName = "Anon",
                        Enabled = true,
                        RecordState = 0
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalCategory", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description");

                b.Property<int>("DisplayOrderHint");

                b.Property<string>("DisplayStyleHint");

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title");

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_PrincipalCategory_RecordState");

                b.ToTable("PrincipalCategories", "Core");

                b.HasData(
                    new
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000000"),
                        Description = "An error state as Principal type is not defined.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "Unspecified"
                    },
                    new
                    {
                        Id = new Guid("00000001-0000-0000-0000-000000000000"),
                        Description = "An error state as Principal type is unclear.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "Unknown"
                    },
                    new
                    {
                        Id = new Guid("00000002-0000-0000-0000-000000000000"),
                        Description = "This system.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "System"
                    },
                    new
                    {
                        Id = new Guid("00000003-0000-0000-0000-000000000000"),
                        Description = "A remote service or user.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "Default"
                    },
                    new
                    {
                        Id = new Guid("00000004-0000-0000-0000-000000000000"),
                        Description = "A remote service (whether owned by organisation or other.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "Service"
                    },
                    new
                    {
                        Id = new Guid("00000005-0000-0000-0000-000000000000"),
                        Description = "General users.",
                        DisplayOrderHint = 0,
                        Enabled = true,
                        RecordState = 0,
                        Title = "User"
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalClaim", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Authority")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<string>("AuthoritySignature")
                    .IsRequired()
                    .HasMaxLength(32768);

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<Guid>("PrincipalFK");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Value")
                    .HasMaxLength(1024);

                b.HasKey("Id");

                b.HasIndex("Authority")
                    .HasName("IX_PrincipalClaim_Authority");

                b.HasIndex("Key")
                    .HasName("IX_PrincipalClaim_Key");

                b.HasIndex("PrincipalFK");

                b.HasIndex("RecordState")
                    .HasName("IX_PrincipalClaim_RecordState");

                b.ToTable("PrincipalClaims", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalLogin", b =>
            {
                b.Property<Guid>("Id");

                b.Property<bool>("Enabled");

                b.Property<string>("IdPLogin")
                    .IsRequired()
                    .HasMaxLength(1024);

                b.Property<DateTime>("LastLoggedInUtc");

                b.Property<Guid>("PrincipalFK");

                b.Property<int>("RecordState");

                b.Property<string>("SubLogin")
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasAlternateKey("IdPLogin", "SubLogin")
                    .HasName("IX_PrincipalLogin_IdpLoginSubLogin");

                b.HasIndex("PrincipalFK");

                b.HasIndex("RecordState")
                    .HasName("IX_PrincipalLogin_RecordState");

                b.ToTable("PrincipalLogins", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalProperty", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<Guid>("PrincipalFK");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Value")
                    .HasMaxLength(1024);

                b.HasKey("Id");

                b.HasIndex("Key")
                    .HasName("IX_PrincipalProperty_Key");

                b.HasIndex("PrincipalFK");

                b.HasIndex("RecordState")
                    .HasName("IX_PrincipalProperty_RecordState");

                b.ToTable("PrincipalProperties", "Core");

                b.HasData(
                    new
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000000"),
                        Key = "Description",
                        PrincipalFK = new Guid("00000000-0000-0000-0000-000000000000"),
                        RecordState = 0,
                        Value = "Principal shared by all unauthenticated users, but with distinct Sessions."
                    },
                    new
                    {
                        Id = new Guid("00000001-0000-0000-0000-000000000000"),
                        Key = "FavoriteSong",
                        PrincipalFK = new Guid("00000000-0000-0000-0000-000000000000"),
                        RecordState = 0,
                        Value = "https://www.youtube.com/watch?v=B1BdQcJ2ZYY"
                    },
                    new
                    {
                        Id = new Guid("00000002-0000-0000-0000-000000000000"),
                        Key = "Seeking",
                        PrincipalFK = new Guid("00000000-0000-0000-0000-000000000000"),
                        RecordState = 0,
                        Value = "Romance (what?! You think computers can't dream?!)."
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalTag", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description");

                b.Property<int>("DisplayOrderHint");

                b.Property<string>("DisplayStyleHint")
                    .HasMaxLength(64);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_PrincipalTag_RecordState");

                b.HasIndex("Title")
                    .HasName("IX_PrincipalTag_Title");

                b.ToTable("PrincipalTags", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalTagAssignment", b =>
            {
                b.Property<Guid>("PrincipalFK");

                b.Property<Guid>("TagFK");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp");

                b.HasKey("PrincipalFK", "TagFK");

                b.HasIndex("TagFK");

                b.ToTable("PrincipalTagAssignments", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Session", b =>
            {
                b.Property<Guid>("Id");

                b.Property<bool>("Enabled");

                b.Property<Guid>("PrincipalFK");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("UniqueIdentifier")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<DateTimeOffset>("UtcDateTimeCreated");

                b.HasKey("Id");

                b.HasAlternateKey("UniqueIdentifier")
                    .HasName("IX_Session_UniqueIdentifier");

                b.HasIndex("PrincipalFK");

                b.HasIndex("RecordState")
                    .HasName("IX_Session_RecordState");

                b.ToTable("Sessions", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.SessionOperation", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("ActionArguments")
                    .IsRequired();

                b.Property<string>("ActionName")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<DateTimeOffset?>("BeginDateTimeUtc")
                    .IsRequired();

                b.Property<string>("ClientIp")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<string>("ControllerName")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<TimeSpan>("Duration");

                b.Property<DateTimeOffset?>("EndDateTimeUtc")
                    .IsRequired();

                b.Property<int>("RecordState");

                b.Property<string>("ResourceTenantKey");

                b.Property<string>("ResponseCode")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<Guid?>("SessionFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Url")
                    .IsRequired()
                    .HasMaxLength(32768);

                b.HasKey("Id");

                b.HasIndex("ActionName")
                    .HasName("IX_SessionOperation_ActionName");

                b.HasIndex("ControllerName")
                    .HasName("IX_SessionOperation_ControllerName");

                b.HasIndex("RecordState")
                    .HasName("IX_SessionOperation_RecordState");

                b.HasIndex("SessionFK");

                b.ToTable("SessionOperations", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.SystemRole", b =>
            {
                b.Property<Guid>("Id");

                b.Property<int>("DataClassificationFK");

                b.Property<bool>("Enabled");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<string>("ModuleKey");

                b.Property<Guid?>("PrincipalId");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasIndex("DataClassificationFK");

                b.HasIndex("Key")
                    .HasName("IX_SystemRole_Key");

                b.HasIndex("PrincipalId");

                b.HasIndex("RecordState")
                    .HasName("IX_SystemRole_RecordState");

                b.ToTable("SystemRoles", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Tenant", b =>
            {
                b.Property<Guid>("Id");

                b.Property<int>("DataClassificationFK");

                b.Property<string>("DisplayName")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<bool>("Enabled");

                b.Property<string>("HostName")
                    .HasMaxLength(64);

                b.Property<bool?>("IsDefault");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasIndex("DataClassificationFK");

                b.HasIndex("DisplayName")
                    .HasName("IX_Tenant_DisplayName");

                b.HasIndex("Key")
                    .HasName("IX_Tenant_Key");

                b.HasIndex("RecordState")
                    .HasName("IX_Tenant_RecordState");

                b.ToTable("Tenants", "Core");

                b.HasData(
                    new
                    {
                        Id = new Guid("00000001-0000-0000-0000-000000000000"),
                        DataClassificationFK = 2,
                        DisplayName = "Default",
                        Enabled = true,
                        HostName = "Default",
                        IsDefault = true,
                        Key = "Default",
                        RecordState = 0
                    });
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantClaim", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Authority")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<string>("AuthoritySignature")
                    .IsRequired()
                    .HasMaxLength(1024);

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Value")
                    .HasMaxLength(1024);

                b.HasKey("Id");

                b.HasIndex("Authority")
                    .HasName("IX_TenantClaim_Authority");

                b.HasIndex("Key")
                    .HasName("IX_TenantClaim_Key");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantClaim_RecordState");

                b.HasIndex("TenantFK");

                b.ToTable("TenantClaims", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile", b =>
            {
                b.Property<Guid>("Id");

                b.Property<Guid>("CategoryFK");

                b.Property<int?>("DataClassificationFK");

                b.Property<string>("DisplayName");

                b.Property<bool>("Enabled");

                b.Property<DateTimeOffset?>("EnabledBeginningUtcDateTime");

                b.Property<DateTimeOffset?>("EnabledEndingUtcDateTime");

                b.Property<int>("RecordState");

                b.Property<Guid>("SecurityProfileFK");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasIndex("CategoryFK");

                b.HasIndex("DataClassificationFK");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantMemberProfile_RecordState");

                b.HasIndex("SecurityProfileFK");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantMemberProfile_TenantFK");

                b.ToTable("TenantMemberProfiles", "Core");
            });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile2TagAssignment", b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("TenantPrincipalFK");

                    b.Property<Guid>("TagFK");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp");

                    b.HasKey("TenantFK", "TenantPrincipalFK", "TagFK");

                    b.HasIndex("TagFK");

                    b.HasIndex("TenantPrincipalFK");

                    b.ToTable("TenantMemberProfile2TagAssignments", "Core");
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileCategory", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Description");

                    b.Property<int>("DisplayOrderHint");

                    b.Property<string>("DisplayStyleHint");

                    b.Property<bool>("Enabled");

                    b.Property<int>("RecordState");

                    b.Property<Guid>("TenantFK");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantMemberProfileCategory_RecordState");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantMemberProfileCategory_TenantFK");

                    b.ToTable("TenantMemberProfileCategories", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileClaim",
                b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Authority")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("AuthoritySignature")
                        .IsRequired()
                        .HasMaxLength(32768);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("PrincipalProfileFK");

                    b.Property<int>("RecordState");

                    b.Property<Guid>("TenantFK");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Value")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasAlternateKey("PrincipalProfileFK", "Key")
                        .HasName("IX_TenantMemberProfileClaim_CompositeIndex");

                    b.HasIndex("Authority")
                        .HasName("IX_TenantMemberProfileClaim_Authority");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantMemberProfileClaim_RecordState");

                    b.ToTable("TenantMemberProfileClaims", "Core");
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileProperty", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("PrincipalProfileFK");

                    b.Property<int>("RecordState");

                    b.Property<Guid>("TenantFK");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Value")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasAlternateKey("PrincipalProfileFK", "Key")
                        .HasName("IX_TenantMemberProfileProperty_CompositeIndex");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantMemberProfileProperty_RecordState");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantMemberProfileProperty_TenantFK");

                    b.ToTable("TenantMemberProfileProperties", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileTag",
                b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Description");

                    b.Property<int>("DisplayOrderHint");

                    b.Property<string>("DisplayStyleHint")
                        .HasMaxLength(64);

                    b.Property<bool>("Enabled");

                    b.Property<int>("RecordState");

                    b.Property<Guid>("TenantFK");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantMemberProfileTag_RecordState");

                    b.HasIndex("Title")
                        .HasName("IX_TenantMemberProfileTag_Title");

                    b.ToTable("TenantMemberProfileTags", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMemberSecurityProfile", b =>
            {
                b.Property<Guid>("Id");

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<Guid>("SecurityProfileFK");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantMemberSecurityProfile_RecordState");

                b.HasIndex("SecurityProfileFK");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantMemberSecurityProfile_TenantFK");

                b.ToTable("TenantMemberSecurityProfiles", "Core");
            });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMemberSecurityProfile2PermissionAssignment", b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("MemberFK");

                    b.Property<Guid>("PermissionFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "MemberFK", "PermissionFK");

                    b.HasIndex("MemberFK");

                    b.HasIndex("PermissionFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantMemberSecurityProfile2PermissionAssignment_RecordState");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantMemberSecurityProfile2PermissionAssignment_TenantFK");

                    b.ToTable("TenantMemberSecurityProfile2PermissionAssignments", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantProperty", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(64);

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Value")
                    .HasMaxLength(1024);

                b.HasKey("Id");

                b.HasIndex("Key")
                    .HasName("IX_TenantProperty_Key");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantProperty_RecordState");

                b.HasIndex("TenantFK");

                b.ToTable("TenantProperties", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfile_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfile_TenantFK");

                b.HasIndex("Title")
                    .HasName("IX_TenantSecurityProfile_Title");

                b.ToTable("TenantSecurityProfiles", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2PermissionAssignment",
                b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("ProfileFK");

                    b.Property<Guid>("PermissionFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "ProfileFK", "PermissionFK");

                    b.HasIndex("PermissionFK");

                    b.HasIndex("ProfileFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantSecurityProfile2PermissionAssignment_RecordState");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantSecurityProfile2PermissionAssignment_TenantFK");

                    b.ToTable("TenantSecurityProfile2PermissionAssignments", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2RoleAssignment", b =>
            {
                b.Property<Guid>("TenantFK");

                b.Property<Guid>("ProfileFK");

                b.Property<Guid>("RoleFK");

                b.Property<int>("AssignmentType");

                b.Property<int>("RecordState");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.HasKey("TenantFK", "ProfileFK", "RoleFK");

                b.HasIndex("ProfileFK");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfile2RoleAssignment_RecordState");

                b.HasIndex("RoleFK");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfile2RoleAssignment_TenantFK");

                b.ToTable("TenantSecurityProfile2RoleAssignments", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2RoleGroupAssignment",
                b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("ProfileFK");

                    b.Property<Guid>("RoleGroupFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "ProfileFK", "RoleGroupFK");

                    b.HasIndex("ProfileFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantSecurityProfile2RoleGroupAssignment_RecordState");

                    b.HasIndex("RoleGroupFK");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantSecurityProfile2RoleGroupAssignment_TenantFK");

                    b.ToTable("TenantSecurityProfile2RoleGroupAssignments", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfilePermission", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfilePermission_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfilePermission_TenantFK");

                b.HasIndex("Title")
                    .HasName("IX_TenantSecurityProfilePermission_Title");

                b.ToTable("TenantSecurityProfilePermissions", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileResponsibility", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfileResponsibility_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfileResponsibility_TenantFK");

                b.HasIndex("Title")
                    .HasName("IX_TenantSecurityProfileResponsibility_Title");

                b.ToTable("TenantSecurityProfileResponsibilities", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<bool>("Enabled");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfileRole_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfileRole_TenantFK");

                b.HasIndex("Title")
                    .HasName("IX_TenantSecurityProfileRole_Title");

                b.ToTable("TenantSecurityProfileRoles", "Core");
            });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole2PermissionAssignment", b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("RoleFK");

                    b.Property<Guid>("PermissionFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "RoleFK", "PermissionFK");

                    b.HasIndex("PermissionFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantSecurityProfileRole2PermissionAssignment_RecordState");

                    b.HasIndex("RoleFK");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantSecurityProfileRole2PermissionAssignment_TenantFK");

                    b.ToTable("TenantSecurityProfileRole2PermissionAssignments", "Core");
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole2ResponsibilityAssignment", b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("RoleFK");

                    b.Property<Guid>("ResponsibilityFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "RoleFK", "ResponsibilityFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantSecurityProfileRole2ResponsibilityAssignment_RecordState");

                    b.HasIndex("ResponsibilityFK");

                    b.HasIndex("RoleFK");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantSecurityProfileRole2ResponsibilityAssignment_TenantFK");

                    b.ToTable("TenantSecurityProfileRole2ResponsibilityAssignments", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup", b =>
            {
                b.Property<Guid>("Id");

                b.Property<string>("Description")
                    .HasMaxLength(32768);

                b.Property<bool>("Enabled");

                b.Property<Guid?>("ParentFK");

                b.Property<Guid?>("ParentId");

                b.Property<int>("RecordState");

                b.Property<Guid>("TenantFK");

                b.Property<byte[]>("Timestamp")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate();

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(64);

                b.HasKey("Id");

                b.HasIndex("ParentId");

                b.HasIndex("RecordState")
                    .HasName("IX_TenantSecurityProfileRoleGroup_RecordState");

                b.HasIndex("TenantFK")
                    .HasName("IX_TenantSecurityProfileRoleGroup_TenantFK");

                b.HasIndex("Title")
                    .HasName("IX_TenantSecurityProfileRoleGroup_Title");

                b.ToTable("TenantSecurityProfileRoleGroups", "Core");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup2RoleAssignment",
                b =>
                {
                    b.Property<Guid>("TenantFK");

                    b.Property<Guid>("GroupFK");

                    b.Property<Guid>("RoleFK");

                    b.Property<int>("AssignmentType");

                    b.Property<int>("RecordState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TenantFK", "GroupFK", "RoleFK");

                    b.HasIndex("GroupFK");

                    b.HasIndex("RecordState")
                        .HasName("IX_TenantSecurityProfileRoleGroup2RoleAssignment_RecordState");

                    b.HasIndex("RoleFK");

                    b.HasIndex("TenantFK")
                        .HasName("IX_TenantSecurityProfileRoleGroup2RoleAssignment_TenantFK");

                    b.ToTable("TenantSecurityProfileRoleGroup2RoleAssignments", "Core");
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.MediaMetadata", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.DataClassification", "DataClassification")
                    .WithMany()
                    .HasForeignKey("DataClassificationFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Principal", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.PrincipalCategory", "Category")
                    .WithMany()
                    .HasForeignKey("CategoryFK")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("App.Modules.Core.Shared.Models.Entities.DataClassification", "DataClassification")
                    .WithMany()
                    .HasForeignKey("DataClassificationFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalClaim", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal")
                    .WithMany("Claims")
                    .HasForeignKey("PrincipalFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalLogin", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal")
                    .WithMany("Logins")
                    .HasForeignKey("PrincipalFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalProperty", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal")
                    .WithMany("Properties")
                    .HasForeignKey("PrincipalFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.PrincipalTagAssignment", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal", "Principal")
                    .WithMany("TagAssignment")
                    .HasForeignKey("PrincipalFK")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("App.Modules.Core.Shared.Models.Entities.PrincipalTag", "Tag")
                    .WithMany()
                    .HasForeignKey("TagFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Session", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal", "Principal")
                    .WithMany()
                    .HasForeignKey("PrincipalFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.SessionOperation", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Session")
                    .WithMany("Operations")
                    .HasForeignKey("SessionFK");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.SystemRole", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.DataClassification", "DataClassification")
                    .WithMany()
                    .HasForeignKey("DataClassificationFK")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("App.Modules.Core.Shared.Models.Entities.Principal")
                    .WithMany("Roles")
                    .HasForeignKey("PrincipalId");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.Tenant", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.DataClassification", "DataClassification")
                    .WithMany()
                    .HasForeignKey("DataClassificationFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantClaim", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Tenant")
                    .WithMany("Claims")
                    .HasForeignKey("TenantFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileCategory",
                        "Category")
                    .WithMany()
                    .HasForeignKey("CategoryFK")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("App.Modules.Core.Shared.Models.Entities.DataClassification", "DataClassification")
                    .WithMany()
                    .HasForeignKey("DataClassificationFK");

                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", "SecurityProfile")
                    .WithMany()
                    .HasForeignKey("SecurityProfileFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile2TagAssignment", b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileTag",
                            "Tag")
                        .WithMany()
                        .HasForeignKey("TagFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile",
                            "TenantPrincipal")
                        .WithMany("TagAssignments")
                        .HasForeignKey("TenantPrincipalFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileClaim",
                b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile")
                        .WithMany("Claims")
                        .HasForeignKey("PrincipalProfileFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfileProperty", b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile")
                        .WithMany("Properties")
                        .HasForeignKey("PrincipalProfileFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantMemberSecurityProfile", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", "SecurityProfile")
                    .WithMany()
                    .HasForeignKey("SecurityProfileFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantMemberSecurityProfile2PermissionAssignment", b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantMemberSecurityProfile", "Member")
                        .WithMany("PermissionsAssignments")
                        .HasForeignKey("MemberFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfilePermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantProperty", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.Tenant")
                    .WithMany("Properties")
                    .HasForeignKey("TenantFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2PermissionAssignment",
                b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfilePermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", "Profile")
                        .WithMany("PermissionsAssignments")
                        .HasForeignKey("ProfileFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2RoleAssignment", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", "Profile")
                    .WithMany("RoleAssignents")
                    .HasForeignKey("ProfileFK")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole", "Role")
                    .WithMany()
                    .HasForeignKey("RoleFK")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile2RoleGroupAssignment",
                b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfile", "Profile")
                        .WithMany("RoleGroupAssignments")
                        .HasForeignKey("ProfileFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup", "RoleGroup")
                        .WithMany()
                        .HasForeignKey("RoleGroupFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole2PermissionAssignment", b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfilePermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole", "Role")
                        .WithMany("PermissionsAssignments")
                        .HasForeignKey("RoleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity(
                "App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole2ResponsibilityAssignment", b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileResponsibility",
                            "Responsibility")
                        .WithMany()
                        .HasForeignKey("ResponsibilityFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole", "Role")
                        .WithMany("ResponsibilityAssignments")
                        .HasForeignKey("RoleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup", b =>
            {
                b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup", "Parent")
                    .WithMany()
                    .HasForeignKey("ParentId");
            });

            modelBuilder.Entity("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup2RoleAssignment",
                b =>
                {
                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRoleGroup", "Group")
                        .WithMany("RoleAssignments")
                        .HasForeignKey("GroupFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Modules.Core.Shared.Models.Entities.TenantSecurityProfileRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}