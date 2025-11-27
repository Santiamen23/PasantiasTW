namespace PasantiasTW.Models.Dtos
{
    public record PracticeResponseDto
    {
        public Guid PracticeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Practice  { get; set; } = string.Empty;
        public PracticeStatus Status { get; set; }

        public StudentReferenceDto Student { get; set; } = default!;
        public CompanyReferenceDto Company { get; set; } = default!;
    }
}