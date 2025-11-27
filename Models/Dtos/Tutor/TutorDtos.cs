using System.ComponentModel.DataAnnotations;

namespace PasantiasTW.Models.Dtos.Tutor
{
    public class ResponseTutorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }
        public Guid CompanyId { get; set; }


    }
}
