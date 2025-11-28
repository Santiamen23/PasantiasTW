using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Practice
{
    public record CreatePracticeDto
    {
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public string? Status { get; set; }
    }
}