namespace PasantiasTW.Models.Dtos.Company
{
    public record CompanyReferenceDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
