using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Models.MalariaData;

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
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
