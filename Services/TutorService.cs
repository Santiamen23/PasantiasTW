using PasantiasTW.Models;
using PasantiasTW.Models.Dtos.Tutor;
using PasantiasTW.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PasantiasTW.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repo;
        private readonly ICompanyRepository _companyRepository;
        public TutorService(ITutorRepository repo,ICompanyRepository companyRepository)
        {
            _repo = repo;
            _companyRepository = companyRepository;
        }
        public async Task<ResponseTutorDto> create(CreateTutorDto dto)
        {
            var company = await _companyRepository.GetOne(dto.CompanyId);
            if (company is null) throw new Exception("Company not found");
            var tutor = new Tutor
            {
                Name = dto.Name,
                Phone = dto.Phone, 
                Company=company,
                CompanyId =company.ID
            };
            await _repo.create(tutor);
            return new ResponseTutorDto { 
                Id= tutor.Id,
                Name= dto.Name,
                Phone=dto.Phone,
                Company=company.Name,
                CompanyId=company.ID
            };

        }

        public async Task delete(Guid id)
        {
            var delete = await _repo.getById(id);
            if (delete == null) throw new Exception("Tutor not found");
            await _repo.delete(delete);
        }

        public async Task<IEnumerable<ResponseTutorDto>> getAll()
        {
            var tutorsEntities = await _repo.getAll();
            var tutorsDtos = tutorsEntities.Select(t => new ResponseTutorDto
            {
                Id = t.Id,
                Name = t.Name,
                Phone = t.Phone,
                CompanyId = t.CompanyId,
                Company = t.Company.Name
            }).ToList();

            return tutorsDtos;
        }

        public async Task<ResponseTutorDto?> getById(Guid id)
        {
            var tutor=await _repo.getById(id);
            if (tutor == null) return null;
            return new ResponseTutorDto
            {
                Id = tutor.Id,
                Name = tutor.Name,
                Phone = tutor.Phone,
                Company = tutor.Company.Name,
                CompanyId = tutor.CompanyId
            };
        }

        public async Task<ResponseTutorDto> update(Guid id, UpdateTutorDto dto)
        {
            Tutor? tutor = await _repo.getById(id);
            if (tutor == null) throw new Exception("Tutor not found");
            var company = await _companyRepository.GetOne(tutor.CompanyId);
            if (company is null) throw new Exception("Company not found");
            tutor.Name = dto.Name;
            tutor.Phone = dto.Phone;
            tutor.CompanyId = dto.CompanyId;
            tutor.Company = company;
            await _repo.update(tutor);
            return new ResponseTutorDto
            {
                Id = tutor.Id,
                Name = tutor.Name,
                Phone = tutor.Phone,
                Company = company.Name,
                CompanyId = company.ID
            };
        }
    }
}
