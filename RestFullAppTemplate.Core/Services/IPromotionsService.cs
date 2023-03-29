using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Services
{
    public interface IPromotionsService
    {
        Task<Promo> Create(string name, string? description);
        Task<Promo> Get(int promoId);
        Task<bool> Delete(int promoId);
        Task<bool> Update(Promo promo);
        Task<IReadOnlyList<Promo>> GetAll();
        Task<IReadOnlyList<PromoResult>> Raffle(int promoId);
        Task<IReadOnlyList<PromoResult>> GetResults(int promoId);
    }
}
