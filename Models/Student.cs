namespace PasantiasTW.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;

        public ICollection<StudentCompany> StudentCompany = new List<StudentCompany>();
        //public ICollection<Practice> Practices { get; set; } = new List<Practice>(); creo que se usara xd
    }
}
