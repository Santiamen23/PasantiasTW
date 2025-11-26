using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetAll();
        Task<StudentResponseDto?> GetOne(Guid id);
        Task<StudentResponseDto> CreateStudent(CreateStudentDto dto);
        Task<StudentResponseDto> UpdateStudent(UpdateStudentDto dto, Guid id);
        Task DeleteStudent(Guid id);
    }
}
