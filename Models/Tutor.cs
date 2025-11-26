namespace PasantiasTW.Models
{
    public class Tutor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public string Phone { get; set; }

        public Company? Company { get; set; }

        public Guid CompanyId { get; set; }
    }
}
