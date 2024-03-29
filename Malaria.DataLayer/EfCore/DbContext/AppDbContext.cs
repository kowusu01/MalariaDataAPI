﻿using Microsoft.EntityFrameworkCore;

using Common.Models;
using Common.Models.Malaria;

namespace EfCoreLayer.MalariaData
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EnvInfo> EnvInfos { get; set; } = null!;

        public virtual DbSet<ReportedData> ReportedData { get; set; } = null!;
        public virtual DbSet<LoadStat> LoadStats { get; set; } = null!;
        //public virtual DbSet<CasesReportedBad> CasesReportedBads { get; set; } = null!;
        public virtual DbSet<DataIssuesDetail> DataIssuesDetails { get; set; } = null!;               

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region EXCLUDE
            /*
            modelBuilder.Entity<CasesReportedBad>(entity =>
            {
                entity.ToTable("cases_reported_bad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Year)
                    .HasMaxLength(255)
                    .HasColumnName("year");

                entity.Property(e => e.LoadId)
                    .HasColumnName("load_id");

                entity.Property(e => e.RecordNumber)
                    .HasColumnName("record_number");

                entity.Property(e => e.NumCases)
                    .HasMaxLength(255)
                    .HasColumnName("num_cases");

                entity.Property(e => e.NumDeaths)
                    .HasMaxLength(255)
                    .HasColumnName("num_deaths");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("region");

            });
            */
            #endregion EXCLUDE

            modelBuilder.Entity<ReportedData>(entity =>
            {
                entity.ToTable("reported_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.LoadId)
                    .HasColumnName("load_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Year)
                    .HasColumnName("year");

                entity.Property(e => e.RecordNumber)
                    .HasColumnName("record_number");

                entity.Property(e => e.NumCases)
                    .HasColumnName("num_cases");

                entity.Property(e => e.NumDeaths)
                    .HasColumnName("num_deaths");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("region");

            });

            modelBuilder.Entity<DataIssuesDetail>(entity =>
            {
                entity.ToTable("data_issues_details");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.LoadId)
                    .HasColumnName("load_id");

                entity.Property(e => e.RecordNumber)
                    .HasColumnName("record_number");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(255)
                    .HasColumnName("column_name");

                entity.Property(e => e.IssueType)
                    .HasMaxLength(25)
                    .HasColumnName("issue_type");

                entity.Property(e => e.Issue)
                    .HasMaxLength(255)
                    .HasColumnName("issue");
                
            });

            modelBuilder.Entity<EnvInfo>(entity =>
            {
                entity.ToTable("env_info");

                entity.Property(e => e.Id)
                    .HasMaxLength(15)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Descr)
                    .HasMaxLength(255)
                    .HasColumnName("descr");


                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<LoadStat>(entity =>
            {
                entity.ToTable("load_stats");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BadDataCount).HasColumnName("bad_data_count");

                entity.Property(e => e.LoadStatus)
                    .HasColumnName("load_status")
                    .HasMaxLength(25);

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("region");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(255)
                    .HasColumnName("error_message");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .HasColumnName("file_path");

                entity.Property(e => e.LoadTimestamp)
                    .HasColumnName("load_timestamp")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.NumRecords).HasColumnName("num_records");

                entity.Property(e => e.WarningDataCount)
                    .HasColumnName("warning_data_count")
                    .HasDefaultValueSql("0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
