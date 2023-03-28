using Microsoft.EntityFrameworkCore;

namespace RestFullAppTemplate.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


    }
}
