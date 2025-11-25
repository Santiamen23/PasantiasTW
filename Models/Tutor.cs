namespace PasantiasTW.Models
{
    public class Tutor
    {
        public Guid id { get; set; }=Guid.NewGuid();
        public string name { get; set; }

        public string telephone { get; set; }
    }
}
