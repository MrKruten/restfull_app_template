using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFullAppTemplate.Data.Entities
{
    public class EParticipant
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        [Column("PromoId")]
        public int EPromoId { get; set; }
        public EPromo? EPromo { get; set; }
    }
}
