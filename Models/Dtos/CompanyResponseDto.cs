namespace PasantiasTW.Models.Dtos
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
