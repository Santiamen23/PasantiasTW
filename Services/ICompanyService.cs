using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetOne(Guid id);
        Task<Company> CreateCompany(CreateCompanyDto dto);
        Task<Company> UpdateCompany(UpdateCompanyDto dto, Guid id);
        Task DeleteCompany(Guid id);
    }
}
