namespace PasantiasTW.Models.Dtos.Student
{
    public record UpdateStudentDto
    {
        public string Name { get; set; } 
        public string Email {  get; set; } 
        public string Carrera {  get; set; } 
        public string Phone { get; set; } 
    }
}
