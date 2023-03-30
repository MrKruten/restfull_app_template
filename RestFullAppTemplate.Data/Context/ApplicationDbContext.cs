using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Data.Entities;

namespace RestFullAppTemplate.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EPromo> Promotions { get; set; } = null!;
        public DbSet<EParticipant> Participants { get; set; } = null!;
        public DbSet<EPrize> Prizes { get; set; } = null!;
        public DbSet<EPromoResult> PromoResults { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=templateDb;Username=postgres;Password=admin");
            }
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
