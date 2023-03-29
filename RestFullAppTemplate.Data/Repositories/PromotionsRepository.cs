using Mapster;
using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Data.Context;
using RestFullAppTemplate.Data.Entities;

namespace RestFullAppTemplate.Data.Repositories
{
    public class PromotionsRepository : BaseSqlRepository, IPromotionsRepository
    {
        public async Task<Promo> Create(Promo promo)
        {
            await using var db = DB;
            var result = await db.Promotions.AddAsync(promo.Adapt<EPromo>());
            await db.SaveChangesAsync();
            return result.Entity.Adapt<Promo>();
        }

        public async Task<Promo?> Get(int promoId)
        {
            await using var db = DB;
            var result = await db.Promotions.Where(x => x.Id == promoId).FirstOrDefaultAsync();
            return result?.Adapt<Promo>();
        }

        public async Task<bool> Delete(int promoId)
        {
            await using var db = DB;
            var rowCount = await db.Promotions.Where(x => x.Id == promoId).ExecuteDeleteAsync();
            await db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<bool> Update(Promo promo)
        {
            await using var db = DB;
            return await db.Promotions.Where(c => c.Id == promo.Id).ExecuteUpdateAsync(c => c
                .SetProperty(p => p.Name, promo.Name)
                .SetProperty(p => p.Description, promo.Description)) > 0;
        }

        public async Task<IReadOnlyList<Promo>> GetAll()
        {
            await using var db = DB;
            var result = db.Promotions.ToListAsync();
            return result.Adapt<IReadOnlyList<Promo>>();
        }

        public async void AddResults(int promoId, IReadOnlyList<PromoResult> results)
        {
            if (results == null || results.Count < 1)
                return;
            await using var db = DB;
            var adaptResults = results.Adapt<IReadOnlyList<EPromoResult>>();
            foreach (var res in adaptResults)
            {
                res.EPromoId = promoId;
            }

            await db.PromoResults.AddRangeAsync(adaptResults);
            await db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<PromoResult>> GetResults(int promoId)
        {
            await using var db = DB;
            var result = db.PromoResults.Where(res => res.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<PromoResult>>();
        }
    }
}