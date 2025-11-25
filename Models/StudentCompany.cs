namespace PasantiasTW.Models

{
    public class StudentCompany
    {
        public Guid StudentID { get; set; }
        public Student Student { get; set; } = default!;
        public Guid CompanyID { get; set; }
        public Company Company { get; set; } = default!;
    }
}
