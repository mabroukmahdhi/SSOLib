﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Data.EF.Migrations
{
    [DbContext(typeof(SSODbContext))]
    [Migration("20220328163537_AddRolesAndPrivs")]
    partial class AddRolesAndPrivs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Objects.Entities.Audit.AuditDataItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuditEntryId")
                        .HasColumnType("int");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuditEntryId");

                    b.ToTable("AuditDataItems", "Audit");
                });

            modelBuilder.Entity("Core.Objects.Entities.Audit.AuditEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("TimeOfEvent")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditEntries", "Audit");
                });

            modelBuilder.Entity("Core.Objects.Entities.Logging.LogDataItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LogEntryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LogEntryId");

                    b.ToTable("LogDataItems", "Logging");
                });

            modelBuilder.Entity("Core.Objects.Entities.Logging.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogEntries", "Logging");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSOPrivilege", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PortalAdminsOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Privileges");

                    b.HasData(
                        new
                        {
                            Id = "token_create",
                            Description = "Allows users to Create Tokens.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "Token"
                        },
                        new
                        {
                            Id = "token_read",
                            Description = "Allows users to Read Tokens.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "Token"
                        },
                        new
                        {
                            Id = "token_update",
                            Description = "Allows users to Update Tokens.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "Token"
                        },
                        new
                        {
                            Id = "token_delete",
                            Description = "Allows users to Delete Tokens.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "Token"
                        },
                        new
                        {
                            Id = "auditentry_create",
                            Description = "Allows users to Create AuditEntrys.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "AuditEntry"
                        },
                        new
                        {
                            Id = "auditentry_read",
                            Description = "Allows users to Read AuditEntrys.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "AuditEntry"
                        },
                        new
                        {
                            Id = "auditentry_update",
                            Description = "Allows users to Update AuditEntrys.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "AuditEntry"
                        },
                        new
                        {
                            Id = "auditentry_delete",
                            Description = "Allows users to Delete AuditEntrys.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "AuditEntry"
                        },
                        new
                        {
                            Id = "auditdataitem_create",
                            Description = "Allows users to Create AuditDataItems.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "AuditDataItem"
                        },
                        new
                        {
                            Id = "auditdataitem_read",
                            Description = "Allows users to Read AuditDataItems.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "AuditDataItem"
                        },
                        new
                        {
                            Id = "auditdataitem_update",
                            Description = "Allows users to Update AuditDataItems.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "AuditDataItem"
                        },
                        new
                        {
                            Id = "auditdataitem_delete",
                            Description = "Allows users to Delete AuditDataItems.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "AuditDataItem"
                        },
                        new
                        {
                            Id = "logentry_create",
                            Description = "Allows users to Create LogEntrys.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "LogEntry"
                        },
                        new
                        {
                            Id = "logentry_read",
                            Description = "Allows users to Read LogEntrys.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "LogEntry"
                        },
                        new
                        {
                            Id = "logentry_update",
                            Description = "Allows users to Update LogEntrys.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "LogEntry"
                        },
                        new
                        {
                            Id = "logentry_delete",
                            Description = "Allows users to Delete LogEntrys.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "LogEntry"
                        },
                        new
                        {
                            Id = "logdataitem_create",
                            Description = "Allows users to Create LogDataItems.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "LogDataItem"
                        },
                        new
                        {
                            Id = "logdataitem_read",
                            Description = "Allows users to Read LogDataItems.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "LogDataItem"
                        },
                        new
                        {
                            Id = "logdataitem_update",
                            Description = "Allows users to Update LogDataItems.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "LogDataItem"
                        },
                        new
                        {
                            Id = "logdataitem_delete",
                            Description = "Allows users to Delete LogDataItems.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "LogDataItem"
                        },
                        new
                        {
                            Id = "ssouser_create",
                            Description = "Allows users to Create SSOUsers.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "SSOUser"
                        },
                        new
                        {
                            Id = "ssouser_read",
                            Description = "Allows users to Read SSOUsers.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "SSOUser"
                        },
                        new
                        {
                            Id = "ssouser_update",
                            Description = "Allows users to Update SSOUsers.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "SSOUser"
                        },
                        new
                        {
                            Id = "ssouser_delete",
                            Description = "Allows users to Delete SSOUsers.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "SSOUser"
                        },
                        new
                        {
                            Id = "ssorole_create",
                            Description = "Allows users to Create SSORoles.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "SSORole"
                        },
                        new
                        {
                            Id = "ssorole_read",
                            Description = "Allows users to Read SSORoles.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "SSORole"
                        },
                        new
                        {
                            Id = "ssorole_update",
                            Description = "Allows users to Update SSORoles.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "SSORole"
                        },
                        new
                        {
                            Id = "ssorole_delete",
                            Description = "Allows users to Delete SSORoles.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "SSORole"
                        },
                        new
                        {
                            Id = "ssoprivilege_create",
                            Description = "Allows users to Create SSOPrivileges.",
                            Operation = "Create",
                            PortalAdminsOnly = false,
                            Type = "SSOPrivilege"
                        },
                        new
                        {
                            Id = "ssoprivilege_read",
                            Description = "Allows users to Read SSOPrivileges.",
                            Operation = "Read",
                            PortalAdminsOnly = false,
                            Type = "SSOPrivilege"
                        },
                        new
                        {
                            Id = "ssoprivilege_update",
                            Description = "Allows users to Update SSOPrivileges.",
                            Operation = "Update",
                            PortalAdminsOnly = false,
                            Type = "SSOPrivilege"
                        },
                        new
                        {
                            Id = "ssoprivilege_delete",
                            Description = "Allows users to Delete SSOPrivileges.",
                            Operation = "Delete",
                            PortalAdminsOnly = false,
                            Type = "SSOPrivilege"
                        });
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSORole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsersArePortalAdmins")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSOUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSOUserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Core.Objects.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTimeOffset>("Expires")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Reason")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Core.Objects.Entities.Audit.AuditDataItem", b =>
                {
                    b.HasOne("Core.Objects.Entities.Audit.AuditEntry", "AuditEntry")
                        .WithMany("Changes")
                        .HasForeignKey("AuditEntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AuditEntry");
                });

            modelBuilder.Entity("Core.Objects.Entities.Logging.LogDataItem", b =>
                {
                    b.HasOne("Core.Objects.Entities.Logging.LogEntry", "LogEntry")
                        .WithMany("Data")
                        .HasForeignKey("LogEntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LogEntry");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSOUserRole", b =>
                {
                    b.HasOne("Core.Objects.Entities.Security.SSORole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Objects.Entities.Security.SSOUser", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Objects.Entities.Audit.AuditEntry", b =>
                {
                    b.Navigation("Changes");
                });

            modelBuilder.Entity("Core.Objects.Entities.Logging.LogEntry", b =>
                {
                    b.Navigation("Data");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSORole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Core.Objects.Entities.Security.SSOUser", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}