using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Practice
{
    public record UpdatePracticeDto
    {
        public DateTime? EndDate { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}