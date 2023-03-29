using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Repositories
{
    public interface IParticipantsRepository
    {
        Task<Participant?> Create(Participant participant);
        Task<bool> Delete(int participantId);
        Task<IReadOnlyList<Participant>> GetList(int promoId);
    }
}
