﻿// <auto-generated />
using System;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IPM.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241221170645_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.AffiliatedUnit", b =>
                {
                    b.Property<int>("AffiliatedUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AffiliatedUnitId"));

                    b.Property<string>("AffiliatedUnitName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AffiliatedUnitId");

                    b.ToTable("AffiliatedUnits");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.AidType", b =>
                {
                    b.Property<int>("AidTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AidTypeId"));

                    b.Property<string>("AidTypeName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AidTypeId");

                    b.ToTable("AidTypes");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.ApprovingAgency", b =>
                {
                    b.Property<int>("ApprovingAgencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ApprovingAgencyId"));

                    b.Property<string>("ApprovingAgencyName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ApprovingAgencyId");

                    b.ToTable("ApprovingAgencies");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.AttachedFile", b =>
                {
                    b.Property<int>("AttachedFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AttachedFileId"));

                    b.Property<string>("HopDongThoaThuanMOAFile")
                        .HasColumnType("text");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("ProposalFile")
                        .HasColumnType("text");

                    b.Property<string>("QuyetDinhChoPhepThucHienFile")
                        .HasColumnType("text");

                    b.Property<string>("QuyetDinhGiaoKinhPhiFile")
                        .HasColumnType("text");

                    b.Property<string>("QuyetDinhThanhLapBanQuanLiFile")
                        .HasColumnType("text");

                    b.Property<string>("ThuChapNhanThucHienFile")
                        .HasColumnType("text");

                    b.Property<string>("ToTrinhXinPhepThucHienFile")
                        .HasColumnType("text");

                    b.HasKey("AttachedFileId");

                    b.ToTable("AttachedFiles");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Catalogue", b =>
                {
                    b.Property<int>("CatalogueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CatalogueId"));

                    b.Property<string>("CatalogueName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CatalogueId");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Counterparty", b =>
                {
                    b.Property<int>("CounterpartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CounterpartyId"));

                    b.Property<string>("CounterpartyName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CounterpartyId");

                    b.ToTable("Counterparties");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.CurrencyUnit", b =>
                {
                    b.Property<int>("CurrencyUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CurrencyUnitId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrencyUnitName")
                        .HasColumnType("text");

                    b.HasKey("CurrencyUnitId");

                    b.ToTable("CurrencyUnits");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Participation", b =>
                {
                    b.Property<int>("ParticipationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParticipationId"));

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ParticipationId");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PositionName")
                        .HasColumnType("text");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectId"));

                    b.Property<int>("AffilatedUnitId")
                        .HasColumnType("integer");

                    b.Property<int>("AidType")
                        .HasColumnType("integer");

                    b.Property<int>("ApprovingAgency")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogueId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("Counterparty")
                        .HasColumnType("integer");

                    b.Property<string>("ProjectNameEnglish")
                        .HasColumnType("text");

                    b.Property<string>("ProjectNameVietnamese")
                        .HasColumnType("text");

                    b.Property<string>("ProjectPurpose")
                        .HasColumnType("text");

                    b.Property<int>("SponsorId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.ProjectUpdateLog", b =>
                {
                    b.Property<int>("ProjectUpdateLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectUpdateLogId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectUpdateLogId");

                    b.ToTable("ProjectUpdateLogs");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.ReportedProject", b =>
                {
                    b.Property<int>("ReportedProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReportedProjectId"));

                    b.HasKey("ReportedProjectId");

                    b.ToTable("ReportedProjects");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.Sponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SponsorId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SponsorName")
                        .HasColumnType("text");

                    b.HasKey("SponsorId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("IPM.Infrastructure.EntityFrameworkDataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("AffilatedUnitId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("VerificationValidTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VerifiedCodeEmail")
                        .HasColumnType("integer");

                    b.Property<int>("VerifiedStatus")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
