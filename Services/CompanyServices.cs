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
        private CompanyResponseDto MapToDto(Company company)
        {
            return new CompanyResponseDto
            {
                CompanyId = company.ID,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Email = company.Email,

                Tutor = company.Tutor is null
                    ? null
                    : new ResponseTutorDto
                    {
                        Id = company.Tutor.Id,
                        Name = company.Tutor.Name,
                        Phone = company.Tutor.Phone
                    },

                Students = company.StudentCompany?
                    .Select(sc => new StudentReferenceDto
                    {
                        StudentId = sc.Student.Id,
                        Name = sc.Student.Name,
                        Career = sc.Student.Carrera
                    }),

                Practices = company.Practices?
                    .Select(p => new PracticeBriefDto
                    {
                        PracticeId = p.PracticeId,
                        Status = p.Status,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    })
            };
        }
        public async Task<CompanyResponseDto> CreateCompany(CreateCompanyDto dto)
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
            return MapToDto(company);
        }

        public async Task DeleteCompany(Guid id)
        {
            var company = await _repo.GetOne(id);
            if (company == null) return;
            await _repo.Delete(company);
        }

        public async Task<IEnumerable<CompanyResponseDto>> GetAll()
        {
            var companies = await _repo.GetAll();
            return companies.Select(MapToDto);
        }

        public async Task<CompanyResponseDto?> GetOne(Guid id)
        {
            var company = await _repo.GetOne(id);
            return company is null ? null : MapToDto(company);
        }

        public async Task<CompanyResponseDto> UpdateCompany(UpdateCompanyDto dto, Guid id)
        {
            var company = await _repo.GetOne(id);
            if (company == null) throw new Exception("company doesnt exist");
            
            company.Name = dto.Name;
            company.Address = dto.Address;
            company.Phone = dto.Phone;
            company.Email = dto.Email;

            await _repo.Update(company);
            return MapToDto(company);
        }
    }
}
