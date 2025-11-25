namespace PasantiasTW.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
    }
}
