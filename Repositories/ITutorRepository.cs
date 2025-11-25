using PasantiasTW.Models;

namespace PasantiasTW.Repositories
{
    public interface ITutorRepository
    {
        Task create(Tutor tutor );
        Task <IEnumerable<Tutor>> getAll();

        Task<Tutor?> getById(Guid id);

        Task update(Tutor tutor);

        Task delete(Tutor tutor);

    }
}
