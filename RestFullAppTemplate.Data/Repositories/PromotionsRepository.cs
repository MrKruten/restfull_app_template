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
        public PromotionsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<Promo> Create(Promo promo)
        {
            var result = await Db.Promotions.AddAsync(promo.Adapt<EPromo>());
            await Db.SaveChangesAsync();
            return result.Entity.Adapt<Promo>();
        }

        public async Task<Promo?> Get(int promoId)
        {
            var result = await Db.Promotions.Where(x => x.Id == promoId).FirstOrDefaultAsync();
            return result?.Adapt<Promo>();
        }

        public async Task<bool> Delete(int promoId)
        {
            var rowCount = await Db.Promotions.Where(x => x.Id == promoId).ExecuteDeleteAsync();
            await Db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<bool> Update(Promo promo)
        {
            return await Db.Promotions.Where(c => c.Id == promo.Id).ExecuteUpdateAsync(c => c
                .SetProperty(p => p.Name, promo.Name)
                .SetProperty(p => p.Description, promo.Description)) > 0;
        }

        public async Task<IReadOnlyList<Promo>> GetAll()
        {
            var result = await Db.Promotions.ToListAsync();
            return result.Adapt<IReadOnlyList<Promo>>();
        }

        public async void AddResults(int promoId, IReadOnlyList<PromoResult> results)
        {
            if (results == null || results.Count < 1)
                return;
            var adaptResults = results.Adapt<IReadOnlyList<EPromoResult>>();
            foreach (var res in adaptResults)
            {
                res.EPromoId = promoId;
            }

            await Db.PromoResults.AddRangeAsync(adaptResults);
            await Db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<PromoResult>> GetResults(int promoId)
        {
            var result = await Db.PromoResults.Where(res => res.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<PromoResult>>();
        }
    }
}