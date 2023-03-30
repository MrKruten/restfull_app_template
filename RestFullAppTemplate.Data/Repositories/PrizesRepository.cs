using Mapster;
using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Data.Context;
using RestFullAppTemplate.Data.Entities;

namespace RestFullAppTemplate.Data.Repositories
{
    public class PrizesRepository : BaseSqlRepository, IPrizesRepository
    {
        public PrizesRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<Prize> Create(Prize prize)
        {
            var result = await Db.Prizes.AddAsync(prize.Adapt<EPrize>());
            await Db.SaveChangesAsync();
            return result.Entity.Adapt<Prize>();
        }

        public async Task<bool> Delete(int prizeId)
        {
            var rowCount = await Db.Prizes.Where(x => x.Id == prizeId).ExecuteDeleteAsync();
            await Db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<IReadOnlyList<Prize>> GetList(int promoId)
        {
            var result = await Db.Prizes.Where(p => p.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<Prize>>();
        }
    }
}