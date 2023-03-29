using System.ComponentModel.DataAnnotations;

namespace RestFullAppTemplate.Data.Entities
{
    public class EPromo
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<EPrize> Prizes { get; set; } = new();
        public List<EParticipant> Participants { get; set; } = new();
        public List<EPromoResult> PromoResults { get; set; } = new();
    }
}
