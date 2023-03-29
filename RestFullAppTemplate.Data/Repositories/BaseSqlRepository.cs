using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Data.Context;

namespace RestFullAppTemplate.Data.Repositories
{
    public abstract class BaseSqlRepository
    {
        private static readonly DbContextOptions<ApplicationDbContext> _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql("Host=localhost;Port=5432;Database=templateDb;Username=postgres;Password=admin").Options;
        /// <summary>
        /// make call through: "using var db = DB"
        /// </summary>
        protected ApplicationDbContext DB => new(_options);
    }
}