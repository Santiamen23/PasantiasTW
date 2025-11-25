using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos
{
    public record CreateTutorDto
    {
        [Required,StringLength(200)]
        public string name { get; set; }

        [Required,StringLength(15)]
        public string telephone { get; set; }
    }
}
