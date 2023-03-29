using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Core.Services;

namespace RestFullAppTemplate.Services.Services
{
    public class PromotionsService : IPromotionsService
    {
        private readonly IPromotionsRepository _promotionsRepository;
        private readonly IPrizesService _prizesService;
        private readonly IParticipantsService _participantsService;

        public PromotionsService(IPromotionsRepository promotionsRepository,
            IPrizesService prizesService, IParticipantsService participantsService)
        {
            _promotionsRepository = promotionsRepository;
            _participantsService = participantsService;
            _prizesService = prizesService;
        }

        public async Task<Promo> Create(string name, string? description)
        {
            var promo = new Promo() { Name = name, Description = description };
            return await _promotionsRepository.Create(promo);
        }

        public async Task<Promo> Get(int promoId)
        {
            return await _promotionsRepository.Get(promoId);
        }

        public async Task<bool> Delete(int promoId)
        {
            return await _promotionsRepository.Delete(promoId);
        }

        public async Task<bool> Update(Promo promo)
        {
            return await _promotionsRepository.Update(promo);
        }

        public async Task<IReadOnlyList<Promo>> GetAll()
        {
            return await _promotionsRepository.GetAll();
        }

        public async Task<IReadOnlyList<PromoResult>> Raffle(int promoId)
        {
            var prizes = new List<Prize>(await _prizesService.GetList(promoId));
            var participants = await _participantsService.GetList(promoId);
            if (prizes.Count != participants.Count) throw new Exception("promo can not raffle");

            var raffle = new List<PromoResult>(prizes.Count);
            var rnd = new Random();
            foreach (var participant in participants)
            {
                var indexPrize = rnd.Next(prizes.Count);
                var prize = prizes[indexPrize];
                raffle.Add(new PromoResult {ParticipantId = participant.Id, PrizeId = prize.Id});
                prizes.RemoveAt(indexPrize);
            }
            _promotionsRepository.AddResults(promoId, raffle);
            return raffle;
        }

        public async Task<IReadOnlyList<PromoResult>> GetResults(int promoId)
        {
            return await _promotionsRepository.GetResults(promoId);
        }
    }
}
