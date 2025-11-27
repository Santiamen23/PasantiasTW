namespace PasantiasTW.Models.Dtos
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