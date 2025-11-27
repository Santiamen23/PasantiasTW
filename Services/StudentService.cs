using PasantiasTW.Models;
using PasantiasTW.Models.Dtos.Student;
using PasantiasTW.Repositories;

namespace PasantiasTW.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        private StudentResponseDto MapToDto(Student student)
        {
            return new StudentResponseDto
            {
                Id=student.Id,
                Name=student.Name,
                Email=student.Email,
                Carrera=student.Carrera,
                Phone=student.Phone,
            };
        }
        public async Task<StudentResponseDto> CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Carrera = dto.Carrera,
                Phone = dto.Phone,
            };
            await _repo.Add(student);
            return MapToDto(student);
        }

        public async Task DeleteStudent(Guid id)
        {
            var student = await _repo.GetOne(id);
            if (student == null) return;
            await _repo.Delete(student);
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAll()
        {
            var students = await _repo.GetAll();
            return students.Select(MapToDto).ToList();
        }

        public async Task<StudentResponseDto?> GetOne(Guid id)
        {
            var student = await _repo.GetOne(id);
            return student == null ? null : MapToDto(student);
        }

        public async Task<StudentResponseDto> UpdateStudent(UpdateStudentDto dto, Guid id)
        {
            var student = await _repo.GetOne(id);

            if (student == null) throw new Exception("student doesnt exist");
            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Carrera = dto.Carrera;
            student.Phone = dto.Phone;

            await _repo.Update(student);
            return MapToDto(student);
        }
    }
}
