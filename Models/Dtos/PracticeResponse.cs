namespace PasantiasTW.Models.Dtos
{
    public record PracticeResponseDto
    {
        public Guid PracticeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;

        /*public StudentReferenceDto Student { get; set; } = default!;
        public CompanyReferenceDto Company { get; set; } = default!; no se si las crearan xd, pero por si acaso*/
    }
}