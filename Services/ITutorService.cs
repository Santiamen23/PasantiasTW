using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface ITutorService
    {
        Task <IEnumerable<Tutor>> getAll();
        Task<Tutor> getById(Guid id);
        Task<Tutor>create(CreateTutorDto dto );
        Task<Tutor> update(Guid id, UpdateTutorDto dto);
        Task delete(Guid id);
    }
}
