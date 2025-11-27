using System.ComponentModel.DataAnnotations;
namespace PasantiasTW.Models.Dtos.Company
{
    public record CreateCompanyDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [StringLength(8, ErrorMessage = "This phone has more than 8 characters")]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
