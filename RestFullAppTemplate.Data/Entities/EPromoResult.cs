using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFullAppTemplate.Data.Entities
{
    [PrimaryKey(nameof(ParticipantId), nameof(PrizeId))]
    public class EPromoResult
    {
        public int ParticipantId { get; set; }
        public int PrizeId { get; set; }
        public EParticipant? Participant { get; set; }
        public EPrize? Prize { get; set; }
        [Column("PromoId")]
        public int EPromoId { get; set; }
        public EPromo? EPromo { get; set; }
    }
}
