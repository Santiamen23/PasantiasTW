using PasantiasTW.Models;

namespace PasantiasTW.Repositories.Interfaces
{
    public interface IPracticeRepository
    {
        Task Create(Practice practice);
        Task Update(Practice practice);
        Task Delete(Practice practice);

        Task<Practice?> GetById(Guid id);
        Task<IEnumerable<Practice>> GetAll();
    }
}