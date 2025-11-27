namespace PasantiasTW.Models
{
    public enum PracticeStatus
    {
        Pending,
        Active,
        Finished
    }

    public class Practice
    {
        public Guid PracticeId { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime StartDate { get; set; }=DateTime.UtcNow;
        public DateTime? EndDate { get; set; }=DateTime.UtcNow.AddMonths(2);
        public PracticeStatus Status { get; set; } = PracticeStatus.Pending;

        public Company Company { get; set; } = default!;
        public Student Student { get; set; } = default!;
    }
}