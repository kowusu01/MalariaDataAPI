using Microsoft.EntityFrameworkCore;

using Common.Models;
using Common.Models.WorldInfo;


namespace EfCoreLayer.WorldInfo
{
    public partial class WorlInfoApiDbContext : DbContext
    {
        public WorlInfoApiDbContext()
        {
        }

        public WorlInfoApiDbContext(DbContextOptions<WorlInfoApiDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EnvInfo> EnvInfos { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<WHORegion> WHORegions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WHORegion>(entity =>
            {
                entity.ToTable("who_region");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Descr)
                    .HasMaxLength(100)
                    .HasColumnName("descr");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CountryName)
                    .HasColumnName("name");

                entity.Property(e => e.OfficialName)
                    .HasColumnName("official_name");

                entity.Property(e => e.WHORegion)
                    .HasMaxLength(100)
                    .HasColumnName("who_region_name");

                entity.Property(e => e.WHORegionCode)
                    .HasMaxLength(10)
                    .HasColumnName("who_region_code");

                entity.Property(e => e.WHORegionName)
                    .HasMaxLength(100)
                    .HasColumnName("who_region_descr");

                entity.Property(e => e.IsWHOCountry)
                    .HasMaxLength(255)
                    .HasColumnName("is_who_country");

                entity.Property(e => e.ISO2)
                    .HasMaxLength(3)
                    .HasColumnName("iso_2");

                entity.Property(e => e.ISO3)
                    .HasMaxLength(3)
                    .HasColumnName("iso_3");

                entity.Property(e => e.ISONum)
                    .HasMaxLength(3)
                    .HasColumnName("iso_num");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
