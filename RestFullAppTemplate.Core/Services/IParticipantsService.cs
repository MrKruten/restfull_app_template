using RestFullAppTemplate.Core.Models;

namespace RestFullAppTemplate.Core.Services
{
    public interface IParticipantsService
    {
        Task<Participant> Create(Participant participant);
        Task<bool> Delete(int participantId);
        Task<IReadOnlyList<Participant>> GetList(int promoId);
    }
}
