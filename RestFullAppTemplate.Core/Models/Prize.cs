namespace RestFullAppTemplate.Core.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int PromoId { get; set; }
    }
}
