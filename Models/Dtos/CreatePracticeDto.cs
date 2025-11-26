using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos
{
    public record CreatePracticeDto
    {
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [StringLength(50)]
        public PracticeStatus? Status { get; set; }
    }
}