using DotaGuideToGreatness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotaGuideToGreatness.DAL
{
    public class DotaDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DotaDbContext(DbContextOptions<DotaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasMany(x => x.Spells)
                .WithOne(s => s.Hero)
                .HasForeignKey(f => f.HeroId);

            modelBuilder.Entity<Spell>()
                .HasOne(x => x.Hero)
                .WithMany(h => h.Spells);
        }

    }
}
