using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Services
{
    public interface IPrizesService
    {
        Task<Prize> Create(Prize prize);
        Task<bool> Delete(int prizeId);
        Task<IReadOnlyList<Prize>> GetList(int promoId);
    }
}
