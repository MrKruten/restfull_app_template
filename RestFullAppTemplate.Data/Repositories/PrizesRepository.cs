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
        public async Task<Prize> Create(Prize prize)
        {
            await using var db = DB;
            var result = await db.Prizes.AddAsync(prize.Adapt<EPrize>());
            await db.SaveChangesAsync();
            return result.Entity.Adapt<Prize>();
        }

        public async Task<bool> Delete(int prizeId)
        {
            await using var db = DB;
            var rowCount = await db.Prizes.Where(x => x.Id == prizeId).ExecuteDeleteAsync();
            await db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<IReadOnlyList<Prize>> GetList(int promoId)
        {
            await using var db = DB;
            var result = await db.Prizes.Where(p => p.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<Prize>>();
        }
    }
}