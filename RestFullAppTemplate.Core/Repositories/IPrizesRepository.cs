using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Repositories
{
    public interface IPrizesRepository
    {
        Task<Prize> Create(Prize prize);
        Task<bool> Delete(int prizeId);
        Task<IReadOnlyList<Prize>> GetList(int promoId);
    }
}
