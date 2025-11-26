namespace PasantiasTW.Models
{
    public class Student
    {
        public Guid PracticeId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public Company Company = default;
    }
}