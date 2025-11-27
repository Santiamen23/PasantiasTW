namespace PasantiasTW.Models.Dtos
{
    public record CompanyReferenceDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
