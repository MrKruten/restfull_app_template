using RestFullAppTemplate.Data.Context;

namespace RestFullAppTemplate.Data.Repositories
{
    public abstract class BaseSqlRepository
    {
        protected ApplicationDbContext DB;

        protected BaseSqlRepository(ApplicationDbContext db)
        {
            DB = db;
        }
    }
}