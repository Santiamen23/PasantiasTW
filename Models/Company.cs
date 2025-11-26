namespace PasantiasTW.Models
{
    public class Company
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Tutor? Tutor { get; set; }
        public ICollection<StudentCompany> StudentCompany { get; set; } = new List<StudentCompany>();
        //public ICollection<Practice> Practices { get; set; } = new List<Practice>(); igual creo que se usara
    }
}
