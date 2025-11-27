using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Tutor
{
    public record UpdateTutorDto
    {
        [Required,StringLength(200)]
        public string Name { get; set; }

        [Required,StringLength(15)]
        public string Phone { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
    }
}
