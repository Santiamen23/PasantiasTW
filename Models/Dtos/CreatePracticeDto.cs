using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos
{
    public record CreatePracticeDto
    {
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public PracticeStatus? Status { get; set; }
    }
}