using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Student
{
    public record CreateStudentDto
    {
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Career { get; set; }
        [StringLength(8,ErrorMessage ="This phone number has more than 8 numbers")]
        public required string Phone { get; set; }
    }
}
