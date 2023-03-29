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
            await using var db = DB;
            var result = await db.Participants.AddAsync(participant.Adapt<EParticipant>());
            await db.SaveChangesAsync();
            return result.Entity.Adapt<Participant>();
        }

        public async Task<bool> Delete(int participantId)
        {
            await using var db = DB;
            var rowCount = await db.Participants.Where(x => x.Id == participantId).ExecuteDeleteAsync();
            await db.SaveChangesAsync();
            return rowCount > 0;
        }

        public async Task<IReadOnlyList<Participant>> GetList(int promoId)
        {
            await using var db = DB;
            var result = await db.Participants.Where(p => p.EPromoId == promoId).ToListAsync();
            return result.Adapt<IReadOnlyList<Participant>>();
        }
    }
}