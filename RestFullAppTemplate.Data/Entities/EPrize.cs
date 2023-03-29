using System.ComponentModel.DataAnnotations.Schema;

namespace RestFullAppTemplate.Data.Entities
{
    public class EPrize
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        [Column("PromoId")]
        public int EPromoId { get; set; }
        public EPromo? EPromo { get; set; }
    }
}
