using MMA_site_app.Models;
using Microsoft.EntityFrameworkCore;

namespace MMA_site_app.Data {
    public class FighterContext : DbContext {
        public FighterContext(DbContextOptions<FighterContext> options) : base(options) {
        }

        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Perfomanse> Perfomanses { get; set; }
        public DbSet<TitleHolder> TitleHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Fighter>().ToTable("Fighter");
            modelBuilder.Entity<Perfomanse>().ToTable("Perfomanse");
            modelBuilder.Entity<TitleHolder>().ToTable("TitleHolder");
        }
    }
}
