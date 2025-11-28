using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Models.Dtos.Company;
using PasantiasTW.Models.Dtos.Practice;
using PasantiasTW.Models.Dtos.Student;
using PasantiasTW.Repositories;
using PasantiasTW.Repositories.Interfaces;

namespace PasantiasTW.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IPracticeRepository _repo;
        private readonly IStudentRepository _studentRepository; 
        private readonly ICompanyRepository _companyRepository; 

        public PracticeService(
            IPracticeRepository repo,
            IStudentRepository studentRepository,
            ICompanyRepository companyRepository)
        {
            _repo = repo;
            _studentRepository = studentRepository;
            _companyRepository = companyRepository;
        }

        private PracticeStatus ParseStatusOrDefault(string? statusStr, PracticeStatus defaultValue)
        {
            if (string.IsNullOrWhiteSpace(statusStr))
                return defaultValue;

            if (statusStr == "Pending") { return PracticeStatus.Pending; }
            else if (statusStr == "Active") { return PracticeStatus.Active; }
            else if (statusStr == "Finished") { return PracticeStatus.Finished; }
                throw new ArgumentException($"Invalid Practice status value: '{statusStr}'");
        }

        private PracticeResponseDto MapToDto(Practice practice)
        {
            return new PracticeResponseDto
            {
                PracticeId = practice.PracticeId,
                StartDate = practice.StartDate,
                EndDate = practice.EndDate,
                Status = practice.Status,
                Student = new StudentReferenceDto 
                {
                    StudentId = practice.Student.Id,
                    Name = practice.Student.Name,
                    Career = practice.Student.Carrera
                },
                Company = new CompanyReferenceDto
                {
                    CompanyId = practice.Company.ID, 
                    Name = practice.Company.Name
                }
            };
        }

        public async Task<PracticeResponseDto> Create(CreatePracticeDto dto)
        {
            var student = await _studentRepository.GetOne(dto.StudentId);
            if (student is null) throw new Exception("Student not found");

            var company = await _companyRepository.GetOne(dto.CompanyId);
            if (company is null) throw new Exception("Company not found");

            var parsedStatus = ParseStatusOrDefault(dto.Status, PracticeStatus.Pending);

            var practice = new Practice
            {
                StudentId = dto.StudentId,
                CompanyId = dto.CompanyId,
                StartDate = dto.StartDate,
                Status = parsedStatus,
                Student = student, 
                Company = company 
            };

            await _repo.Create(practice);

            return MapToDto(practice);
        }

        public async Task Delete(Guid id)
        {
            var practice = await _repo.GetById(id);
            if (practice == null) throw new Exception("Practice not found");
            await _repo.Delete(practice);
        }

        public async Task<IEnumerable<PracticeResponseDto>> GetAll()
        {
            var practiceEntities = await _repo.GetAll();
            return practiceEntities.Select(MapToDto).ToList();
        }

        public async Task<PracticeResponseDto?> GetById(Guid id)
        {
            var practice = await _repo.GetById(id);
            if (practice == null) return null;
            return MapToDto(practice);
        }

        public async Task<PracticeResponseDto?> Update(Guid id, UpdatePracticeDto dto)
        {
            Practice? practice = await _repo.GetById(id);
            if (practice == null) return null;

            practice.EndDate = dto.EndDate;
            practice.Status = ParseStatusOrDefault(dto.Status, practice.Status);

            await _repo.Update(practice);
            return MapToDto(practice);
        }
    }
}