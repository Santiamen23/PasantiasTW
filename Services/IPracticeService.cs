using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface IPracticeService
    {
        Task<PracticeResponseDto> Create(CreatePracticeDto dto);
        Task<PracticeResponseDto?> Update(Guid id, UpdatePracticeDto dto);
        Task Delete(Guid id);

        Task<PracticeResponseDto?> GetById(Guid id);
        Task<IEnumerable<PracticeResponseDto>> GetAll();
    }
}