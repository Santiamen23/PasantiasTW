using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface ITutorService
    {
        Task <IEnumerable<ResponseTutorDto>> getAll();
        Task<ResponseTutorDto> getById(Guid id);
        Task<ResponseTutorDto>create(CreateTutorDto dto );
        Task<ResponseTutorDto> update(Guid id, UpdateTutorDto dto);
        Task delete(Guid id);
    }
}
