using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Repositories;

namespace PasantiasTW.Services
{
    public class CompanyServices : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        public CompanyServices(ICompanyRepository repo)
        {
            _repo = repo;
        }
        public async Task<Company> CreateCompany(CreateCompanyDto dto)
        {
            var company = new Company
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email
            };
            await _repo.Add(company);
            return company;
        }

        public async Task DeleteCompany(Guid id)
        {
            Company? company = (await GetAll()).FirstOrDefault(x => x.ID == id);
            if (company == null) return;
            await _repo.Delete(company);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Company> GetOne(Guid id)
        {
            return await _repo.GetOne(id);
        }

        public async Task<Company> UpdateCompany(UpdateCompanyDto dto, Guid id)
        {
            Company? company = await GetOne(id);
            if (company == null) throw new Exception("company doesnt exist");
            company.Name = dto.Name;
            company.Address = dto.Address;
            company.Phone = dto.Phone;
            company.Email = dto.Email;

            await _repo.Update(company);
            return company;
        }
    }
}
