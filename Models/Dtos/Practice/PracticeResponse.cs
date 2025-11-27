using PasantiasTW.Models.Dtos.Company;
using PasantiasTW.Models.Dtos.Student;

namespace PasantiasTW.Models.Dtos.Practice
{
    public record PracticeResponseDto
    {
        public Guid PracticeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PracticeStatus Status { get; set; }

        public StudentReferenceDto Student { get; set; } = default!;
        public CompanyReferenceDto Company { get; set; } = default!;
    }
}