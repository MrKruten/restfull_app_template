using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Core.Services;

namespace RestFullAppTemplate.Services.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly IParticipantsRepository _participantsRepository;

        public ParticipantsService(IParticipantsRepository participantsRepository)
        {
            _participantsRepository = participantsRepository;
        }

        public async Task<Participant> Create(Participant participant)
        {
            return await _participantsRepository.Create(participant);
        }

        public async Task<bool> Delete(int participantId)
        {
            return await _participantsRepository.Delete(participantId);
        }

        public async Task<IReadOnlyList<Participant>> GetList(int promoId)
        {
            return await _participantsRepository.GetList(promoId);
        }
    }
}
