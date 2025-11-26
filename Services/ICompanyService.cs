using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;

namespace PasantiasTW.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponseDto>> GetAll();
        Task<CompanyResponseDto?> GetOne(Guid id);
        Task<CompanyResponseDto> CreateCompany(CreateCompanyDto dto);
        Task<CompanyResponseDto> UpdateCompany(UpdateCompanyDto dto, Guid id);
        Task DeleteCompany(Guid id);
    }
}
