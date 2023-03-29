using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Core.Services;

namespace RestFullAppTemplate.Services.Services
{
    public class PrizesService : IPrizesService
    {
        private readonly IPrizesRepository _prizesRepository;

        public PrizesService(IPrizesRepository prizesRepository)
        {
            _prizesRepository = prizesRepository;
        }

        public async Task<Prize> Create(Prize prize)
        {
            return await _prizesRepository.Create(prize);
        }

        public async Task<bool> Delete(int prizeId)
        {
            return await _prizesRepository.Delete(prizeId);
        }

        public async Task<IReadOnlyList<Prize>> GetList(int promoId)
        {
            return await _prizesRepository.GetList(promoId);
        }
    }
}
