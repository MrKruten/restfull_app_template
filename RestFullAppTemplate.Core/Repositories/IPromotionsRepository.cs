using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Repositories
{
    public interface IPromotionsRepository
    {
        Task<Promo> Create(Promo promo);
        Task<Promo?> Get(int promoId);
        Task<bool> Delete(int promoId);
        Task<bool> Update(Promo promo);
        Task<IReadOnlyList<Promo>> GetAll();
        void AddResults(int promoId, IReadOnlyList<PromoResult> results);
        Task<IReadOnlyList<PromoResult>> GetResults(int promoId);
    }
}
