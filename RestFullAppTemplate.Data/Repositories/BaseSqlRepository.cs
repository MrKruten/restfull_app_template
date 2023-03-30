using RestFullAppTemplate.Data.Context;

namespace RestFullAppTemplate.Data.Repositories
{
    public abstract class BaseSqlRepository
    {
        protected ApplicationDbContext Db;

        public BaseSqlRepository(ApplicationDbContext db)
        {
            Db = db;
        }
    }
}