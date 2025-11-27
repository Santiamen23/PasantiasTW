namespace PasantiasTW.Models.Dtos.Practice
{
    public record PracticeBriefDto
    {
        public Guid PracticeId { get; set; }
        public PracticeStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
