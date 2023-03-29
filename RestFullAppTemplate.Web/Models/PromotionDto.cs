using System.ComponentModel.DataAnnotations;

namespace RestFullAppTemplate.Web.Models
{
    public class PromotionDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
