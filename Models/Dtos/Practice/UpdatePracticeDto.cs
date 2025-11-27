using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Practice
{
    public record UpdatePracticeDto
    {
        public DateTime? EndDate { get; set; }
        [Required]
        [StringLength(50)]
        public PracticeStatus Status { get; set; }
    }
}