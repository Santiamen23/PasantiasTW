namespace PasantiasTW.Models.Dtos.Student
{
    public record StudentReferenceDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Career { get; set; } = string.Empty;
    }
}
