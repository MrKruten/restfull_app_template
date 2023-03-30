using Mapster;
using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Repositories;
using RestFullAppTemplate.Data.Context;
using RestFullAppTemplate.Data.Entities;

namespace RestFullAppTemplate.Data.Repositories
{
    public class ParticipantsRepository : BaseSqlRepository, IParticipantsRepository
    {
        public ParticipantsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<Participant> Create(Participant participant)
        {
            var result = await Db.Participants.AddAsync(participant.Adapt<EParticipant>());
            await Db.SaveChangesAsync();
            return result.Entity.Adapt<Participant>();
        }

        public async Task<bool> Delete(int participantId)
        {
            var rowCount = await Db.Participants.Where(x => x.Id == participantId).ExecuteDeleteAsync();
            await Db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<IReadOnlyList<Participant>> GetList(int promoId)
        {
            var result = await Db.Participants.Where(p => p.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<Participant>>();
        }
    }
}