using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Data.Context;

namespace RestFullAppTemplate.Data.Base
{
    public abstract class BaseSqlRepository
    {
        protected ApplicationDbContext Db;

        protected BaseSqlRepository(ApplicationDbContext db)
        {
            Db = db;
        }
    }
}