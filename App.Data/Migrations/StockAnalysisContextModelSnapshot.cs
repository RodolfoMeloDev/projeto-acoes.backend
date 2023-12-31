﻿// <auto-generated />
using System;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Data.Migrations
{
    [DbContext(typeof(StockAnalysisContext))]
    partial class StockAnalysisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Entities.BaseTickerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("BaseTicker")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SegmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("BaseTickers");
                });

            modelBuilder.Entity("App.Domain.Entities.FileImportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateFile")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TypeFile")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FileImports");
                });

            modelBuilder.Entity("App.Domain.Entities.HistoryTickerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("AverageDailyLiquidity")
                        .HasColumnType("numeric");

                    b.Property<decimal>("AverageGrowth")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("DividendYield")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Dpa")
                        .HasColumnType("numeric");

                    b.Property<decimal>("EbitMargin")
                        .HasColumnType("numeric");

                    b.Property<decimal>("EvEbit")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ExpectedGrowth")
                        .HasColumnType("numeric");

                    b.Property<int>("FileImportId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Lpa")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("MarketValue")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Payout")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceByProfit")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("ProfitCAGR")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Pvp")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Roe")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Roic")
                        .HasColumnType("numeric");

                    b.Property<int>("TickerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Vpa")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FileImportId");

                    b.HasIndex("TickerId");

                    b.ToTable("HistoryTickers");
                });

            modelBuilder.Entity("App.Domain.Entities.SectorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("App.Domain.Entities.SegmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SubSectorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubSectorId");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("App.Domain.Entities.SubSectorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("SubSectors");
                });

            modelBuilder.Entity("App.Domain.Entities.TickerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("BaseTickerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("JudicialRecovery")
                        .HasColumnType("boolean");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("TypeTicker")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BaseTickerId");

                    b.ToTable("Tickers");
                });

            modelBuilder.Entity("App.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateCreated")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NickName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateTime?>("RefreshTokenExpiration")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Entities.BaseTickerEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.SegmentEntity", "Segment")
                        .WithMany()
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("App.Domain.Entities.FileImportEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Entities.HistoryTickerEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.FileImportEntity", "FileImport")
                        .WithMany()
                        .HasForeignKey("FileImportId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.TickerEntity", "Ticker")
                        .WithMany()
                        .HasForeignKey("TickerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FileImport");

                    b.Navigation("Ticker");
                });

            modelBuilder.Entity("App.Domain.Entities.SegmentEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.SubSectorEntity", "SubSector")
                        .WithMany("Segments")
                        .HasForeignKey("SubSectorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SubSector");
                });

            modelBuilder.Entity("App.Domain.Entities.SubSectorEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.SectorEntity", "Sector")
                        .WithMany("SubSectors")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("App.Domain.Entities.TickerEntity", b =>
                {
                    b.HasOne("App.Domain.Entities.BaseTickerEntity", "BaseTicker")
                        .WithMany()
                        .HasForeignKey("BaseTickerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BaseTicker");
                });

            modelBuilder.Entity("App.Domain.Entities.SectorEntity", b =>
                {
                    b.Navigation("SubSectors");
                });

            modelBuilder.Entity("App.Domain.Entities.SubSectorEntity", b =>
                {
                    b.Navigation("Segments");
                });
#pragma warning restore 612, 618
        }
    }
}
