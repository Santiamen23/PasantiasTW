using PasantiasTW.Models;

namespace PasantiasTW.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetOne(Guid id);
        Task Add(Company company);
        Task Update(Company company);
        Task Delete(Company company);
    }
}
