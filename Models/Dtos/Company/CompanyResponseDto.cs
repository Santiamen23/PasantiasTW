using PasantiasTW.Models.Dtos.Practice;
using PasantiasTW.Models.Dtos.Student;
using PasantiasTW.Models.Dtos.Tutor;

namespace PasantiasTW.Models.Dtos.Company
{
    public record CompanyResponseDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ResponseTutorDto? Tutor { get; set; }
        public IEnumerable<StudentReferenceDto>? Students { get; set; }
        public IEnumerable<PracticeBriefDto>? Practices { get; set; }
    }
}
